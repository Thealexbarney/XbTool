using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using BdatEditor.Bdat;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using XbTool.Bdat;
using XbTool.Common;

namespace BdatEditor.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand OpenBdatCommand { get; set; }
        public ICommand ViewTableCommand { get; set; }
        public ICommand SaveTableCommand { get; set; }
        public ICommand RefreshTableCommand { get; set; }

        public ICommand StringExportCommand { get; set; }
        public ICommand StringImportCommand { get; set; }


        private bool IsFileOpened { get; set; }
        private bool IsTableOpened { get; set; }

        public BdatTables BdatTables { get; private set; }
        private string Filename { get; set; }
        public string FileDisplayName { get; set; } = "Select a file";
        public List<string> TableNames { get; private set; }
        public int SelectedTable { get; set; }
        public BdatTable CurrentTable { get; set; }
        public DataTable EditingTable { get; set; }

        public MainViewModel()
        {
            OpenBdatCommand = new RelayCommand(OpenBdatViaFileBrowser);
            ViewTableCommand = new RelayCommand(ViewTable);
            SaveTableCommand = new RelayCommand(SaveTable);
            RefreshTableCommand = new RelayCommand(RefreshTable);
            StringExportCommand = new RelayCommand(StringExport);
            StringImportCommand = new RelayCommand(StringImport);
        }

        private void tables_list_DoubleClick(object sender, System.EventArgs e)
        {
            ViewTable();
        }


        public void OpenBdatViaFileBrowser()
        {
            Filename = OpenViaFileBrowser(".bdat", "BDAT Files (*.bdat)|*.bdat|All Files|*.*");
            if (Filename == null)
                return;
            OpenBdat(Filename);
            FileDisplayName = Filename.Split('\\')[Filename.Split('\\').Length - 1];
            CurrentTable = null;
            EditingTable = new DataTable();
            EditingTable.AcceptChanges();
        }


        public void StringExport()
        {
            var Files = OpenViaFileBrowser(".bdat", "BDAT Files (*.bdat)|*.bdat|All Files|*.*", true);
            if (Files == null)
                return;

            foreach (var File in Files) {
                List<string> Lines = new List<string>();
                var Info = LoadBdat(File);
                foreach (var Table in Info.BDAT.Tables) {
                    var CurrentTable = new EditTable(Table);
                    foreach (var Row in CurrentTable.Items)
                    {
                        for (int Col = 1; Col < Row.Length; Col++)
                        {
                            var ColumnValue = Row[Col];
                            var ColumnInfo = CurrentTable.Columns[Col - 1];
                            if (ColumnInfo.ValType != BdatValueType.String)
                                continue;

                            Lines.Add(Escape((string)ColumnValue));
                        }
                    }
                }

                string OutFile = File + ".txt";

                using (StreamWriter Writer = System.IO.File.CreateText(OutFile)) {
                    foreach (var Line in Lines)
                        Writer.WriteLine(Line);
                }
            }
            MessageBox.Show("Exported!");
        }

        public void StringImport()
        {
            var Files = OpenViaFileBrowser(".bdat", "BDAT Files (*.bdat)|*.bdat|All Files|*.*", true);
            if (Files == null)
                return;
            
            bool IgnoreLimit = false;

            foreach (var File in Files)
            {
                string TxtFile = File + ".txt";
                string OutFile = File + ".new";

                if (!System.IO.File.Exists(TxtFile))
                    continue;

                string[] Lines = System.IO.File.ReadAllLines(TxtFile);
                int i = 0;

                var Info = LoadBdat(File);
                foreach (var Table in Info.BDAT.Tables)
                {
                    var CurrentTable = new EditTable(Table);
                    foreach (var Row in CurrentTable.Items)
                    {
                        for (int Col = 1; Col < Row.Length; Col++)
                        {
                            var ColumnValue = Row[Col];
                            var ColumnInfo = CurrentTable.Columns[Col - 1];
                            if (ColumnInfo.ValType != BdatValueType.String)
                                continue;

                            var OriLine = Table.ReadValue((int)Row.First(), ColumnInfo.Name);
                            var NewLine = Unescape(Lines[i++]);
                            if (!IgnoreLimit && NewLine.Length > OriLine.Length) {
                                IgnoreLimit = MessageBoxResult.Yes == MessageBox.Show($"The line {i - 1} has more character than the original line. Ignore?", "Error at " + Path.GetFileName(File), MessageBoxButton.YesNo, MessageBoxImage.Error); ;
                                if (!IgnoreLimit)
                                    return;
                            }
                            if (NewLine.Length > OriLine.Length) {
                                NewLine = NewLine.Substring(0, OriLine.Length);

                                //Remove Possible Open Tags after the cut
                                if (NewLine.LastIndexOf(']') < NewLine.LastIndexOf('['))
                                    NewLine = NewLine.Substring(0, NewLine.LastIndexOf('['));
                            }

                            Table.WriteValue((int)Row.First(), ColumnInfo.Name, NewLine);
                        }
                    }
                }

                System.IO.File.WriteAllBytes(OutFile, Info.BDAT.FileData);
            }
            MessageBox.Show("Imported!");
        }

        public void ViewTable()
        {
            if (!IsFileOpened) return;

            BdatTable table = BdatTables.Tables[SelectedTable];
            CurrentTable = table;
            RefreshTable();
        }

        public void RefreshTable() {
            if (CurrentTable == null) return;
            var editTable = new EditTable(CurrentTable);
            EditingTable = new DataTable();
            EditingTable.Columns.Add(new DataColumn("ID") { ReadOnly = true });
            foreach (BdatMember col in editTable.Columns)
            {
                var column = new DataColumn();
                /*if (col.Type != BdatMemberType.Scalar)
                {
                    column.ReadOnly = true;
                }*/

                column.ColumnName = $"{col.Name}\n({col.ValType})";
                EditingTable.Columns.Add(column);
            }

            foreach (object[] item in editTable.Items)
            {
                DataRow row = EditingTable.NewRow();
                row.ItemArray = item;
                EditingTable.Rows.Add(item);
            }

            EditingTable.AcceptChanges();
            IsTableOpened = true;

            DataTable temp = EditingTable;
            EditingTable = null;
            EditingTable = temp;
        }
        public void SaveTable()
        {
            if (!IsTableOpened) return;

            DataTable rows = EditingTable.GetChanges();
            if (rows == null) return;
            BdatMember[] members = CurrentTable.Members;

            foreach (DataRow row in rows.Rows.Cast<DataRow>())
            {
                int itemId = int.Parse((string)row.ItemArray[0]);
                for (int m = 0; m < members.Length; m++)
                {
                    //if (members[m].Type != BdatMemberType.Scalar) continue;
                    string value = (string)row.ItemArray[m + 1];
                    try
                    {
                        CurrentTable.WriteValue(itemId, members[m].Name, value);
                    }
                    catch (Exception ex)
                    {
                        string caption = null;
                        if (ex is ArgumentOutOfRangeException)
                        {
                            caption = "Error: " + ex.Message;
                        }

                        if (ex is FormatException || ex is OverflowException)
                        {
                            caption = $"Error parsing \"{value}\" as a {members[m].ValType} " +
                                      $"from Item \"{itemId}\" Column \"{members[m].Name}\".";
                        }
                        else
                        {

                            if (caption == null) throw;

                            MessageBox.Show(caption, "Format Error");
                        }
                    }
                }
            }

            File.WriteAllBytes(Filename, BdatTables.FileData);

            EditingTable.AcceptChanges();
        }

        public string Escape(string Str) {
            StringBuilder Result = new StringBuilder();
            foreach (var Char in Str) {
                switch (Char) {
                    case '\n':
                        Result.Append("\\n");
                        break;
                    case '\r':
                        Result.Append("\\r");
                        break;
                    case '\\':
                        Result.Append("\\\\");
                        break;
                    default:
                        Result.Append(Char);
                        break;
                }
            }
            return Result.ToString();
        }
        public string Unescape(string Str)
        {
            StringBuilder Result = new StringBuilder();
            bool InEscape = false;
            foreach (var Char in Str)
            {
                switch (Char)
                {
                    case 'n':
                        if (!InEscape)
                            goto default;

                        Result.Append("\n");
                        InEscape = false;
                        break;
                    case 'r':
                        if (!InEscape)
                            goto default;

                        Result.Append("\r");
                        InEscape = false;
                        break;
                    case '\\':
                        if (InEscape)
                            goto default;

                        InEscape = true;
                        break;
                    default:
                        InEscape = false;
                        Result.Append(Char);
                        break;
                }
            }
            return Result.ToString();
        }

        public (BdatTables BDAT, List<string> Names) LoadBdat(string filename) {
            BdatTables Tables;
            List<string> Names;
            try
            {
                Tables = new BdatTables(filename, Game.XB2, false);
                Names = Tables.Tables.Select(x => x.Name).ToList();
            }
            catch
            {
                try
                {
                    Tables = new BdatTables(filename, Game.XBX, false);
                    Names = Tables.Tables.Select(x => x.Name).ToList();
                }
                catch
                {
                    try
                    {
                        Tables = new BdatTables(filename, Game.XB1DE, false);
                        Names = Tables.Tables.Select(x => x.Name).ToList();
                    }
                    catch
                    {
                        return (null, null);
                    }
                }
            }

            return (Tables, Names);
        }
        public void OpenBdat(string filename)
        {
            var Info = LoadBdat(filename);
            if (Info.BDAT == null) {
                MessageBox.Show("Failed to open file. Is it a valid bdat?");
                return;
            }

            BdatTables = Info.BDAT;
            TableNames = Info.Names;
            IsFileOpened = true;
        }

        private static string OpenViaFileBrowser(string extension, string filter)
        {
            var openDialog = new OpenFileDialog
            {
                DefaultExt = extension,
                Filter = filter
            };

            if (openDialog.ShowDialog() != true) return null;

            return openDialog.FileName;
        }
        private static string[] OpenViaFileBrowser(string extension, string filter, bool Multi)
        {
            var openDialog = new OpenFileDialog
            {
                DefaultExt = extension,
                Filter = filter,
                Multiselect = Multi
            };

            if (openDialog.ShowDialog() != true) return null;

            return openDialog.FileNames;
        }
    }
}

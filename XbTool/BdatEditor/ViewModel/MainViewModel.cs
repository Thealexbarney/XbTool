using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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

        public void OpenBdat(string filename)
        {
            try
            {
                BdatTables = new BdatTables(filename, Game.XB2, false);
                TableNames = BdatTables.Tables.Select(x => x.Name).ToList();
                IsFileOpened = true;
            }
            catch
            {
                try
                {
                    BdatTables = new BdatTables(filename, Game.XBX, false);
                    TableNames = BdatTables.Tables.Select(x => x.Name).ToList();
                    IsFileOpened = true;
                }
                catch
                {
                    try
                    {
                        BdatTables = new BdatTables(filename, Game.XB1DE, false);
                        TableNames = BdatTables.Tables.Select(x => x.Name).ToList();
                        IsFileOpened = true;
                    }
                    catch
                    {
                        MessageBox.Show("Failed to open file. Is it a valid bdat?");
                    }
                }
            }
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
    }
}

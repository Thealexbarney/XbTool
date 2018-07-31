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

        private bool IsFileOpened { get; set; }
        private bool IsTableOpened { get; set; }

        public BdatTables BdatTables { get; private set; }
        private string Filename { get; set; }
        public List<string> TableNames { get; private set; }
        public int SelectedTable { get; set; }
        private BdatTable CurrentTable { get; set; }
        public DataTable EditingTable { get; set; }

        public MainViewModel()
        {
            OpenBdatCommand = new RelayCommand(OpenBdatViaFileBrowser);
            ViewTableCommand = new RelayCommand(ViewTable);
            SaveTableCommand = new RelayCommand(SaveTable);
        }

        public void OpenBdatViaFileBrowser()
        {
            Filename = OpenViaFileBrowser(".bdat", "BDAT Files (*.bdat)|*.bdat|All Files|*.*");
            OpenBdat(Filename);
        }

        public void ViewTable()
        {
            if (!IsFileOpened) return;

            var table = BdatTables.Tables[SelectedTable];
            var editTable = new EditTable(table);
            EditingTable = new DataTable();
            CurrentTable = table;

            EditingTable.Columns.Add(new DataColumn("ID") { ReadOnly = true });
            foreach (var col in editTable.Columns)
            {
                DataColumn column = new DataColumn();
                if (col.Type != BdatMemberType.Scalar)
                {
                    column.ReadOnly = true;
                }

                column.ColumnName = $"{col.Name}\n({col.ValType})";
                EditingTable.Columns.Add(column);
            }

            foreach (var item in editTable.Items)
            {
                var row = EditingTable.NewRow();
                row.ItemArray = item;
                EditingTable.Rows.Add(item);
            }

            EditingTable.AcceptChanges();
            IsTableOpened = true;

            var temp = EditingTable;
            EditingTable = null;
            EditingTable = temp;
        }

        public void SaveTable()
        {
            if (!IsTableOpened) return;

            var rows = EditingTable.GetChanges();
            if (rows == null) return;
            var members = CurrentTable.Members;

            foreach (var row in rows.Rows.Cast<DataRow>())
            {
                var itemId = int.Parse((string)row.ItemArray[0]);
                for (int m = 0; m < members.Length; m++)
                {
                    if (members[m].Type != BdatMemberType.Scalar) continue;
                    var value = (string)row.ItemArray[m + 1];
                    try
                    {
                        CurrentTable.WriteValue(itemId, members[m].Name, value);
                    }
                    catch (Exception ex)
                    {
                        string caption = null;
                        if (ex is ArgumentOutOfRangeException)
                        {
                            caption = "Replacement string was too large to fit in the original space.";
                        }

                        if (ex is FormatException || ex is OverflowException)
                        {
                            caption = $"Error parsing \"{value}\" as a {members[m].ValType} " +
                                      $"from Item \"{itemId}\" Column \"{members[m].Name}\".";
                        }

                        if (caption == null) throw;

                        MessageBox.Show(caption, "Format Error");
                    }
                }
            }

            File.WriteAllBytes(Filename, BdatTables.FileData);

            EditingTable.AcceptChanges();
        }

        public void OpenBdat(string filename)
        {
            BdatTables = new BdatTables(filename, Game.XB2, false);
            TableNames = BdatTables.Tables.Select(x => x.Name).ToList();
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
    }
}

using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public BdatTables BdatTables { get; private set; }
        public List<string> TableNames { get; private set; }
        public int SelectedTable { get; set; }
        public DataTable EditingTable { get; set; } = new DataTable();
        public DataView EditingTableView
        {
            get { return EditingTable.DefaultView; }
        }


        public MainViewModel()
        {
            OpenBdatCommand = new RelayCommand(OpenBdatViaFileBrowser);
            ViewTableCommand = new RelayCommand(ViewTable);
        }

        public void OpenBdatViaFileBrowser()
        {
            var filename = OpenViaFileBrowser(".bdat", "BDAT Files (*.bdat)|*.bdat|All Files|*.*");
            OpenBdat(filename);
        }

        public void ViewTable()
        {
            var table = BdatTables.Tables[SelectedTable];
            var editTable = new EditTable(table);
            EditingTable = new DataTable();

            foreach (var col in editTable.Columns)
            {
                EditingTable.Columns.Add(col);
            }

            foreach (var row in editTable.Items)
            {
                EditingTable.Rows.Add(row);
            }

            var temp = EditingTable;
            EditingTable = null;
            EditingTable = temp;
        }

        public void OpenBdat(string filename)
        {
            BdatTables = new BdatTables(filename, Game.XB2, false);
            TableNames = BdatTables.Tables.Select(x => x.Name).ToList();
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

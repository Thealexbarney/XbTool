using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Xb2;
using Xb2.Save;
using Xb2.Types;
using System.IO.Compression;
using System.Linq;
using Xb2.Bdat;
using Xb2.Serialization;

namespace SaveEditor.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand ReadSaveCommand { get; set; }
        public ICommand WriteSaveCommand { get; set; }
        public ICommand LoadBdatsCommand { get; set; }

        public string SaveFilename { get; set; }
        public string Money { get; set; }
        public ItemDesc[] Acc { get; set; }

        public SDataSave SaveFile { get; set; }
        public BdatCollection Tables { get; set; }

        public MainViewModel()
        {
            ReadSaveCommand = new RelayCommand(ReadSaveDialog);
            WriteSaveCommand = new RelayCommand(WriteSave);
            LoadBdatsCommand = new RelayCommand(LoadBdats);

            if (IsInDesignModeStatic)
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SaveEditor.bf2savefile.sav.gz"))
                {
                    if (stream == null) return;
                    using (var decompressionStream = new GZipStream(stream, CompressionMode.Decompress))
                    {
                        var file = new byte[0x1176A0];
                        decompressionStream.Read(file, 0, file.Length);
                        SaveFile = new SDataSave(new DataBuffer(file, Game.XB2, 0));
                    }
                }
            }

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SaveEditor.bdats.gz"))
            {
                if (stream == null) return;
                using (var decompressionStream = new GZipStream(stream, CompressionMode.Decompress))
                {
                    var file = new byte[7394040];
                    decompressionStream.Read(file, 0, file.Length);
                    var bdats = new BdatTables(file, Game.XB2, false);
                    Tables = Deserialize.DeserializeTables(bdats);
                }
            }

            var s = new List<ItemDesc> { new ItemDesc { Id = 0, Name = "" } };
            s.AddRange(Tables.ITM_PcEquip.Select(x => new ItemDesc { Id = x.Id, Name = x._Name?.name }));
            Acc = s.ToArray();
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

        private static string OpenDirViaFileBrowser()
        {
            var openDialog = new CommonOpenFileDialog { IsFolderPicker = true };

            if (openDialog.ShowDialog() != CommonFileDialogResult.Ok) return null;

            return openDialog.FileName;
        }

        public void ReadSave(string filename)
        {
            var file = File.ReadAllBytes(filename);
            var save = new SDataSave(new DataBuffer(file, Game.XB2, 0));
            SaveFile = save;
            SaveFilename = filename;
        }

        public void ReadSaveDialog()
        {
            var filename = OpenViaFileBrowser(".sav", "SAV Files (*.sav)|*.sav|All Files|*.*");
            if (filename == null) return;
            ReadSave(filename);
        }

        public void WriteSave()
        {
            var file = Write.WriteSave(SaveFile);
            File.WriteAllBytes(SaveFilename, file);
        }

        public void LoadBdats()
        {
            var dirName = OpenDirViaFileBrowser();
            var options = new Options
            {
                BdatDir = dirName,
                Game = Game.XB2,
                Filter = "*.bdat"
            };

            BdatCollection tables = Tasks.GetBdatCollection(options);
            Tables = tables;
        }
    }

    public class ItemDesc
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

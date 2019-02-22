using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LibHac;
using LibHac.IO;

namespace XbTool.Xb2
{
    public class Xb2FileSystem : IFileSystem
    {
        private IFileSystem BaseFs { get; }

        public Xb2FileSystem(string sdPath)
        {
            SwitchFs sdFs = OpenSdCard(sdPath);
            Application xb2App = sdFs.Applications[0x0100E95004038000];

            IFileSystem mainFs = xb2App.Patch.MainNca.OpenSectionFileSystem(1, IntegrityCheckLevel.ErrorOnInvalid);
            IFile mainArh = mainFs.OpenFile("/bf2.arh", OpenMode.Read);
            IFile mainArd = mainFs.OpenFile("/bf2.ard", OpenMode.Read);

            var mainArchiveFs = new ArchiveFileSystem(mainArh, mainArd);

            var fsList = new List<IFileSystem>();
            fsList.Add(xb2App.Patch.MainNca.OpenSectionFileSystem(1, IntegrityCheckLevel.ErrorOnInvalid));
            fsList.Add(mainArchiveFs);

            foreach (Title aoc in xb2App.AddOnContent.OrderBy(x => x.Id))
            {
                IFileSystem aocFs = aoc.MainNca.OpenSectionFileSystem(0, IntegrityCheckLevel.ErrorOnInvalid);
                fsList.Add(aocFs);

                if (aoc.Id == 0x0100E95004039001)
                {
                    IFile aocArh = aocFs.OpenFile("/aoc1.arh", OpenMode.Read);
                    IFile aocArd = aocFs.OpenFile("/aoc1.ard", OpenMode.Read);

                    var aocArchiveFs = new ArchiveFileSystem(aocArh, aocArd);
                    fsList.Add(aocArchiveFs);
                }
            }

            fsList.Reverse();
            BaseFs = new LayeredFileSystem(fsList);
        }

        public IDirectory OpenDirectory(string path, OpenDirectoryMode mode)
        {
            path = PathTools.Normalize(path);

            IDirectory baseDir = BaseFs.OpenDirectory(path, mode);

            return new Xb2Directory(this, baseDir);
        }

        public IFile OpenFile(string path, OpenMode mode)
        {
            path = PathTools.Normalize(path);

            if(IsArchiveFile(path)) throw new FileNotFoundException();

            return BaseFs.OpenFile(path, mode);
        }

        public bool DirectoryExists(string path)
        {
            path = PathTools.Normalize(path);

            if (IsArchiveFile(path)) return false;

            return BaseFs.DirectoryExists(path);
        }

        public bool FileExists(string path)
        {
            path = PathTools.Normalize(path);

            if (IsArchiveFile(path)) return false;

            return BaseFs.FileExists(path);
        }

        public DirectoryEntryType GetEntryType(string path)
        {
            path = PathTools.Normalize(path);

            if (IsArchiveFile(path)) throw new FileNotFoundException();

            return BaseFs.GetEntryType(path);
        }

        internal static bool IsArchiveFile(string path)
        {
            string extension = Path.GetExtension(path);

            return extension == ".ard" || extension == ".arh";
        }

        private static SwitchFs OpenSdCard(string path, IProgressReport logger = null)
        {
            SwitchFs switchFs;
            Keyset keyset = OpenKeyset();

            var baseFs = new LocalFileSystem(path);

            if (Directory.Exists(Path.Combine(path, "Nintendo", "Contents", "registered")))
            {
                logger?.LogMessage("Treating path as SD card storage");
                switchFs = SwitchFs.OpenSdCard(keyset, baseFs);
            }
            else if (Directory.Exists(Path.Combine(path, "Contents", "registered")))
            {
                logger?.LogMessage("Treating path as NAND storage");
                switchFs = SwitchFs.OpenNandPartition(keyset, baseFs);
            }
            else
            {
                logger?.LogMessage("Treating path as a directory of loose NCAs");
                switchFs = SwitchFs.OpenNcaDirectory(keyset, baseFs);
            }

            return switchFs;
        }

        private static Keyset OpenKeyset()
        {
            string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string homeKeyFile = Path.Combine(home, ".switch", "prod.keys");
            string homeTitleKeyFile = Path.Combine(home, ".switch", "title.keys");
            string homeConsoleKeyFile = Path.Combine(home, ".switch", "console.keys");

            return ExternalKeys.ReadKeyFile(homeKeyFile, homeTitleKeyFile, homeConsoleKeyFile);
        }

        public void Commit(){}

        public void CreateDirectory(string path) => throw new NotSupportedException();
        public void CreateFile(string path, long size, CreateFileOptions options) => throw new NotSupportedException();
        public void DeleteDirectory(string path) => throw new NotSupportedException();
        public void DeleteFile(string path) => throw new NotSupportedException();
        public void RenameDirectory(string srcPath, string dstPath) => throw new NotSupportedException();
        public void RenameFile(string srcPath, string dstPath) => throw new NotSupportedException();
    }
}

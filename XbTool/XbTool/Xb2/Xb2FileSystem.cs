using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LibHac;
using LibHac.Common;
using LibHac.Fs;
using LibHac.FsService;
using LibHac.FsSystem;

namespace XbTool.Xb2
{
    public class Xb2FileSystem : IFileSystem
    {
        private IFileSystem BaseFs { get; }

        public Xb2FileSystem(string sdPath)
        {
            SwitchFs sdFs = OpenSdCard(sdPath);
            Application xb2App = sdFs.Applications[0x0100E95004038000];

            IFileSystem mainFs = xb2App.Patch.MainNca.OpenFileSystem(1, IntegrityCheckLevel.ErrorOnInvalid);
            mainFs.OpenFile(out IFile mainArh, "/bf2.arh".ToU8Span(), OpenMode.Read);
            mainFs.OpenFile(out IFile mainArd, "/bf2.ard".ToU8Span(), OpenMode.Read);

            var mainArchiveFs = new ArchiveFileSystem(mainArh, mainArd);

            var fsList = new List<IFileSystem>();
            fsList.Add(xb2App.Patch.MainNca.OpenFileSystem(1, IntegrityCheckLevel.ErrorOnInvalid));
            fsList.Add(mainArchiveFs);

            foreach (Title aoc in xb2App.AddOnContent.OrderBy(x => x.Id))
            {
                IFileSystem aocFs = aoc.MainNca.OpenFileSystem(0, IntegrityCheckLevel.ErrorOnInvalid);
                fsList.Add(aocFs);

                if (aoc.Id == 0x0100E95004039001)
                {
                    aocFs.OpenFile(out IFile aocArh, "/aoc1.arh".ToU8Span(), OpenMode.Read);
                    aocFs.OpenFile(out IFile aocArd, "/aoc1.ard".ToU8Span(), OpenMode.Read);

                    var aocArchiveFs = new ArchiveFileSystem(aocArh, aocArd);
                    fsList.Add(aocArchiveFs);
                }
            }

            fsList.Reverse();
            BaseFs = new LayeredFileSystem(fsList);
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

            return ExternalKeyReader.ReadKeyFile(homeKeyFile, homeTitleKeyFile, homeConsoleKeyFile);
        }

        public Result CreateFile(U8Span path, long size, CreateFileOptions options) => throw new NotSupportedException();
        public Result DeleteFile(U8Span path) => throw new NotSupportedException();
        public Result CreateDirectory(U8Span path) => throw new NotSupportedException();
        public Result DeleteDirectory(U8Span path) => throw new NotSupportedException();
        public Result DeleteDirectoryRecursively(U8Span path) => throw new NotSupportedException();
        public Result CleanDirectoryRecursively(U8Span path) => throw new NotSupportedException();
        public Result RenameFile(U8Span oldPath, U8Span newPath) => throw new NotSupportedException();
        public Result RenameDirectory(U8Span oldPath, U8Span newPath) => throw new NotSupportedException();

        public Result GetEntryType(out DirectoryEntryType entryType, U8Span path)
        {
            PathTools.Normalize(out path, path);

            if (IsArchiveFile(path.ToString())) throw new FileNotFoundException();

            return BaseFs.GetEntryType(out entryType, path);
        }

        public Result GetFreeSpaceSize(out long freeSpace, U8Span path) => throw new NotSupportedException();
        public Result GetTotalSpaceSize(out long totalSpace, U8Span path) => BaseFs.GetTotalSpaceSize(out totalSpace, path);

        public Result OpenFile(out IFile file, U8Span path, OpenMode mode)
        {
            PathTools.Normalize(out path, path);

            if (IsArchiveFile(path.ToString())) throw new FileNotFoundException();

            return BaseFs.OpenFile(out file, path, mode);
        }

        public Result OpenDirectory(out IDirectory directory, U8Span path, OpenDirectoryMode mode)
        {
            PathTools.Normalize(out path, path);

            Result res = BaseFs.OpenDirectory(out IDirectory baseDir, path, mode);

            directory = new Xb2Directory(this, baseDir);

            return res;
        }

        Result IFileSystem.Commit() => Result.Success;
        public Result CommitProvisionally(long commitCount) => Result.Success;

        public Result Rollback() => Result.Success;

        public Result Flush() => Result.Success;

        public Result GetFileTimeStampRaw(out FileTimeStampRaw timeStamp, U8Span path) => BaseFs.GetFileTimeStampRaw(out timeStamp, path);

        public Result QueryEntry(Span<byte> outBuffer, ReadOnlySpan<byte> inBuffer, QueryId queryId, U8Span path)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

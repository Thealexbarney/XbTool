using System.Collections.Generic;
using LibHac.IO;
using LibHac.IO.RomFs;

namespace XbTool.Xb2
{
    public class ArchiveDirectory : IDirectory
    {
        IFileSystem IDirectory.ParentFileSystem => ParentFileSystem;
        public ArchiveFileSystem ParentFileSystem { get; }
        public string FullPath { get; }
        public OpenDirectoryMode Mode { get; }

        private FindPosition InitialPosition { get; }

        public ArchiveDirectory(ArchiveFileSystem fs, string path, FindPosition position, OpenDirectoryMode mode)
        {
            ParentFileSystem = fs;
            InitialPosition = position;
            FullPath = path;
            Mode = mode;
        }

        public IEnumerable<DirectoryEntry> Read()
        {
            FindPosition position = InitialPosition;
            HierarchicalRomFileTable tab = ParentFileSystem.FileTable;

            if (Mode.HasFlag(OpenDirectoryMode.Directories))
            {
                while (tab.FindNextDirectory(ref position, out string name))
                {
                    yield return new DirectoryEntry(name, FullPath + '/' + name, DirectoryEntryType.Directory, 0);
                }
            }

            if (Mode.HasFlag(OpenDirectoryMode.Files))
            {
                while (tab.FindNextFile(ref position, out RomFileInfo info, out string name))
                {
                    yield return new DirectoryEntry(name, FullPath + '/' + name, DirectoryEntryType.File, info.Length);
                }
            }
        }

        public int GetEntryCount()
        {
            int count = 0;

            FindPosition position = InitialPosition;
            HierarchicalRomFileTable tab = ParentFileSystem.FileTable;

            if (Mode.HasFlag(OpenDirectoryMode.Directories))
            {
                while (tab.FindNextDirectory(ref position, out string _))
                {
                    count++;
                }
            }

            if (Mode.HasFlag(OpenDirectoryMode.Files))
            {
                while (tab.FindNextFile(ref position, out RomFileInfo _, out string _))
                {
                    count++;
                }
            }

            return count;
        }
    }
}

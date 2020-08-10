using LibHac;
using LibHac.Common;
using LibHac.Fs;
using LibHac.FsSystem.RomFs;
using System;
using System.Collections.Generic;
using System.Text;

namespace XbTool.Xb2
{
    public class ArchiveDirectory : IDirectory
    {
        public ArchiveFileSystem ParentFileSystem { get; }
        public string FullPath { get; }
        public OpenDirectoryMode Mode { get; }

        private FindPosition InitialPosition { get; }
        private FindPosition _curPosition;

        public ArchiveDirectory(ArchiveFileSystem fs, string path, FindPosition position, OpenDirectoryMode mode)
        {
            ParentFileSystem = fs;
            InitialPosition = position;
            _curPosition = position;
            FullPath = path;
            Mode = mode;
        }

        public Result Read(out long entriesRead, Span<DirectoryEntry> entryBuffer)
        {
            int i = 0;
            ref FindPosition position = ref _curPosition;
            HierarchicalRomFileTable<RomFileInfo> table = ParentFileSystem.FileTable;

            if (Mode.HasFlag(OpenDirectoryMode.Directory))
            {
                while (table.FindNextDirectory(ref position, out string name))
                {
                    if (i >= entryBuffer.Length)
                        break;
                    entryBuffer[i].Type = DirectoryEntryType.Directory;
                    entryBuffer[i].Size = 0;
                    StringUtils.Copy(entryBuffer[i].Name, Encoding.UTF8.GetBytes(name));
                    i++;
                }
            }
            if (Mode.HasFlag(OpenDirectoryMode.File))
            {
                while (table.FindNextFile(ref position, out RomFileInfo info, out string name))
                {
                    if (i >= entryBuffer.Length)
                        break;
                    entryBuffer[i].Type = DirectoryEntryType.File;
                    entryBuffer[i].Size = info.Length;
                    StringUtils.Copy(entryBuffer[i].Name, Encoding.UTF8.GetBytes(name));
                    i++;
                }
            }

            entriesRead = i;
            return Result.Success;
        }

        public Result GetEntryCount(out long entryCount)
        {
            entryCount = 0;
            FindPosition position = InitialPosition;
            HierarchicalRomFileTable<RomFileInfo> table = ParentFileSystem.FileTable;

            if (Mode.HasFlag(OpenDirectoryMode.Directory))
            {
                while (table.FindNextDirectory(ref position, out string _))
                {
                    entryCount++;
                }
            }

            if (Mode.HasFlag(OpenDirectoryMode.File))
            {
                while (table.FindNextFile(ref position, out RomFileInfo _, out string _))
                {
                    entryCount++;
                }
            }

            return Result.Success;
        }
    }
}

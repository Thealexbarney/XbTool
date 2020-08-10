using LibHac;
using LibHac.Fs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XbTool.Xb2
{
    public class Xb2Directory : IDirectory
    {
        private IDirectory BaseDirectory { get; }
        public IFileSystem ParentFileSystem { get; }

        public Xb2Directory(IFileSystem fs, IDirectory baseDirectory)
        {
            BaseDirectory = baseDirectory;
            ParentFileSystem = fs;
        }

        public Result Read(out long entriesRead, Span<DirectoryEntry> entryBuffer) => BaseDirectory.Read(out entriesRead, entryBuffer);

        public Result GetEntryCount(out long entryCount) => BaseDirectory.GetEntryCount(out entryCount);
    }
}

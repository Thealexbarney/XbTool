using System.Collections.Generic;
using System.Linq;
using LibHac.IO;

namespace XbTool.Xb2
{
    public class Xb2Directory : IDirectory
    {
        private IDirectory BaseDirectory { get; }

        public IFileSystem ParentFileSystem { get; }
        public string FullPath { get; }
        public OpenDirectoryMode Mode { get; }

        public Xb2Directory(IFileSystem fs, IDirectory baseDirectory)
        {
            BaseDirectory = baseDirectory;
            ParentFileSystem = fs;
            FullPath = baseDirectory.FullPath;
            Mode = baseDirectory.Mode;
        }

        public IEnumerable<DirectoryEntry> Read()
        {
            return BaseDirectory.Read().Where(x => !Xb2FileSystem.IsArchiveFile(x.Name));
        }

        public int GetEntryCount()
        {
            return Read().Count();
        }
    }
}

using LibHac.Common;
using LibHac.Fs;
using LibHac.FsService.Creators;
using LibHac.FsSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace XbTool.Common
{
    public static class Helpers
    {
        public static T CreateJaggedArray<T>(params int[] lengths)
        {
            return (T)InitializeJaggedArray(typeof(T).GetElementType(), 0, lengths);
        }

        private static object InitializeJaggedArray(Type type, int index, int[] lengths)
        {
            Array array = Array.CreateInstance(type, lengths[index]);

            Type elementType = type.GetElementType();
            if (elementType == null) return array;

            for (int i = 0; i < lengths[index]; i++)
            {
                array.SetValue(InitializeJaggedArray(elementType, index + 1, lengths), i);
            }
            return array;
        }

        public static string GetRelativePath(string path, string basePath)
        {
            var directory = new DirectoryInfo(basePath);
            var file = new FileInfo(path);

            string fullDirectory = directory.FullName;
            string fullFile = file.FullName;

            if (!fullFile.StartsWith(fullDirectory))
            {
                throw new ArgumentException($"{nameof(path)} is not a subpath of {nameof(basePath)}");
            }

            return fullFile.Substring(fullDirectory.Length + 1);
        }

        public static FileStream TryOpenDataFile(string filename)
        {
            string path = null;
            if (File.Exists(filename))
            {
                path = filename;
            }
            else
            {
                string localPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", filename);
                if (File.Exists(localPath)) path = localPath;
            }

            if (path == null) return null;
            return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        public static FileStream OpenDataFile(string filename)
        {
            return TryOpenDataFile(filename) ?? throw new FileNotFoundException($"Could not find data file {filename}", filename);
        }

        public static int GetNextMultiple(int value, int multiple)
        {
            if (multiple <= 0)
                return value;

            if (value % multiple == 0)
                return value;

            return value + multiple - value % multiple;
        }

        public static byte[] ReadFile(this IFileSystem fs, string path)
        {
            fs.OpenFile(out IFile file, path.ToU8Span(), OpenMode.Read);
            file.GetSize(out long size);
            var fileArr = new byte[size];
            file.Read(out _, 0, fileArr.AsSpan());

            return fileArr;
        }

        public static IDirectory OpenDirectory(this IFileSystem fs, string path, OpenDirectoryMode mode)
        {
            fs.OpenDirectory(out IDirectory outDir, path.ToU8Span(), mode);
            return outDir;
        }

        public static IEnumerable<DirectoryEntry> Read(this IDirectory directory)
        {
            directory.GetEntryCount(out long entryCount);
            DirectoryEntry[] dirEntries = new DirectoryEntry[entryCount];
            directory.Read(out long _, dirEntries.AsSpan());
            return dirEntries;
        }
    }
}

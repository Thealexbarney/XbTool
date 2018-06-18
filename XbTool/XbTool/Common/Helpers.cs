using System;
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
            if (File.Exists(filename)) path = filename;

            var localPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", filename);
            if (File.Exists(localPath)) path = localPath;

            if (path == null) return null;
            return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        public static FileStream OpenDataFile(string filename)
        {
            return TryOpenDataFile(filename) ?? throw new FileNotFoundException($"Could not find data file {filename}", filename);
        }
    }
}

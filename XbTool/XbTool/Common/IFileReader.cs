using System.Collections.Generic;

namespace XbTool.Common
{
    public interface IFileReader
    {
        byte[] ReadFile(string filename);
        IEnumerable<string> FindFiles(string pattern);
        bool Exists(string filename);
    }
}

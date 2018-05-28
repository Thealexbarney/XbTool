using System.Collections.Generic;

namespace Xb2
{
    public interface IFileReader
    {
        byte[] ReadFile(string filename);
        IEnumerable<string> FindFiles(string pattern);
        bool Exists(string filename);
    }
}

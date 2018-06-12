using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace XbTool.Serialization
{
    public static class TypeMap
    {
        private static Dictionary<string, Type> Types { get; }
        private static Dictionary<Type, Func<byte[], int, int, int, object>> Functions { get; }

        static TypeMap()
        {
            var dictionaries = CreateDictionary();
            Types = dictionaries.Item1;
            Functions = dictionaries.Item2;
        }

        public static Tuple<Dictionary<string, Type>, Dictionary<Type, Func<byte[], int, int, int, object>>> CreateDictionary()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(x => x.IsClass && x.Namespace == "XbTool.Types").ToDictionary(x => x.Name, x => x);
            var methods = typeof(ReadFunctions).GetMethods().ToDictionary(x => x.Name, x => x);

            var typeDict = new Dictionary<string, Type>();
            var funcDict = new Dictionary<Type, Func<byte[], int, int, int, object>>();

            Stream resourceStream = assembly.GetManifestResourceStream("XbTool.Serialization.TypeMap.txt");
            if (resourceStream == null) throw new InvalidOperationException("Can't open embedded resource");

            using (var reader = new StreamReader(resourceStream))
            {
                while (!reader.EndOfStream)
                {
                    string[] tables = reader.ReadLine()?.Split(',');
                    if (tables == null || tables.Length < 2) continue;

                    string typeName = tables[0];
                    Type type = types[typeName];

                    for (int i = 1; i < tables.Length; i++)
                    {
                        typeDict.Add(tables[i], type);
                    }

                    if (!funcDict.ContainsKey(type))
                    {
                        string funcName = "Read" + typeName;
                        var funcDelegate = (Func<byte[], int, int, int, object>)Delegate.CreateDelegate(
                            typeof(Func<byte[], int, int, int, object>), methods[funcName]);
                        funcDict.Add(type, funcDelegate);
                    }
                }
            }

            return new Tuple<Dictionary<string, Type>, Dictionary<Type, Func<byte[], int, int, int, object>>>(typeDict, funcDict);
        }

        public static Type GetTableType(string tableName)
        {
            return Types[tableName];
        }

        public static Func<byte[], int, int, int, object> GetTableReadFunction(Type tableType)
        {
            return Functions[tableType];
        }
    }
}

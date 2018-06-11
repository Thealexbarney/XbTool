using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using XbTool.Bdat;
using XbTool.BdatString;

namespace XbTool
{
    public static class JsonGen
    {
        public static void PrintAllTables(BdatStringCollection bdats, string htmlDir)
        {
            string bdatHtmlDir = Path.Combine(htmlDir, "json");
            Directory.CreateDirectory(bdatHtmlDir);

            foreach (string tableName in bdats.Tables.Keys)
            {
                string outDir = bdatHtmlDir;
                string tableFilename = bdats[tableName].Filename;

                string json = PrintTable(bdats[tableName]);

                if (tableFilename != null)
                {
                    outDir = Path.Combine(outDir, tableFilename);
                }

                string filename = Path.Combine(outDir, tableName + ".json");
                Directory.CreateDirectory(outDir);
                File.WriteAllText(filename, json);
            }
        }

        public static string PrintTable(BdatStringTable table)
        {
            var json = new JArray();

            foreach (BdatStringItem item in table.Items.Where(x => x != null))
            {
                var itemObj = new JObject();
                itemObj["id"] = item.Id;

                foreach (BdatMember member in table.Members)
                {
                    switch (member.Type)
                    {
                        case BdatMemberType.Scalar:
                            string value = item[member.Name].ValueString;
                            itemObj[member.Name] = JToken.FromObject(ParseValue(value, member.ValType));
                            break;
                        case BdatMemberType.Flag:
                            itemObj[member.Name] = bool.Parse(item[member.Name].ValueString);
                            break;
                        case BdatMemberType.Array:
                            var array = new JArray();
                            itemObj[member.Name] = array;

                            foreach (string val in (string[])item[member.Name].Value)
                            {
                                array.Add(ParseValue(val, member.ValType));
                            }

                            break;
                    }
                }

                json.Add(itemObj);
            }


            return json.ToString();
        }

        private static object ParseValue(string value, BdatValueType type)
        {
            switch (type)
            {
                case BdatValueType.UInt8:
                case BdatValueType.UInt16:
                case BdatValueType.UInt32:
                case BdatValueType.Int8:
                case BdatValueType.Int16:
                case BdatValueType.Int32:
                    return long.Parse(value);
                case BdatValueType.String:
                    return value;
                case BdatValueType.FP32:
                    return float.Parse(value);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

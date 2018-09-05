using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Npgsql;
using XbTool.Bdat;
using XbTool.BdatString;
using XbTool.Common;

namespace XbTool
{
    public static class DBGen
    {
        public static void PrintAllTables(BdatStringCollection bdats, string schemaName, IProgressReport progress = null)
        {
            string dbName;
            string dbUsername;
            string dbPassword;

            Console.Write("Enter Database Name: ");
            dbName = Console.ReadLine();

            Console.Write("Enter User Name: ");
            dbUsername = Console.ReadLine();

            Console.Write("Enter User Password: ");
            dbPassword = GetHiddenConsoleInput();
            Console.WriteLine();

            string connString = $"Host=localhost;Username={dbUsername};Password={dbPassword};Database={dbName};";

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();
                }
                catch (PostgresException exception)
                {
                    if (exception.SqlState == "28P01") Console.WriteLine($"Password authentication for user {dbUsername} failed.");
                    if (exception.SqlState == "3D000") Console.WriteLine($"Database {dbName} does not exist.");
                    System.Environment.Exit(1);
                }

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"CREATE SCHEMA {schemaName};";
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (PostgresException exception)
                    {
                        if (exception.SqlState == "42P06")
                        {
                            Console.WriteLine($"Schema name {schemaName} is already in use. Delete the schema and retry or provide a different schema name.");
                            System.Environment.Exit(1);
                        }
                    }
                }

                progress?.LogMessage("Writing BDAT tables to postgresql database");
                progress?.SetTotal(bdats.Tables.Count);

                foreach (string tableName in bdats.Tables.Keys)
                {

                    BdatStringTable table = bdats[tableName];

                    string createQuery = CreateTableQuery(schemaName, table);

                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = createQuery;
                        cmd.ExecuteNonQuery();
                    }

                    PrintTable(table, conn, schemaName);
                    progress?.ReportAdd(1);
                }
            }
        }

        public static string CreateTableQuery(string schemaName, BdatStringTable table)
        {
            string query = $"CREATE TABLE {schemaName}.{table.Name} (";

            List<string> columns = new List<string>();

            columns.Add("\"row_id\" INTEGER");

            foreach (BdatMember member in table.Members)
            {
                string memberType = "";
                switch (member.ValType)
                {
                    case BdatValueType.UInt8:
                    case BdatValueType.Int8:
                    case BdatValueType.Int16:
                        memberType = "SMALLINT";
                        break;
                    case BdatValueType.UInt16:
                    case BdatValueType.Int32:
                        memberType = "INTEGER";
                        break;
                    case BdatValueType.UInt32:
                        memberType = "BIGINT";
                        break;
                    case BdatValueType.String:
                        memberType = "TEXT";
                        break;
                    case BdatValueType.FP32:
                        memberType = "NUMERIC";
                        break;
                }

                switch (member.Type)
                {
                    case BdatMemberType.Flag:
                        memberType = "BOOL";
                        break;
                    case BdatMemberType.Array:
                        memberType += "[]";
                        break;
                }

                columns.Add($"\"{member.Name}\" {memberType}");
            }

            query += String.Join(",", columns);
            query += ");";

            return query;
        }

        public static void PrintTable(BdatStringTable table, NpgsqlConnection conn, string schemaName)
        {
            List<string> memberNames = (from member in table.Members select member.Name).ToList();

            memberNames.Add("row_id");

            string columns = String.Join(",", from member in memberNames select $"\"{member}\"");
            string values = String.Join(",", from member in memberNames select $"@{member}");

            string query = $"INSERT INTO {schemaName}.{table.Name} ({columns}) VALUES ({values})";

            foreach (BdatStringItem item in table.Items.Where(x => x != null))
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = query;

                var param = cmd.CreateParameter();
                param.ParameterName = "row_id";
                param.Value = item.Id;
                cmd.Parameters.Add(param);

                foreach (BdatMember member in table.Members)
                {
                    var parameter = cmd.CreateParameter();
                    parameter.ParameterName = member.Name;

                    switch (member.Type)
                    {
                        case BdatMemberType.Scalar:
                            string value = item[member.Name].ValueString;
                            parameter.Value = ParseValue(value, member.ValType);
                            break;
                        case BdatMemberType.Flag:
                            parameter.Value = bool.Parse(item[member.Name].ValueString);
                            break;
                        case BdatMemberType.Array:
                            List<object> array = new List<object>();

                            foreach (string val in (string[])item[member.Name].Value)
                            {
                                array.Add(ParseValue(val, member.ValType));
                            }

                            switch (member.ValType)
                            {
                                case BdatValueType.UInt8:
                                case BdatValueType.UInt16:
                                case BdatValueType.UInt32:
                                case BdatValueType.Int8:
                                case BdatValueType.Int16:
                                case BdatValueType.Int32:
                                    parameter.Value = array.Select(k => (long)k).ToList();
                                    break;
                                case BdatValueType.String:
                                    parameter.Value = array.Select(k => (string)k).ToList();
                                    break;
                                case BdatValueType.FP32:
                                    parameter.Value = array.Select(k => (float)k).ToList();
                                    break;
                            }
                            break;
                    }
                    cmd.Parameters.Add(parameter);
                }
                cmd.ExecuteNonQuery();
            }
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

        private static string GetHiddenConsoleInput()
        {
            StringBuilder input = new StringBuilder();
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                if (key.Key == ConsoleKey.Backspace && input.Length > 0) input.Remove(input.Length - 1, 1);
                else if (key.Key != ConsoleKey.Backspace) input.Append(key.KeyChar);
            }
            return input.ToString();
        }
    }
}

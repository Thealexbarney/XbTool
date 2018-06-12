using System;
using System.Collections.Generic;
using System.Text;

namespace XbTool
{
    public class Table
    {
        private List<string[]> Rows { get; } = new List<string[]>();
        private int ColumnCount { get; set; }

        public Table(params string[] header)
        {
            ColumnCount = header.Length;
            Rows.Add(header);
        }

        public void AddRow(params string[] row)
        {
            if (row.Length != ColumnCount)
            {
                throw new ArgumentOutOfRangeException(nameof(row), "All rows must have the same number of columns");
            }

            Rows.Add(row);
        }

        public string Print()
        {
            var sb = new StringBuilder();
            var width = new int[ColumnCount];

            foreach (var row in Rows)
            {
                for (int i = 0; i < ColumnCount - 1; i++)
                {
                    width[i] = Math.Max(width[i], row[i].Length);
                }
            }

            foreach (var row in Rows)
            {
                for (int i = 0; i < ColumnCount; i++)
                {
                    sb.Append($"{row[i].PadRight(width[i] + 1, ' ')}");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}

using System;
using System.Text;

namespace XbTool.CodeGen
{
    public class Indenter
    {
        public int LevelSize { get; set; } = 4;
        public int Level { get; private set; }
        private StringBuilder _sb = new StringBuilder();
        private string _indentation = string.Empty;

        public Indenter() { }
        public Indenter(int levelSize) => LevelSize = levelSize;

        public void SetLevel(int level)
        {
            Level = Math.Max(level, 0);
            _indentation = new string(' ', Level * LevelSize);
        }

        public void IncreaseLevel() => SetLevel(Level + 1);
        public void DecreaseLevel() => SetLevel(Level - 1);

        public Indenter AppendLine()
        {
            _sb.AppendLine();
            return this;
        }

        public Indenter AppendLine(string value)
        {
            _sb.Append(_indentation).AppendLine(value);
            return this;
        }

        public Indenter AppendLineAndIncrease(string value)
        {
            _sb.Append(_indentation).AppendLine(value);
            IncreaseLevel();
            return this;
        }

        public Indenter DecreaseAndAppendLine(string value)
        {
            DecreaseLevel();
            _sb.Append(_indentation).AppendLine(value);
            return this;
        }

        public override string ToString() => _sb.ToString();
    }
}

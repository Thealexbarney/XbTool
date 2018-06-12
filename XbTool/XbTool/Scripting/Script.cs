using System.Collections.Generic;

namespace XbTool.Scripting
{
    public class Script
    {
        public byte Version;
        public byte Field5;
        public byte Flags;
        public byte IsLoaded;
        public int CodeOffset;
        public int IdPoolOffset;
        public int IntPoolOffset;
        public int FixedPoolOffset;
        public int StringPoolOffset;
        public int FunctionPoolOffset;
        public int PluginsOffset;
        public int OcImportsOffset;
        public int FuncImportsOffset;
        public int StaticVarsOffset;
        public int LocalPoolOffset;
        public int SysAtrPoolOffset;
        public int UsrAtrPoolOffset;
        public int SymbolSectionOffset;

        public List<Section> Sections = new List<Section>();
        public Instruction[][] Code;
        public string[] IdPool;
        public string[] IdPoolRefs;
        public int[] IntPool;
        public float[] FixedPool;
        public string[] StringPool;
        public LocalFunction[] FunctionPool;
        public PluginFunction[] Plugins;
        public string[] OcImports;
        public PluginFunction[] ImportFuncs;
        public VmObject[] StaticVars;
        public VmObject[][] LocalPool;
        public string[] SysAtrPool;
        public string[] UsrAtrPool;
        public Symbol[] StaticSymbols;
        public Symbol[][] LocalSymbols;
        public Symbol[][] ArgsSymbols;
        public string[] FilenameSymbols;
        public SymbolLine[] LineSymbols;

        public readonly bool Is64Bit;

        public Script(DataBuffer data)
        {
            ScriptTools.DescrambleScript(data);

            Version = data.ReadUInt8(4, true);
            Field5 = data.ReadUInt8();
            Flags = data.ReadUInt8();
            Is64Bit = (Flags & 4) != 0;
            IsLoaded = data.ReadUInt8();
            CodeOffset = data.ReadInt32();
            IdPoolOffset = data.ReadInt32();
            IntPoolOffset = data.ReadInt32();
            FixedPoolOffset = data.ReadInt32();
            StringPoolOffset = data.ReadInt32();
            FunctionPoolOffset = data.ReadInt32();
            PluginsOffset = data.ReadInt32();
            OcImportsOffset = data.ReadInt32();
            FuncImportsOffset = data.ReadInt32();
            StaticVarsOffset = data.ReadInt32();
            LocalPoolOffset = data.ReadInt32();
            SysAtrPoolOffset = data.ReadInt32();
            UsrAtrPoolOffset = data.ReadInt32();
            SymbolSectionOffset = data.ReadInt32();

            ReadIdPool(data);
            ReadIntPool(data);
            ReadFixedPool(data);
            ReadStringPool(data);
            ReadFunctionPool(data);
            ReadPluginImports(data);
            ReadOcImports(data);
            ReadFuncImports(data);
            ReadStaticVars(data);
            ReadLocalPool(data);
            ReadSysAtrPool(data);
            ReadUsrAtrPool(data);
            ReadSymbolSection(data);
            ReadCodeSection(data);
        }

        private string GetId(int id, string user)
        {
            IdPoolRefs[id] += $"; {user}";
            return IdPool[id];
        }

        private void ReadCodeSection(DataBuffer data)
        {
            data.Position = CodeOffset;
            var start = CodeOffset + data.ReadInt32();
            data.Position += 4;
            var codeSize = data.ReadInt32();
            var length = IdPoolOffset - CodeOffset;

            var section = new Section("Code", CodeOffset, codeSize, length);
            Sections.Insert(0, section);

            Code = new Instruction[FunctionPool.Length][];
            var code = data.Slice(start, codeSize);
            
            for (int i = 0; i < FunctionPool.Length; i++)
            {
                var instructions = new List<Instruction>();
                code.Position = FunctionPool[i].Start;

                while (code.Position < FunctionPool[i].End)
                {
                    var inst = new Instruction(this, code, i);
                    instructions.Add(inst);
                }

                Code[i] = instructions.ToArray();
            }
        }

        private void ReadIdPool(DataBuffer data)
        {
            IdPool = ReadStringSection(data, IdPoolOffset);
            IdPoolRefs = new string[IdPool.Length];
            for (int i = 0; i < IdPoolRefs.Length; i++)
            {
                IdPoolRefs[i] = string.Empty;
            }

            var length = IntPoolOffset - IdPoolOffset;
            var section = new Section("ID Pool", IdPoolOffset, IdPool.Length, length);
            Sections.Add(section);
        }

        private void ReadIntPool(DataBuffer data)
        {
            data.Position = IntPoolOffset;
            int offset = data.ReadInt32();
            int count = data.ReadInt32();
            var length = FixedPoolOffset - IntPoolOffset;
            data.Position = IntPoolOffset + offset;

            IntPool = new int[count];
            var section = new Section("Int Pool", IntPoolOffset, count, length);
            Sections.Add(section);

            for (int i = 0; i < count; i++)
            {
                IntPool[i] = data.ReadInt32();
            }
        }

        private void ReadFixedPool(DataBuffer data)
        {
            data.Position = FixedPoolOffset;
            int offset = data.ReadInt32();
            int count = data.ReadInt32();
            var length = StringPoolOffset - FixedPoolOffset;
            data.Position = FixedPoolOffset + offset;

            FixedPool = new float[count];
            var section = new Section("Fixed Pool", FixedPoolOffset, count, length);
            Sections.Add(section);

            for (int i = 0; i < count; i++)
            {
                FixedPool[i] = data.ReadSingle();
            }
        }

        private void ReadStringPool(DataBuffer data)
        {
            StringPool = ReadStringSection(data, StringPoolOffset);
            var length = FunctionPoolOffset - StringPoolOffset;
            var section = new Section("String Pool", StringPoolOffset, StringPool.Length, length);
            Sections.Add(section);
        }

        private void ReadFunctionPool(DataBuffer data)
        {
            data.Position = FunctionPoolOffset;
            int offset = data.ReadInt32();
            int count = data.ReadInt32();
            var length = PluginsOffset - FunctionPoolOffset;
            data.Position = FunctionPoolOffset + offset;

            var section = new Section("Function Pool", FunctionPoolOffset, count, length);
            Sections.Add(section);

            FunctionPool = new LocalFunction[count];
            {
                for (int i = 0; i < FunctionPool.Length; i++)
                {
                    FunctionPool[i] = new LocalFunction(data);
                    FunctionPool[i].Name = GetId(FunctionPool[i].NameIndex, $"Function #{i}");
                }
            }
        }

        private void ReadPluginImports(DataBuffer data)
        {
            data.Position = PluginsOffset;
            int offset = data.ReadInt32();
            int count = data.ReadInt32();
            var length = OcImportsOffset - PluginsOffset;
            data.Position = PluginsOffset + offset;

            var section = new Section("Plugin Imports", PluginsOffset, count, length);
            Sections.Add(section);

            Plugins = new PluginFunction[count];
            for (int i = 0; i < Plugins.Length; i++)
            {
                Plugins[i] = new PluginFunction();
                var pluginId = data.ReadUInt16();
                var functionId = data.ReadUInt16();
                Plugins[i].Plugin = GetId(pluginId, $"Plugin Name #{i}");
                Plugins[i].Function = GetId(functionId, $"Plugin Function Name #{i}");
            }
        }

        private void ReadOcImports(DataBuffer data)
        {
            data.Position = OcImportsOffset;
            var indexes = ReadIntTable(data, OcImportsOffset);
            var length = FuncImportsOffset - OcImportsOffset;

            var section = new Section("OC Imports", OcImportsOffset, indexes.Length, length);
            Sections.Add(section);

            OcImports = new string[indexes.Length];
            for (int i = 0; i < indexes.Length; i++)
            {
                OcImports[i] = GetId(indexes[i], $"OC Name #{i}");
            }
        }

        private void ReadFuncImports(DataBuffer data)
        {
            data.Position = FuncImportsOffset;
            int offset = data.ReadInt32();
            int count = data.ReadInt32();
            int length = StaticVarsOffset - FuncImportsOffset;
            data.Position = FuncImportsOffset + offset;

            Sections.Add(new Section("Function Imports", FuncImportsOffset, count, length));

            ImportFuncs = new PluginFunction[count];
            for (int i = 0; i < ImportFuncs.Length; i++)
            {
                ImportFuncs[i] = new PluginFunction();
                var pluginId = data.ReadUInt16();
                var functionId = data.ReadUInt16();
                ImportFuncs[i].Plugin = GetId(pluginId, $"Import Script Name #{i}");
                ImportFuncs[i].Function = GetId(functionId, $"Import Function Name #{i}");
            }
        }

        private void ReadStaticVars(DataBuffer data)
        {
            data.Position = StaticVarsOffset;
            int offset = data.ReadInt32();
            int count = data.ReadInt32();
            int length = LocalPoolOffset - StaticVarsOffset;
            data.Position = StaticVarsOffset + offset;

            Sections.Add(new Section("Static Vars", StaticVarsOffset, count, length));

            StaticVars = new VmObject[count];
            for (int i = 0; i < StaticVars.Length; i++)
            {
                StaticVars[i] = new VmObject(data, Is64Bit);
            }
        }

        private void ReadLocalPool(DataBuffer data)
        {
            data.Position = LocalPoolOffset;
            int length = SysAtrPoolOffset - LocalPoolOffset;
            var tableOffset = LocalPoolOffset + data.ReadInt32();
            var offsets = ReadIntTable(data, LocalPoolOffset);
            Sections.Add(new Section("Local Pool", LocalPoolOffset, offsets.Length, length));

            LocalPool = new VmObject[offsets.Length][];
            for (int i = 0; i < offsets.Length; i++)
            {
                data.Position = tableOffset + offsets[i];
                int offset = data.ReadInt32();
                int count = data.ReadInt32();
                data.Position += offset - 8;
                var entries = new VmObject[count];

                for (int j = 0; j < count; j++)
                {
                    entries[j] = new VmObject(data, Is64Bit);
                }

                LocalPool[i] = entries;
            }
        }

        private void ReadSysAtrPool(DataBuffer data)
        {
            data.Position = SysAtrPoolOffset;
            int length = UsrAtrPoolOffset - SysAtrPoolOffset;
            var values = ReadIntTable(data, SysAtrPoolOffset);

            Sections.Add(new Section("Sys Atr Pool", SysAtrPoolOffset, values.Length, length));

            SysAtrPool = new string[values.Length];
            for (int j = 0; j < values.Length; j++)
            {
                SysAtrPool[j] = values[j] == ushort.MaxValue ? "" : GetId(values[j], $"System Attribute #{j}");
            }
        }

        private void ReadUsrAtrPool(DataBuffer data)
        {
            data.Position = UsrAtrPoolOffset;
            int length = (SymbolSectionOffset == 0 ? data.Length : SymbolSectionOffset) - UsrAtrPoolOffset;
            var values = ReadIntTable(data, UsrAtrPoolOffset);

            Sections.Add(new Section("User Atr Pool", UsrAtrPoolOffset, values.Length, length));

            UsrAtrPool = new string[values.Length];
            for (int j = 0; j < values.Length; j++)
            {
                UsrAtrPool[j] = values[j] == ushort.MaxValue ? "" : GetId(values[j], $"User Attribute #{j}");
            }
        }

        private void ReadSymbolSection(DataBuffer data)
        {
            if (SymbolSectionOffset == 0) return;
            data.Position = SymbolSectionOffset;
            int length = data.Length - SymbolSectionOffset;
            Sections.Add(new Section("Debug Symbols", SymbolSectionOffset, 5, length));

            int staticOffset = data.ReadInt32();
            int localOffset = data.ReadInt32();
            int argsOffset = data.ReadInt32();
            int filenamesOffset = data.ReadInt32();
            int linesOffset = data.ReadInt32();

            ReadStaticSymbols(data, SymbolSectionOffset + staticOffset);
            ReadLocalSymbols(data, SymbolSectionOffset + localOffset);
            ReadArgsSymbols(data, SymbolSectionOffset + argsOffset);
            ReadFilenameSymbols(data, SymbolSectionOffset + filenamesOffset);
            ReadLineSymbols(data, SymbolSectionOffset + linesOffset);
        }

        private void ReadStaticSymbols(DataBuffer data, int sectionOffset)
        {
            data.Position = sectionOffset;
            int offset = data.ReadInt32();
            int count = data.ReadInt32();
            data.Position = sectionOffset + offset;

            StaticSymbols = new Symbol[count];
            for (int i = 0; i < count; i++)
            {
                var sym = new Symbol(data);
                sym.Name = GetId(sym.IdIndex, $"Static Symbol #{i}");
                StaticVars[sym.Var].Name = sym.Name;

                StaticSymbols[i] = sym;
            }
        }

        private void ReadLocalSymbols(DataBuffer data, int sectionOffset)
        {
            var symbols = ReadSymbolSets(data, sectionOffset);

            for (int set = 0; set < symbols.Length; set++)
            {
                int localPoolIndex = FunctionPool[set].LocalPoolIndex;
                foreach (var sym in symbols[set])
                {
                    sym.Name = GetId(sym.IdIndex, $"Local Symbol #{localPoolIndex}.{sym.Var}");
                    LocalPool[localPoolIndex][sym.Var].Name = sym.Name;
                }
            }

            LocalSymbols = symbols;
        }

        private void ReadArgsSymbols(DataBuffer data, int sectionOffset)
        {
            var symbols = ReadSymbolSets(data, sectionOffset);

            for (int set = 0; set < symbols.Length; set++)
            {
                int localPoolIndex = FunctionPool[set].LocalPoolIndex;
                foreach (var sym in symbols[set])
                {
                    sym.Name = GetId(sym.IdIndex, $"Args Symbol #{localPoolIndex}.{sym.Var}");
                }
            }

            ArgsSymbols = symbols;
        }

        private void ReadFilenameSymbols(DataBuffer data, int sectionOffset)
        {
            data.Position = sectionOffset;
            int tableOffset = data.ReadInt32() + sectionOffset;
            int count = data.ReadInt32();
            data.Position = tableOffset;

            var symbols = new string[count];
            for (int i = 0; i < count; i++)
            {
                int offset = data.ReadUInt16() + tableOffset;
                symbols[i] = data.ReadTextZ("shift-jis", offset);
            }

            FilenameSymbols = symbols;
        }

        private void ReadLineSymbols(DataBuffer data, int sectionOffset)
        {
            data.Position = sectionOffset;
            int offset = data.ReadInt32();
            int count = data.ReadInt32();
            data.Position = sectionOffset + offset;

            LineSymbols = new SymbolLine[count];
            for (int i = 0; i < count; i++)
            {
                var sym = new SymbolLine(data);
                LineSymbols[i] = sym;
            }
        }

        private Symbol[][] ReadSymbolSets(DataBuffer data, int sectionOffset)
        {
            data.Position = sectionOffset;
            int tableOffset = data.ReadInt32() + sectionOffset;
            int count = data.ReadInt32();
            data.Position = tableOffset;

            var symbols = new Symbol[count][];

            var sets = new(int offset, int count)[count];
            for (int i = 0; i < count; i++)
            {
                sets[i] = (data.ReadUInt16(), data.ReadUInt16());
            }

            for (int i = 0; i < count; i++)
            {
                var (setOffset, setCount) = sets[i];
                data.Position = tableOffset + setOffset;
                symbols[i] = new Symbol[setCount];

                for (int j = 0; j < setCount; j++)
                {
                    symbols[i][j] = new Symbol(data);
                }
            }

            return symbols;
        }

        private static string[] ReadStringSection(DataBuffer data, int sectionOffset)
        {
            var tableOffset = sectionOffset + data.ReadInt32(sectionOffset);
            var offsets = ReadIntTable(data, sectionOffset);
            var strings = new string[offsets.Length];

            for (int i = 0; i < offsets.Length; i++)
            {
                var offset = tableOffset + offsets[i];
                strings[i] = data.ReadTextZ("shift-jis", offset);
            }

            return strings;
        }

        private static int[] ReadIntTable(DataBuffer data, int sectionOffset)
        {
            data.Position = sectionOffset;
            var offset = data.ReadInt32();
            var count = data.ReadInt32();
            var size = data.ReadInt32();

            data.Position = sectionOffset + offset;
            var values = new int[count];

            for (int i = 0; i < count; i++)
            {
                switch (size)
                {
                    case 2:
                        values[i] = data.ReadUInt16();
                        break;
                    case 4:
                        values[i] = data.ReadInt32();
                        break;
                }
            }

            return values;
        }
    }

    public class PluginFunction
    {
        public string Plugin { get; set; }
        public string Function { get; set; }
    }

    public class LocalFunction
    {
        public string Name { get; set; }
        public int NameIndex { get; set; }
        public int ArgsCount { get; set; }
        public int Field4 { get; set; }
        public int LocalVarCount { get; set; }
        public int LocalPoolIndex { get; set; }
        public int FieldA { get; set; }
        public int Start { get; set; }
        public int End { get; set; }

        public LocalFunction(DataBuffer data)
        {
            NameIndex = data.ReadUInt16();
            ArgsCount = data.ReadUInt16();
            Field4 = data.ReadUInt16();
            LocalVarCount = data.ReadUInt16();
            LocalPoolIndex = data.ReadUInt16();
            FieldA = data.ReadUInt16();
            Start = data.ReadInt32();
            End = data.ReadInt32();
        }
    }

    public class Symbol
    {
        public string Name { get; set; }
        public int IdIndex { get; set; }
        public int Field2 { get; set; }
        public int Var { get; set; }
        public int Field6 { get; set; }
        public int Field8 { get; set; }

        public Symbol(DataBuffer data)
        {
            IdIndex = data.ReadUInt16();
            Field2 = data.ReadUInt16();
            Var = data.ReadUInt16();
            Field6 = data.ReadUInt16();
            Field8 = data.ReadUInt16();
        }
    }

    public class SymbolLine
    {
        public int Field0 { get; set; }
        public int Field2 { get; set; }
        public int Address { get; set; }

        public SymbolLine(DataBuffer data)
        {
            Field0 = data.ReadUInt16();
            Field2 = data.ReadUInt16();
            Address = data.ReadInt32();
        }
    }

    public class Section
    {
        public Section(string name, int offset, int count, int length)
        {
            Name = name;
            Offset = offset;
            Count = count;
            Length = length;
        }

        public string Name { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
        public int Length { get; set; }
    }

    public enum ScTypes
    {
        Nil = 0,
        True = 1,
        False = 2,
        Int = 3,
        Fixed = 4,
        String = 5,
        Array = 6,
        Function = 7,
        Plugin = 8,
        OC = 9,
        Sys = 10
    }

    public class VmObject
    {
        public ScTypes Type { get; set; }
        public int Length { get; set; }
        public int Value { get; set; }
        public int Field8 { get; set; }
        public string Name { get; set; } = string.Empty;

        public VmObject(DataBuffer data, bool isLongObject)
        {
            Type = (ScTypes)data.ReadUInt8();
            data.Position++;
            Length = data.ReadUInt16();
            Value = data.ReadInt32();
            if (isLongObject) Field8 = data.ReadInt32();
        }
    }
}

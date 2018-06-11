using System;
using System.Diagnostics;
using System.Globalization;

namespace XbTool.Scripting
{
    [DebuggerDisplay("{" + nameof(DebugString) + ", nq}")]
    public class Instruction
    {
        private string DebugString => Opcode.ToString();
        public int Address { get; set; }
        public Opcode Opcode { get; set; }
        public string Operand { get; set; }
        public string Comment { get; set; } = string.Empty;

        public Instruction() { }

        public Instruction(Script script, DataBuffer data, int funcIndex)
        {
            ReadInstruction(script, data, funcIndex);
        }

        public int ReadOperand(DataBuffer data, int size)
        {
            var original = data.Endianness;
            data.Endianness = Endianness.Big;
            int result;
            switch (size)
            {
                case 0:
                    result = 0;
                    break;
                case 1:
                    result = data.ReadUInt8();
                    break;
                case 2:
                    result = data.ReadUInt16();
                    break;
                case 4:
                    result = data.ReadInt32();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(size));
            }

            data.Endianness = original;
            return result;
        }

        public void ReadInstruction(Script script, DataBuffer data, int funcIndex)
        {
            Address = data.Position;
            var opcode = (Opcode)data.ReadUInt8();
            Opcode = opcode;
            var opcodeInfo = Opcode.GetInfo();
            var operand = ReadOperand(data, opcodeInfo.Size);

            switch (opcode)
            {
                case Opcode.NOP:
                    break;
                case Opcode.CONST_0:
                    break;
                case Opcode.CONST_1:
                    break;
                case Opcode.CONST_2:
                    break;
                case Opcode.CONST_3:
                    break;
                case Opcode.CONST_4:
                    break;
                case Opcode.CONST_I:
                    break;
                case Opcode.CONST_I_W:
                    break;
                case Opcode.POOL_INT:
                case Opcode.POOL_INT_W:
                    Comment = script.IntPool[operand].ToString();
                    break;
                case Opcode.POOL_FIXED:
                case Opcode.POOL_FIXED_W:
                    Comment = script.FixedPool[operand].ToString(CultureInfo.InvariantCulture);
                    break;
                case Opcode.POOL_STR:
                case Opcode.POOL_STR_W:
                    Comment = script.StringPool[operand];
                    break;
                case Opcode.LD:
                case Opcode.ST:
                    Comment = script.LocalPool[script.FunctionPool[funcIndex].LocalPoolIndex][operand].Name;
                    break;
                case Opcode.LD_ARG:
                case Opcode.ST_ARG:
                    Comment = script.ArgsSymbols?[funcIndex][operand].Name ?? string.Empty;
                    break;
                case Opcode.ST_ARG_OMIT:
                    Comment = script.ArgsSymbols?[funcIndex][operand].Name ?? string.Empty;
                    break;
                case Opcode.LD_0:
                case Opcode.LD_1:
                case Opcode.LD_2:
                case Opcode.LD_3:
                    Comment = script.LocalPool[script.FunctionPool[funcIndex].LocalPoolIndex][opcode - Opcode.LD_0].Name;
                    break;
                case Opcode.ST_0:
                case Opcode.ST_1:
                case Opcode.ST_2:
                case Opcode.ST_3:
                    Comment = script.LocalPool[script.FunctionPool[funcIndex].LocalPoolIndex][opcode - Opcode.ST_0].Name;
                    break;
                case Opcode.LD_ARG_0:
                case Opcode.LD_ARG_1:
                case Opcode.LD_ARG_2:
                case Opcode.LD_ARG_3:
                    Comment = script.ArgsSymbols?[funcIndex][opcode - Opcode.LD_ARG_0].Name ?? string.Empty;
                    break;
                case Opcode.ST_ARG_0:
                case Opcode.ST_ARG_1:
                case Opcode.ST_ARG_2:
                case Opcode.ST_ARG_3:
                    Comment = script.ArgsSymbols?[funcIndex][opcode - Opcode.ST_ARG_0].Name ?? string.Empty;
                    break;
                case Opcode.LD_STATIC:
                case Opcode.LD_STATIC_W:
                    Comment = script.StaticVars[operand].Name;
                    break;
                case Opcode.ST_STATIC:
                case Opcode.ST_STATIC_W:
                    Comment = script.StaticVars[operand].Name;
                    break;
                case Opcode.LD_AR:
                case Opcode.ST_AR:
                    break;
                case Opcode.LD_NIL:
                    break;
                case Opcode.LD_TRUE:
                    break;
                case Opcode.LD_FALSE:
                    break;
                case Opcode.LD_FUNC:
                case Opcode.LD_FUNC_W:
                    break;
                case Opcode.LD_PLUGIN:
                case Opcode.LD_PLUGIN_W:
                    break;
                case Opcode.LD_FUNC_FAR:
                case Opcode.LD_FUNC_FAR_W:
                    break;
                case Opcode.MINUS:
                    break;
                case Opcode.NOT:
                    break;
                case Opcode.L_NOT:
                    break;
                case Opcode.ADD:
                    break;
                case Opcode.SUB:
                    break;
                case Opcode.MUL:
                    break;
                case Opcode.DIV:
                    break;
                case Opcode.MOD:
                    break;
                case Opcode.OR:
                    break;
                case Opcode.AND:
                    break;
                case Opcode.R_SHIFT:
                    break;
                case Opcode.L_SHIFT:
                    break;
                case Opcode.EQ:
                    break;
                case Opcode.NE:
                    break;
                case Opcode.GT:
                    break;
                case Opcode.LT:
                    break;
                case Opcode.GE:
                    break;
                case Opcode.LE:
                    break;
                case Opcode.L_OR:
                    break;
                case Opcode.L_AND:
                    break;
                case Opcode.JMP:
                case Opcode.JPF:
                    operand = (short)operand;
                    Comment = (Address + operand).ToString("x");
                    Operand = ((ushort)operand).ToString("x");
                    break;
                case Opcode.CALL:
                case Opcode.CALL_W:
                    Comment = script.FunctionPool[operand].Name;
                    break;
                case Opcode.CALL_IND:
                    break;
                case Opcode.RET:
                    break;
                case Opcode.NEXT:
                    break;
                case Opcode.PLUGIN:
                case Opcode.PLUGIN_W:
                    var plugin = script.Plugins[operand];
                    Comment = $"{plugin.Plugin}::{plugin.Function}";
                    break;
                case Opcode.CALL_FAR:
                    break;
                case Opcode.CALL_FAR_W:
                    break;
                case Opcode.GET_OC:
                case Opcode.GET_OC_W:
                    Comment = script.OcImports[operand];
                    break;
                case Opcode.GETTER:
                    break;
                case Opcode.GETTER_W:
                    break;
                case Opcode.SETTER:
                    break;
                case Opcode.SETTER_W:
                    break;
                case Opcode.SEND:
                case Opcode.SEND_W:
                    Comment = script.IdPool[operand];
                    break;
                case Opcode.TYPEOF:
                    break;
                case Opcode.SIZEOF:
                    break;
                case Opcode.SWITCH:
                    var values = new int[operand];
                    var addresses = new int[operand];
                    if (operand > 0) data.Position += 4;
                    for (int i = 0; i < operand; i++)
                    {
                        values[i] = ReadOperand(data, 4);
                        addresses[i] = ReadOperand(data, 4);
                        Comment += $"case {values[i]}: {addresses[i] + Address:x}\n";
                    }

                    break;
                case Opcode.INC:
                    break;
                case Opcode.DEC:
                    break;
                case Opcode.EXIT:
                    break;
                case Opcode.BP:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(opcode), opcode, null);
            }

            if (Operand == null) Operand = opcodeInfo.Size > 0 ? operand.ToString() : string.Empty;
        }
    }
}

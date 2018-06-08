using System;
using System.Diagnostics;

namespace Xb2.Scripting
{
    [DebuggerDisplay("{" + nameof(DebugString) + ", nq}")]
    public class Instruction
    {
        private string DebugString => Opcode.ToString();
        public Opcode Opcode { get; set; }

        public Instruction(DataBuffer data)
        {
            Opcode = (Opcode)data.ReadUInt8();
            data.Position += Opcode.GetInfo().Size;
        }

        public void ReadInstruction(DataBuffer data, Opcode opcode)
        {
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
                    break;
                case Opcode.POOL_INT_W:
                    break;
                case Opcode.POOL_FIXED:
                    break;
                case Opcode.POOL_FIXED_W:
                    break;
                case Opcode.POOL_STR:
                    break;
                case Opcode.POOL_STR_W:
                    break;
                case Opcode.LD:
                    break;
                case Opcode.ST:
                    break;
                case Opcode.LD_ARG:
                    break;
                case Opcode.ST_ARG:
                    break;
                case Opcode.ST_ARG_OMIT:
                    break;
                case Opcode.LD_0:
                    break;
                case Opcode.LD_1:
                    break;
                case Opcode.LD_2:
                    break;
                case Opcode.LD_3:
                    break;
                case Opcode.ST_0:
                    break;
                case Opcode.ST_1:
                    break;
                case Opcode.ST_2:
                    break;
                case Opcode.ST_3:
                    break;
                case Opcode.LD_ARG_0:
                    break;
                case Opcode.LD_ARG_1:
                    break;
                case Opcode.LD_ARG_2:
                    break;
                case Opcode.LD_ARG_3:
                    break;
                case Opcode.ST_ARG_0:
                    break;
                case Opcode.ST_ARG_1:
                    break;
                case Opcode.ST_ARG_2:
                    break;
                case Opcode.ST_ARG_3:
                    break;
                case Opcode.LD_STATIC:
                    break;
                case Opcode.LD_STATIC_W:
                    break;
                case Opcode.ST_STATIC:
                    break;
                case Opcode.ST_STATIC_W:
                    break;
                case Opcode.LD_AR:
                    break;
                case Opcode.ST_AR:
                    break;
                case Opcode.LD_NIL:
                    break;
                case Opcode.LD_TRUE:
                    break;
                case Opcode.LD_FALSE:
                    break;
                case Opcode.LD_FUNC:
                    break;
                case Opcode.LD_FUNC_W:
                    break;
                case Opcode.LD_PLUGIN:
                    break;
                case Opcode.LD_PLUGIN_W:
                    break;
                case Opcode.LD_FUNC_FAR:
                    break;
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
                    break;
                case Opcode.JPF:
                    break;
                case Opcode.CALL:
                    break;
                case Opcode.CALL_W:
                    break;
                case Opcode.CALL_IND:
                    break;
                case Opcode.RET:
                    break;
                case Opcode.NEXT:
                    break;
                case Opcode.PLUGIN:
                    break;
                case Opcode.PLUGIN_W:
                    break;
                case Opcode.CALL_FAR:
                    break;
                case Opcode.CALL_FAR_W:
                    break;
                case Opcode.GET_OC:
                    break;
                case Opcode.GET_OC_W:
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
                    break;
                case Opcode.SEND_W:
                    break;
                case Opcode.TYPEOF:
                    break;
                case Opcode.SIZEOF:
                    break;
                case Opcode.SWITCH:
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
        }
    }
}

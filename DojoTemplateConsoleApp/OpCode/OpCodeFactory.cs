using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.OpCode
{
    public interface ICreateOpCode
    {
        OpCode CreateOpCode(int index);
    }
    public class OpCodeFactory: ICreateOpCode
    {
        public OpCodeFactory(IOperateOpCode opCodeOps)
        {
            _opCodeOperations = opCodeOps;
        }

        private readonly IOperateOpCode _opCodeOperations;

        public OpCode CreateOpCode(int index)
        {
            var opCode = (_opCodeOperations.OpCodes[index] == 1 || _opCodeOperations.OpCodes[index] == 2)
            ? new OpCode()
            {
                Instruction = _opCodeOperations.OpCodes[index],
                FirstParameter = _opCodeOperations.OpCodes[index + 1],
                SecondParameter = _opCodeOperations.OpCodes[index + 2],
                OutputIndex = _opCodeOperations.OpCodes[index + 3]
            }
            : (_opCodeOperations.OpCodes[index] == 3 || _opCodeOperations.OpCodes[index] == 4)
            ? new OpCode()
            {
                Instruction = _opCodeOperations.OpCodes[index],
                FirstParameter = _opCodeOperations.OpCodes[index + 1],
            }
            : null;

            return opCode;
        }

    }
}

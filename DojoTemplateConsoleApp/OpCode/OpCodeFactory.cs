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
            var instructionCode = _opCodeOperations.OpCodes[index];
            var instruction = instructionCode % 100;
            var firstParamMode = instructionCode > 1000
                ? (instructionCode - instruction) % 1000
                : instructionCode / 100 > 0
                    ? (instructionCode - instruction) / 100
                    : 0;
            var secondParamMode = instructionCode > 10000
                ? (instructionCode - firstParamMode - instruction) % 10000
                : instructionCode / 1000 > 0
                    ? (instructionCode - instruction- firstParamMode) / 1000
                    : 0;
            var thirdParamMode = ((instructionCode - firstParamMode - secondParamMode - instruction) > 100000)
                ? (instructionCode - firstParamMode - secondParamMode - instruction) % 100000
                : 0;

            var opCode = (instruction == 1 || instruction == 2)
            ? new OpCode()
            {
                Instruction = instruction,
                FirstParameter = (_opCodeOperations.OpCodes[index + 1], firstParamMode),
                SecondParameter = (_opCodeOperations.OpCodes[index + 2], secondParamMode),
                OutputIndex = (_opCodeOperations.OpCodes[index + 3], thirdParamMode)
            }
            : (instruction == 3 || instruction == 4)
            ? new OpCode()
            {
                Instruction = instruction,
                FirstParameter = (_opCodeOperations.OpCodes[index + 1], firstParamMode)
            }
            : null;

            return opCode;
        }
    }
}

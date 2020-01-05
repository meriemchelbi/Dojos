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
            var instructionCodeString = _opCodeOperations.OpCodes[index].ToString();

            var instruction = int.Parse(instructionCodeString[^1].ToString());
            var firstParamMode = instructionCodeString.Length >= 3 && instructionCodeString[^3].Equals('1')
                ? 1
                : 0;
            var secondParamMode = instructionCodeString.Length >= 4 && instructionCodeString[^4].Equals('1')
                ? 1
                : 0;
            var thirdParamMode = instructionCodeString.Length == 5
                ? 1
                : 0;

            var opCode = (instruction == 1 || instruction == 2 || instruction == 7 || instruction == 8)
            ? new OpCode()
            {
                Instruction = instruction,
                FirstParameter = (_opCodeOperations.OpCodes[index + 1], firstParamMode),
                SecondParameter = (_opCodeOperations.OpCodes[index + 2], secondParamMode),
                OutputIndex = (_opCodeOperations.OpCodes[index + 3], thirdParamMode)
            }
            : (instruction == 5 || instruction == 6)
            ? new OpCode()
            {
                Instruction = instruction,
                FirstParameter = (_opCodeOperations.OpCodes[index + 1], firstParamMode),
                SecondParameter = (_opCodeOperations.OpCodes[index + 2], secondParamMode)
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

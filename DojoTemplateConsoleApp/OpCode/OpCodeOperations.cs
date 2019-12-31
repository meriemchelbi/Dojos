using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.OpCode
{
    public class OpCodeOperations
    {
        public OpCodeOperations(InputCapturer inputCapturer)
        {
            _inputCapturer = inputCapturer;
        }

        public int[] Input { get; set; }
        public int[] OpCodes
        {
            get
            {
                if (_opCodes == null)
                {
                    _opCodes = new int[Input.Length];
                    Array.Copy(Input, 0, _opCodes, 0, Input.Length);
                }
                return _opCodes;
            }
            set { }
        }
        private int[] _opCodes;
        private InputCapturer _inputCapturer;

        public void FindNounVerb(int expectedTotal)
        {
            int noun;
            int verb;

            for (noun = 0; noun < 100; noun++)
            {
                for (verb = 0; verb < 100; verb++)
                {
                    OpCodes[1] = noun;
                    OpCodes[2] = verb;
                    RunProgramme();

                    if (OpCodes[0] == expectedTotal)
                    {
                        return;
                    }
                    else
                    {
                        Array.Copy(Input, 0, _opCodes, 0, Input.Length);
                    }
                }
            }
        }
        
        public void RunProgramme()
        {
            var opCodesLength = OpCodes.Length;

            for (int i = 0; i < (opCodesLength - 3); i++)
            {
                var opCode = new OpCode()
                {
                    Instruction = OpCodes[i],
                    FirstParameter = OpCodes[i+1],
                    SecondParameter = OpCodes[i+2],
                    OutputIndex = OpCodes[i+3]
                };

                if (opCode.Instruction == 99) return;

                if (opCode.OutputIndex < opCodesLength
                    && opCode.FirstParameter < opCodesLength
                    && opCode.SecondParameter < opCodesLength)
                {
                    ExecuteOpCode(opCode, ref i);
                }
            }
        }

        private void AddOp(int param1, int param2, int outputIndex) => OpCodes[outputIndex] = OpCodes[param1] + OpCodes[param2];

        private void MultiplyOp(int operandIndex1, int operandIndex2, int outputIndex) =>  OpCodes[outputIndex] = OpCodes[operandIndex1] * OpCodes[operandIndex2];

        private void ExecuteOpCode(OpCode opCode, ref int index)
        {
            switch (opCode.Instruction)
            {
                case 1:
                    AddOp(opCode.FirstParameter, opCode.SecondParameter, opCode.OutputIndex);
                    index += 3;
                    break;
                case 2:
                    MultiplyOp(opCode.FirstParameter, opCode.SecondParameter, opCode.OutputIndex);
                    index += 3;
                    break;
                case 3:
                    index += 1;
                    break;
                case 4:
                    index += 1;
                    break;
                default:
                    break;
            }
        }

    }
}



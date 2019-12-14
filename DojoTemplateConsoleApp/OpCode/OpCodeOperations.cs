using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.OpCode
{
    public class OpCodeOperations
    {
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
                    ExecuteOpCode();

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
        
        public void ExecuteOpCode()
        {
            var opCodesLength = OpCodes.Length;
            for (int i = 0; i < (opCodesLength - 3); i++)
            {
                var replaceIndex = OpCodes[i + 3];
                var nounIndex = OpCodes[i + 1];
                var verbIndex = OpCodes[i + 2];

                if (replaceIndex < opCodesLength &&
                    nounIndex < opCodesLength &&
                    verbIndex < opCodesLength)
                {
                    switch (OpCodes[i])
                    {
                        case 99:
                            return;
                        case 1:
                            OpCodes[replaceIndex] = AddOp(nounIndex, verbIndex);
                            i += 3;
                            break;
                        case 2:
                            OpCodes[replaceIndex] = MultiplyOp(nounIndex, verbIndex);
                            i += 3;
                            break;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        public int AddOp(int operandIndex1, int operandIndex2)
        {
            return OpCodes[operandIndex1] + OpCodes[operandIndex2];
        }

        public int MultiplyOp(int operandIndex1, int operandIndex2)
        {
            return OpCodes[operandIndex1] * OpCodes[operandIndex2];
        }

    }
}



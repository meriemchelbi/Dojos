﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class OpCodeOperations
    {
        public List<int> OpCodes { get; set; }

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
                }
            }
        }
        
        public void ExecuteOpCode()
        {
            for (int i = 0; i < (OpCodes.Count - 3); i++)
            {
                var replaceIndex = OpCodes[i + 3];
                var operandIndex1 = OpCodes[i + 1];
                var operandIndex2 = OpCodes[i + 2];

                if (replaceIndex < OpCodes.Count &&
                    operandIndex1 < OpCodes.Count &&
                    operandIndex2 < OpCodes.Count)
                {
                    switch (OpCodes[i])
                    {
                        case 99:
                            return;
                        case 1:
                            OpCodes[replaceIndex] = AddOp(operandIndex1, operandIndex2);
                            i += 3;
                            break;
                        case 2:
                            OpCodes[replaceIndex] = MultiplyOp(operandIndex1, operandIndex2);
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

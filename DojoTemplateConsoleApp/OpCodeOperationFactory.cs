using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class OpCodeOperationFactory
    {
        public List<int> OpCodes { get; set; }


        static int Add(int operandOne, int operandTwo)
        {
            return operandOne + operandTwo;
        }
        
        static int Multiply(int operandOne, int operandTwo)
        {
            return operandOne * operandTwo;
        }

        public List<int> ExecuteOpCode(List<int> opCodes)
        {
            // for element in opcodes
            for (int i = 0; i < opCodes.Count; i++)
            {
                switch (opCodes[i])
                {
                    case 99:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                }
            }
            // switch on value:
            // 99- break
            // 1- add, insert result into item of index & move to next item
            // 2- multiply, insert result into item of index & move to next item

            return opCodes;
        }

        public int AddOp(int v1, int v2)
        {
            throw new NotImplementedException();
        }

        public int MultiplyOp(int v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}

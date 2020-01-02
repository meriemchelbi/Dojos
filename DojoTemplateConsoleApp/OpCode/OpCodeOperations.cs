using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.OpCode
{
    public interface IOperateOpCode
    {
        public int[] OpCodes { get; set; }
    }
    public class OpCodeOperations: IOperateOpCode
    {
        public OpCodeOperations(ICaptureInput inputCapturer)
        {
            _inputCapturer = inputCapturer;
            _opCodeFactory = new OpCodeFactory(this);
            DiagnosticOutputs = new List<int>();
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
        public List<int> DiagnosticOutputs { get; set; }
        
        private int[] _opCodes;
        private readonly ICaptureInput _inputCapturer;
        private readonly ICreateOpCode _opCodeFactory;

        public void RunProgramme()
        {
            for (int i = 0; i < OpCodes.Length - 1; i++)
            {
                var instruction = OpCodes[i] % 100;
                if (instruction == 99
                    || ((instruction == 1 || instruction == 2) && i > OpCodes.Length - 3))
                {
                    return;
                }

                var opCode = _opCodeFactory.CreateOpCode(i);

                ExecuteOpCode(opCode, ref i);
            }
        }

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
                    try
                    {
                        RunProgramme();
                    }
                    catch (Exception) { }

                    if (OpCodes[0] == expectedTotal)
                    {
                        return;
                    }
                    else // reset
                    {
                        Array.Copy(Input, 0, _opCodes, 0, Input.Length);
                    }
                }
            }
        }

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
                    RequestInput(opCode.FirstParameter);
                    index += 1;
                    break;
                case 4:
                    OutputValue(opCode.FirstParameter);
                    index += 1;
                    break;
                default:
                    break;
            }
        }

        private void AddOp((int, int) param1, (int, int) param2, (int, int) outputIndex)
        {
            var operand1 = OpCodes[param1.Item1];
            var operand2 = OpCodes[param2.Item1];
            OpCodes[outputIndex.Item1] = operand1 + operand2;
        }

        private void MultiplyOp((int, int) param1, (int, int) param2, (int, int) outputIndex)
        {
            OpCodes[outputIndex.Item1] = OpCodes[param1.Item1] * OpCodes[param2.Item1];
        }
        private void RequestInput((int, int) saveLocation)
        {
            var input = _inputCapturer.GetUserInput();
            OpCodes[saveLocation.Item1] = input;
        }

        private void OutputValue((int, int) inputParameter) => DiagnosticOutputs.Add(OpCodes[inputParameter.Item1]);

    }
}



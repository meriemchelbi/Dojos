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
                if (OpCodes[i] == 99
                    || ((OpCodes[i] == 1 || OpCodes[i] == 2) && i > OpCodes.Length - 3))
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

        private void RequestInput(int saveLocation)
        {
            var input = _inputCapturer.GetUserInput();
            OpCodes[saveLocation] = input;
        }

        private void OutputValue(int inputLocation) => DiagnosticOutputs.Add(OpCodes[inputLocation]);

    }
}



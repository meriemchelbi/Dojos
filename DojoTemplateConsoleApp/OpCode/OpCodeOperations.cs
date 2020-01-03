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
                    AddOp(opCode);
                    index += 3;
                    break;
                case 2:
                    MultiplyOp(opCode);
                    index += 3;
                    break;
                case 3:
                    RequestInput(opCode);
                    index += 1;
                    break;
                case 4:
                    OutputValue(opCode);
                    index += 1;
                    break;
                default:
                    break;
            }
        }

        private void AddOp(OpCode opCode)
        {
            OpCodes[Math.Abs(opCode.OutputIndex.Item1)] =
                (opCode.FirstParameter.Item2 == 1 && opCode.SecondParameter.Item2 == 1)
                ? opCode.FirstParameter.Item1 + opCode.SecondParameter.Item1
                : (opCode.FirstParameter.Item2 == 0 && opCode.SecondParameter.Item2 == 1)
                ? OpCodes[Math.Abs(opCode.FirstParameter.Item1)] + opCode.SecondParameter.Item1
                : (opCode.FirstParameter.Item2 == 1 && opCode.SecondParameter.Item2 == 0)
                ? opCode.FirstParameter.Item1 + OpCodes[Math.Abs(opCode.SecondParameter.Item1)]
                : OpCodes[Math.Abs(opCode.FirstParameter.Item1)] + OpCodes[Math.Abs(opCode.SecondParameter.Item1)];
        }

        private void MultiplyOp(OpCode opCode)
        {
            OpCodes[Math.Abs(opCode.OutputIndex.Item1)] =
                (opCode.FirstParameter.Item2 == 1 && opCode.SecondParameter.Item2 == 1)
                ? opCode.FirstParameter.Item1 * opCode.SecondParameter.Item1
                : (opCode.FirstParameter.Item2 == 0 && opCode.SecondParameter.Item2 == 1)
                ? OpCodes[Math.Abs(opCode.FirstParameter.Item1)] * opCode.SecondParameter.Item1
                : (opCode.FirstParameter.Item2 == 1 && opCode.SecondParameter.Item2 == 0)
                ? opCode.FirstParameter.Item1 * OpCodes[Math.Abs(opCode.SecondParameter.Item1)]
                : OpCodes[Math.Abs(opCode.FirstParameter.Item1)] * OpCodes[Math.Abs(opCode.SecondParameter.Item1)];
        }

        private void RequestInput(OpCode opCode)
        {
            var input = _inputCapturer.GetUserInput();
            OpCodes[Math.Abs(opCode.FirstParameter.Item1)] = input;
        }

        private void OutputValue(OpCode opCode)
        {
            switch (opCode.FirstParameter.Item2)
            {
                case 0:
                    DiagnosticOutputs.Add(OpCodes[Math.Abs(opCode.FirstParameter.Item1)]);
                    break;
                case 1:
                    DiagnosticOutputs.Add(opCode.FirstParameter.Item1);
                    break;
                default:
                    break;
            }
        }

        private void JumpIfTrue(OpCode opCode)
        {

        }

        private void JumpIfFalse(OpCode opCode)
        {

        }

        private void LessThan(OpCode opCode)
        {

        }
        
        private void Equals(OpCode opCode)
        {

        }

    }
}



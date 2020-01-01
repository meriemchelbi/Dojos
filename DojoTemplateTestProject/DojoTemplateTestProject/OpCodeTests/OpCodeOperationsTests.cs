using DojoTemplateConsoleApp.OpCode;
using FluentAssertions;
using NSubstitute;
using System;
using System.Linq;
using Xunit;

namespace DojoTemplateTestProject.OpCodeTests
{
    public class OpCodeOperationsTests
    {
        [Theory]
        [InlineData(12, 1)]
        [InlineData(4, 10)]
        [InlineData(1, 20)]
        public void OpCodeParserParsesToList(int opCode, int expectedElementIndex)
        {
            var inputCapturer = new InputCapturer();
            var opCodeOperations = new OpCodeOperations(inputCapturer);
            var parser = new OpCodeParser();
            var list = parser.ParseOpCode(opCodeOperations, @"OpCode\OpCode.txt");


            Assert.Equal(opCode, list[expectedElementIndex]);
        }
                
        [Theory]
        [InlineData("1,0,3,5,2,7,3,4,99,2,1,7,3", "1,0,3,5,15,6,3,4,99,2,1,7,3")]
        [InlineData("2,3,0,3,99", "2,3,0,6,99")]
        [InlineData("1,0,0,0,99", "2,0,0,0,99")]
        [InlineData("2,4,4,5,99,0", "2,4,4,5,99,9801")]
        [InlineData("1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]
        public void RunProgrammeInsertsExpectedResultInCorrectPosition(string sourceCode, string expectedOutput)
        {
            var inputCapturer = new InputCapturer();
            var opCodeOperations = new OpCodeOperations(inputCapturer)
            {
                Input = sourceCode.Split(',').Select(int.Parse).ToArray()
            };
            
            opCodeOperations.RunProgramme();
            var output = expectedOutput.Split(',').Select(int.Parse).ToArray();

            opCodeOperations.OpCodes.Should().BeEquivalentTo(output);
        }

        [Fact]
        public void RunProgrammeOutputsInputInCorrectPosition()
        {
            var inputCapturer = Substitute.For<ICaptureInput>();
            inputCapturer.GetUserInput().Returns(1);
            //var inputCapturer = new InputCapturer();
            var opCodeOps = new OpCodeOperations(inputCapturer)
            {
                Input = "3,0,4,0,99".Split(',').Select(int.Parse).ToArray()
            };
            var expectedOutput = 1;
            var expectedOpCodes = "1,0,4,0,99".Split(',').Select(int.Parse).ToArray();

            opCodeOps.RunProgramme();

            opCodeOps.OpCodes.Should().BeEquivalentTo(expectedOpCodes);
            opCodeOps.DiagnosticOutputs[0].Should().Be(expectedOutput);
        }

        //}

        //[Fact]
        //public void OpCodeExecutorFinalResult()
        //{
        //    var opCodeOperations = new OpCodeOperations();
        //    var inputParser = new OpCodeParser();
        //    inputParser.ParseOpCode(opCodeOperations, @"OpCode\OpCode.txt");
        //    opCodeOperations.ExecuteOpCode();
        //    var result = opCodeOperations.OpCodes[0];

        //    Console.WriteLine(result);
        //}

        [Theory]
        [InlineData("2,6,9,0,6,33", 4, 5, 198)]
        [InlineData("1,10,8,0,52", 2, 4, 56)]
        public void FindNounVerbTest(string input, int noun, int verb, int expectedOutput)
        {
            var inputCapturer = new InputCapturer();
            var opCodeOperations = new OpCodeOperations(inputCapturer)
            {
                Input = input.Split(',').Select(int.Parse).ToArray()
            };
           
            opCodeOperations.FindNounVerb(expectedOutput);

            Assert.Equal(noun, opCodeOperations.OpCodes[1]);           
            Assert.Equal(verb, opCodeOperations.OpCodes[2]);           
        }

    }
}

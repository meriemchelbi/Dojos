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
            var inputCapturer = new UserInputCapturer();
            var opCodeOperations = new OpCodeOperations(inputCapturer);
            var opCodeFactory = new OpCodeFactory(opCodeOperations);
            var parser = new OpCodeParser();
            parser.ParseOpCode(opCodeOperations, @"OpCode\OpCode.txt");


            Assert.Equal(opCode, opCodeOperations.Input[expectedElementIndex]);
        }
                
        [Theory]
        [InlineData("1,0,3,5,2,7,3,4,99,2,1,7,3", "1,0,3,5,15,6,3,4,99,2,1,7,3")]
        [InlineData("2,3,0,3,99", "2,3,0,6,99")]
        [InlineData("102,4,0,3,9999", "102,4,0,408,9999")]
        [InlineData("1,0,0,0,99", "2,0,0,0,99")]
        [InlineData("1001,0,0,6,99999,2,43,2,0", "1001,0,0,6,99999,2,1001,2,0")]
        [InlineData("2,4,4,5,99,0", "2,4,4,5,99,9801")]
        [InlineData("1102,4,4,5,99,0,8", "1102,4,4,5,99,16,8")]
        [InlineData("1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]
        [InlineData("101,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]
        [InlineData("1002,4,3,4,33", "1002,4,3,4,99")]
        public void RunProgrammeInsertsExpectedResultInCorrectPosition(string sourceCode, string expectedOutput)
        {
            var inputCapturer = new UserInputCapturer();
            var opCodeOperations = new OpCodeOperations(inputCapturer)
            {
                Input = sourceCode.Split(',').Select(int.Parse).ToArray()
            };
            var opCodeFactory = new OpCodeFactory(opCodeOperations);

            opCodeOperations.RunProgramme();
            var output = expectedOutput.Split(',').Select(int.Parse).ToArray();

            opCodeOperations.OpCodes.Should().BeEquivalentTo(output);
        }

        [Theory]
        [InlineData("3,0,4,0,99", "1,0,4,0,99", 1)]
        [InlineData("3,0,104,56,99", "1,0,104,56,99", 56)]
        public void RunProgrammeOutputsInputInCorrectPosition(string sourceCode, string expectedCode, int expectedOutput)
        {
            var inputCapturer = Substitute.For<ICaptureInput>();
            inputCapturer.GetUserInput().Returns(1);
            var opCodeOps = new OpCodeOperations(inputCapturer)
            {
                Input = sourceCode.Split(',').Select(int.Parse).ToArray()
            };
            var opCodeFactory = new OpCodeFactory(opCodeOps);
            var expectedOpCodes = expectedCode.Split(',').Select(int.Parse).ToArray();

            opCodeOps.RunProgramme();

            opCodeOps.OpCodes.Should().BeEquivalentTo(expectedOpCodes);
            opCodeOps.DiagnosticOutputs[0].Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("2,6,9,0,6,33", 4, 5, 198)]
        [InlineData("1,10,8,0,52", 2, 4, 56)]
        public void FindNounVerbTest(string input, int noun, int verb, int expectedOutput)
        {
            var inputCapturer = new UserInputCapturer();
            var opCodeOperations = new OpCodeOperations(inputCapturer)
            {
                Input = input.Split(',').Select(int.Parse).ToArray()
            };
            var opCodeFactory = new OpCodeFactory(opCodeOperations);

            opCodeOperations.FindNounVerb(expectedOutput);

            Assert.Equal(noun, opCodeOperations.OpCodes[1]);           
            Assert.Equal(verb, opCodeOperations.OpCodes[2]);           
        }

    }
}

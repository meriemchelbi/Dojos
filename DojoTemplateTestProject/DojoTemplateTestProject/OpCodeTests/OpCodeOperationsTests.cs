using System;
using System.Collections.Generic;
using Xunit;
using DojoTemplateConsoleApp;
using NSubstitute;
using DojoTemplateConsoleApp.OpCode;
using System.Linq;
using FluentAssertions;

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
            var opCodeOperations = new OpCodeOperations();
            var inputParser = new InputParser();
            var list = inputParser.ParseOpCode(opCodeOperations);
            
            Assert.Equal(opCode, list[expectedElementIndex]);
        }
                
        [Theory]
        [InlineData("33,4,6,5,1,0,3,5,2,7,3,4,99,2,1,7,3", "33,4,6,5,25,38,3,5,2,7,3,4,99,2,1,7,3")]
        [InlineData("2,3,0,3,99", "2,3,0,6,99")]
        [InlineData("1,0,0,0,99", "2,0,0,0,99")]
        [InlineData("2,4,4,5,99,0", "2,4,4,5,99,9801")]
        [InlineData("1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]
        public void OpCodeExecutorInsertsExpectedResultInCorrectPosition(string sourceCode, string expectedOutput)
        {
            var substitute = Substitute.For<OpCodeOperations>();
            substitute.Input = sourceCode.Split(',').Select(int.Parse).ToArray();
            substitute.ExecuteOpCode();

            substitute.Should().Equals(expectedOutput);
        }

        [Fact]
        public void OpCodeExecutorFinalResult()
        {
            var opCodeOperations = new OpCodeOperations();
            var inputParser = new InputParser();
            inputParser.ParseOpCode(opCodeOperations);
            opCodeOperations.ExecuteOpCode();
            var result = opCodeOperations.OpCodes[0];

            Console.WriteLine(result);
        }

        [Fact]
        public void AddOpReturnsExpectedTotal()
        {
            var substitute = Substitute.For<OpCodeOperations>();
            substitute.Input = new int[] { 33, 4, 6, 5, 1, 0, 3, 2, 7, 3, 1, 99, 2, 1, 7, 3 };
            var result = substitute.AddOp(3, 1);

            Assert.Equal(9, result);

        }
        
        [Fact]
        public void MultiplyOpReturnsExpectedTotal()
        {
            var substitute = Substitute.For<OpCodeOperations>();
            substitute.Input = new int[] { 33, 4, 6, 5, 1, 0, 3, 2, 7, 3, 1, 99, 2, 1, 7, 3 };
            var result = substitute.MultiplyOp(3, 1);

            Assert.Equal(20, result);

        }

        [Theory]
        [InlineData("2,6,9,0,6,33", 4, 5, 198)]
        [InlineData("1,10,8,0,52", 2, 4, 56)]
        public void FindNounVerbTest(string input, int noun, int verb, int expectedOutput)
        {
            var substitute = Substitute.For<OpCodeOperations>();
            substitute.Input = input.Split(',').Select(int.Parse).ToArray();
            substitute.OpCodes = new int[substitute.Input.Length];
            Array.Copy(substitute.Input, 0, substitute.OpCodes, 0, substitute.Input.Length);
            substitute.FindNounVerb(expectedOutput);

            Assert.Equal(noun, substitute.OpCodes[1]);           
            Assert.Equal(verb, substitute.OpCodes[2]);           
        }

    }
}

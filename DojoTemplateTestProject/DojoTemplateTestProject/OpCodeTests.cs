using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using NSubstitute;
using FluentAssertions;
using DojoTemplateConsoleApp;


namespace DojoTemplateTestProject
{
    public class OpCodeTests
    {
        [Theory]
        [InlineData(12, 1)]
        [InlineData(4, 10)]
        [InlineData(1, 20)]
        public void OpCodeParserParsesToList(int opCode, int expectedElementIndex)
        {
            var opCodeOperations = new OpCodeOperations();
            var inputParser = new InputParser(opCodeOperations);
            var list = inputParser.ParseOpCode();
            
            Assert.Equal(opCode, list[expectedElementIndex]);
        }
                
        [Theory]
        [InlineData("33,4,6,5,1,0,3,5,2,7,3,4,99,2,1,7,3", "33,4,6,5,25,38,3,5,2,7,3,4,99,2,1,7,3")]
        [InlineData("2,3,0,3,99", "2,3,0,6,99")]
        [InlineData("1,0,0,0,99", "2,0,0,0,99")]
        [InlineData("2,4,4,5,99,0", "2,4,4,5,99,9801")]
        [InlineData("1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]
        [InlineData("12,2,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,13,1,19,1,19,10,23,2,10,23,27,1,27,6,31,1,13,31,35,1,13,35,39,1,39,10,43,2,43,13,47,1,47,9,51,2,51,13,55,1,5,55,59,2,59,9,63,1,13,63,67,2,13,67,71,1,71,5,75,2,75,13,79,1,79,6,83,1,83,5,87,2,87,6,91,1,5,91,95,1,95,13,99,2,99,6,103,1,5,103,107,1,107,9,111,2,6,111,115,1,5,115,119,1,119,2,123,1,6,123,0,99,2,14,0,0", "30,1,1,4,2,5,6,0,99")]
        public void OpCodeExecutorInsertsExpectedResultInCorrectPosition(string sourceCode, string expectedOutput)
        {
            var substitute1 = Substitute.For<OpCodeOperations>();
            substitute1.OpCodes = sourceCode.Split(',').Select(int.Parse).ToList();
            substitute1.ExecuteOpCode();

            substitute1.Should().Equals(expectedOutput);
        }

        [Fact]
        public void OpCodeExecutorFinalResult()
        {
            var opCodeOperations = new OpCodeOperations();
            var inputParser = new InputParser(opCodeOperations);
            inputParser.ParseOpCode();
            opCodeOperations.ExecuteOpCode();
            var result = opCodeOperations.OpCodes[0];

            Console.WriteLine(result);
        }

        [Fact]
        public void AddOpReturnsExpectedTotal()
        {
            var substitute = Substitute.For<OpCodeOperations>();
            substitute.OpCodes = new List<int>() { 33, 4, 6, 5, 1, 0, 3, 2, 7, 3, 1, 99, 2, 1, 7, 3 };
            var result = substitute.AddOp(3, 1);

            Assert.Equal(9, result);

        }
        
        [Fact]
        public void MultiplyOpReturnsExpectedTotal()
        {
            var substitute = Substitute.For<OpCodeOperations>();
            substitute.OpCodes = new List<int>() { 33, 4, 6, 5, 1, 0, 3, 2, 7, 3, 1, 99, 2, 1, 7, 3 };
            var result = substitute.MultiplyOp(3, 1);

            Assert.Equal(20, result);

        }


        
        

        
    }
}

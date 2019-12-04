using System;
using System.Collections.Generic;
using Xunit;
using DojoTemplateConsoleApp;
using NSubstitute;

namespace DojoTemplateTestProject
{
    public class OpCodeTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(4, 10)]
        [InlineData(1, 20)]
        public void OpCodeParserParsesToList(int opCode, int expectedElementIndex)
        {
            var inputParser = new InputParser();
            var list = inputParser.ParseOpCode();
            
            Assert.Equal(opCode, list[expectedElementIndex]);
        }
                
        // TODO add test for out of range
        [Fact]
        public void OpCodeExecutorInsertsExpectedResultInCorrectPosition()
        {
            var opCodeOperations = new OpCodeOperationFactory();
            var opCodes = new List<int>(){33, 4, 6, 5, 1, 0, 3, 2, 7, 3, 1, 99, 2, 1, 7, 3};
            var executed = opCodeOperations.ExecuteOpCode(opCodes);

            Assert.Equal(38, executed[2]);
            Assert.Equal(7, executed[1]);
            Assert.Equal(5, executed[3]);
        }

        [Fact]
        public void AddOpReturnsExpectedTotal()
        {
            var substitute = Substitute.For<OpCodeOperationFactory>();
            substitute.OpCodes = new List<int>() { 33, 4, 6, 5, 1, 0, 3, 2, 7, 3, 1, 99, 2, 1, 7, 3 };
            var result = substitute.AddOp(3, 1);

            Assert.Equal(9, result);

        }
        
        [Fact]
        public void MultiplyOpReturnsExpectedTotal()
        {
            var opCodeOperations = new OpCodeOperationFactory();
            var opCodes = new List<int>() { 33, 4, 6, 5, 1, 0, 3, 2, 7, 3, 1, 99, 2, 1, 7, 3 };
            var result = opCodeOperations.MultiplyOp(3, 1);

            Assert.Equal(20, result);

        }


        
        

        
    }
}

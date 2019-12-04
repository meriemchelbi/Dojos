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
            var opCodeOperations = new OpCodeOperations();
            var inputParser = new InputParser(opCodeOperations);
            var list = inputParser.ParseOpCode();
            
            Assert.Equal(opCode, list[expectedElementIndex]);
        }
                
        // TODO add test for out of range
        [Fact]
        public void OpCodeExecutorInsertsExpectedResultInCorrectPosition()
        {
            var substitute1 = Substitute.For<OpCodeOperations>();
            substitute1.OpCodes = new List<int>(){33, 4, 6, 5, 1, 0, 3, 5, 2, 7, 3, 4, 99, 2, 1, 7, 3};
            substitute1.ExecuteOpCode();
            
            Assert.Equal(38, substitute1.OpCodes[5]);
            Assert.Equal(25, substitute1.OpCodes[4]);
            Assert.Equal(5, substitute1.OpCodes[3]);
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

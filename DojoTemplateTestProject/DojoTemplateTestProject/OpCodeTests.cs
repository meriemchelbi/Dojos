using System;
using System.Collections.Generic;
using Xunit;
using DojoTemplateConsoleApp;

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
                
        
        [Fact]
        public void AddShouldInsertCorrectResultInExpectedPosition(List<int> opCodes, int positionOne, int positionTwo, int PositionThree)
        {
            var opCodeOperations = new OpCodeOperationFactory();
            var add = opCodeOperations.Add(opCodes, positionOne, positionTwo, PositionThree);

            Assert.Equal(expectedFuelMass, actualModuleMass);
        }


        //[Fact]
        //public void CalculateTotalFuelRequirementsShouldReturnCorrectTotal()
        //{
        //    var fuelMassCalculator = new FuelMassCalculator();
        //    var actualTotalFuelMass = fuelMassCalculator.CalculateTotalFuelRequirements();

        //    Assert.Equal(3384232, actualTotalFuelMass);
        //}
        
    }
}

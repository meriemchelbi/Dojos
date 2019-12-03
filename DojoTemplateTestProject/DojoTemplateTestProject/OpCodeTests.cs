using System;
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
                
        
        [Theory]
        [InlineData(14, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void CalculateModuleFuelMassShouldReturnCorrectMass(int moduleMass, int expectedFuelMass)
        {
            var fuelMassCalculator = new FuelMassCalculator();
            var actualModuleMass = fuelMassCalculator.CalculateModuleFuelMass(moduleMass);

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

using System;
using Xunit;
using DojoTemplateConsoleApp;

namespace DojoTemplateTestProject
{
    public class FuelRequirementsTests
    {
        [Theory]
        [InlineData(51585, 0)]
        [InlineData(103969, 16)]
        [InlineData(72867, 56)]
        [InlineData(102481, 90)]
        [InlineData(126543, 99)]
        public void ModuleMassParsesStringToIntMass(int expectedMass, int elementIndex)
        {
            var moduleMassParser = new ModuleMassParser();
            
            Assert.Equal(expectedMass, moduleMassParser.ModuleMasses[elementIndex]);
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

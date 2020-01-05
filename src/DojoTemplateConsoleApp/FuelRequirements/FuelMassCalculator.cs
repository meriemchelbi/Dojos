using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.FuelRequirements
{
    public class FuelMassCalculator
    {
        private readonly InputParser _moduleMassParser;
        public FuelMassCalculator()
        {
            _moduleMassParser = new InputParser();
        }

        public int CalculateModuleFuelMass(int mass)
        {
            var fuelMass = 0;

            while (mass > 5)
            {
                mass = (int)(Math.Floor((decimal)mass / 3) - 2);
                fuelMass += mass;
            }
            return fuelMass;
        }

        public int CalculateTotalFuelRequirements(IEnumerable<int> moduleMasses)
        {
            int totalFuelMass = 0;

            foreach (var moduleMass in moduleMasses)
            {
                totalFuelMass += CalculateModuleFuelMass(moduleMass);
            }

            return totalFuelMass;
            
        }
    }
}

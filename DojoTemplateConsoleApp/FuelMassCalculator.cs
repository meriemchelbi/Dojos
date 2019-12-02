using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class FuelMassCalculator
    {
        private readonly ModuleMassParser _moduleMassParser;
        public FuelMassCalculator()
        {
            _moduleMassParser = new ModuleMassParser();
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

        public int CalculateTotalFuelRequirements()
        {
            int totalFuelMass = 0;

            foreach (var moduleMass in _moduleMassParser.ModuleMasses)
            {
                totalFuelMass += CalculateModuleFuelMass(moduleMass);
            }

            return totalFuelMass;
            
        }
    }
}

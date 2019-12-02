using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class ModuleMassParser
    {
        public List<int> ModuleMasses
        {
            get
            { 
                if (_moduleMasses is null) 
                    _moduleMasses = ParseModuleMass();
                return _moduleMasses;
            }
            private set {}
        }

        private List<int> _moduleMasses;
        
        public List<int> ParseModuleMass()
        {
            var moduleMasses = new List<int>();
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\merie\Documents\GitHub\Dojos\DojoTemplateConsoleApp\ModuleMasses.txt");
            foreach (string line in lines)
            {
                var moduleMass = int.Parse(line);
                moduleMasses.Add(moduleMass);
            }

            return moduleMasses;
        
        }
        
    }
}

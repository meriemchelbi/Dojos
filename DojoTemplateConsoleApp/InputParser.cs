using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class InputParser
    {
        //public List<int> ModuleMasses
        //{
        //    get
        //    { 
        //        if (_moduleMasses is null) 
        //            _moduleMasses = ParseModuleMass();
        //        return _moduleMasses;
        //    }
        //    private set {}
        //}

        private List<int> _moduleMasses;
        
        public List<int> ParseModuleMass()
        {
            var moduleMasses = new List<int>();
            var input = System.IO.File.ReadAllLines(@"..\..\..\..\..\DojoTemplateConsoleApp\ModuleMasses.txt");
            foreach (var line in input)
            {
                var moduleMass = int.Parse(line);
                moduleMasses.Add(moduleMass);
            }

            return moduleMasses;
        
        }

        public List<int> ParseOpCode()
        {
            var opCodes = new List<int>();
            var commaDelimitedInput = System.IO.File.ReadAllText(@"..\..\..\..\..\DojoTemplateConsoleApp\OpCode.txt");
            var inputArray = commaDelimitedInput.Split(",");
            foreach (var item in inputArray)
            {
                var code = int.Parse(item);
                opCodes.Add(code);
            }

            return opCodes;
        }
    }
}

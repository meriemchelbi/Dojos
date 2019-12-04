using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

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

        public InputParser()
        {

        }
        public InputParser(OpCodeOperations opCodeOperations)
        {
            _opCodeOperationFactory = opCodeOperations;
        }

        private List<int> _moduleMasses;
        private readonly OpCodeOperations _opCodeOperationFactory;
        
        public List<int> ParseModuleMass()
        {
            var moduleMasses = new List<int>();
            var input = System.IO.File.ReadAllLines(@"..\..\..\..\..\DojoTemplateConsoleApp\ModuleMasses.txt");
            //Assembly.GetExecutingAssembly().GetManifestResourceStream("DojoTemplateConsoleApp.ModuleMasses.txt"); 
            foreach (var line in input)
            {
                var moduleMass = int.Parse(line);
                moduleMasses.Add(moduleMass);
            }

            return moduleMasses;
        
        }

        public List<int> ParseOpCode()
        {
            var commaDelimitedInput = System.IO.File.ReadAllText(@"..\..\..\..\..\DojoTemplateConsoleApp\OpCode.txt");
            var inputArray = commaDelimitedInput.Split(",");
            _opCodeOperationFactory.OpCodes = inputArray.Select(c => int.Parse(c)).ToList();
               
            return _opCodeOperationFactory.OpCodes;
        }
    }
}

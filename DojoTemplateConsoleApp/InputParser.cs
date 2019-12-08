using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.IO;

namespace DojoTemplateConsoleApp
{
    public class InputParser
    {
        public InputParser()
        {

        }
        public InputParser(OpCodeOperations opCodeOperations)
        {
            _opCodeOps = opCodeOperations;
        }

        private List<int> _moduleMasses;
        private readonly OpCodeOperations _opCodeOps;
        
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
            //var commaDelimitedInput = System.IO.File.ReadAllText(@"..\..\..\..\..\DojoTemplateConsoleApp\OpCode.txt");
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"OpCode.txt");
            var commaDelimitedInput = File.ReadAllText(path);
            // Assembly.GetExecutingAssembly().GetManifestResourceStream("DojoTemplateConsoleApp.OpCode.txt").BeginRead();
            var inputArray = commaDelimitedInput.Split(",");
            
            _opCodeOps.OpCodes = inputArray.Select(c => int.Parse(c)).ToList();
               
            return _opCodeOps.OpCodes;
        }
    }
}

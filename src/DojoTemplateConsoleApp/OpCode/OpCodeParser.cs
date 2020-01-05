using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DojoTemplateConsoleApp.OpCode
{
    public class OpCodeParser
    {
        public void ParseOpCode(OpCodeOperations opCodeOperations, string fileName)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            opCodeOperations.Input = File.ReadAllText(path)
                            .Split(",")
                            .Select(c => int.Parse(c))
                            .ToArray();
        }
    }
}

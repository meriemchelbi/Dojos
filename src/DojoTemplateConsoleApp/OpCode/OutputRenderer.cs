using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DojoTemplateConsoleApp.OpCode
{
    public class OutputRenderer
    {
        public void DisplayDiagnosticOutput(OpCodeOperations opCodeOps)
        {
            opCodeOps.DiagnosticOutputs.ForEach(o => Console.WriteLine(o));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.OpCode
{
    public class OpCode
    {
        public int Instruction { get; set; }
        //public int FirstParameter { get; set; }
        //public int SecondParameter { get; set; }
        //public int OutputIndex { get; set; }

        public (int, int) FirstParameter { get; set; }
        public (int, int) SecondParameter { get; set; }
        public (int, int) OutputIndex { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace IntCodeComputer
{
    public class OpCode
    {
        public int Instruction { get; set; }
        public (int, int) FirstParameter { get; set; }
        public (int, int) SecondParameter { get; set; }
        public (int, int) OutputIndex { get; set; }
    }
}

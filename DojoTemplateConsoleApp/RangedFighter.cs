using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class RangedFighter : Character
    {
        public int AttackRange { get; set; } = 20;

        public int Position { get; set; }
    }
}

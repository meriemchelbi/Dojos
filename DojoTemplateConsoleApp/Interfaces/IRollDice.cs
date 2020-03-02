using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public interface IRollDice
    {
        public bool IsDouble { get; }
        (int, int) RollDice();
    }
}

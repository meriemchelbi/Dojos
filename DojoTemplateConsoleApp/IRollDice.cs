using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public interface IRollDice
    {
        (int, int) RollDice();
    }
}

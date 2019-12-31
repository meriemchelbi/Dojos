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

        public int[] Input { get; set; }
        public int[] OpCodes
        {
            get
            {
                if (_opCodes == null)
                {
                    _opCodes = new int[Input.Length];
                    Array.Copy(Input, 0, _opCodes, 0, Input.Length);
                }
                return _opCodes;
            }
            set { }
        }
        private int[] _opCodes;

        public int[] ParseOpCode(OpCodeOperations opCodeOperations, string fileName)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            return Input = File.ReadAllText(path)
                            .Split(",")
                            .Select(c => int.Parse(c))
                            .ToArray();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DojoTemplateConsoleApp;

namespace DojoTemplateTestProject
{
    public class FramesTestDataClass: IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                "X X X X X X X X X X X X",
                new List<Frame>
                {
                    new Frame() {Roll1 = 10, Roll2 = 0, isStrike = true}
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}

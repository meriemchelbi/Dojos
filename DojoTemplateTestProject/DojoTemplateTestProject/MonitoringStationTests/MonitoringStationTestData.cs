using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateTestProject.MonitoringStationTests
{
    internal class MonitoringStationTestData: IEnumerable<object[]>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                    new string[][]
                    {
                        new string[] {".", "#", ".", ".", "#" },
                        new string[] {".", ".", ".", ".", "." },
                        new string[] {"#", "#", "#", "#", "#" },
                        new string[] {".", ".", ".", ".", "#" },
                        new string[] {".", ".", ".", ".", "#" },
                        new string[] {".", ".", ".", "#", "#" }
                    },
                    (x: 3, y: 4)
            };
            yield return new object[]
            {
                    new string[][]
                    {
                        new string[] { ".", ".", ".", ".", ".", ".", "#", ".", "#", "." },
                        new string[] { "#", ".", ".", "#", ".", "#", ".", ".", ".", "." },
                        new string[] {".", ".", "#", "#", "#", "#", "#", "#", "#", "." },
                        new string[] {".", "#", ".", "#", ".", "#", "#", "#", ".", "." },
                        new string[] {".", "#", ".", ".", "#", ".", ".", ".", ".", "." },
                        new string[] {".", ".", "#", ".", "#", ".", ".", "#", ".", "#" },
                        new string[] {"#", ".", ".", "#", ".", ".", ".", ".", "#", "." },
                        new string[] {".", "#", "#", ".", "#", ".", ".", "#", "#", "#" },
                        new string[] {"#", "#", ".", ".", ".", "#", ".", ".", "#", "." },
                        new string[] {".", "#", ".", ".", ".", ".", "#", "#", "#", "#" },
                    },
                    (x: 5, y: 8)
            };
        }
            
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

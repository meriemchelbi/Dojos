using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateTestProject.MonitoringStationTests
{
    internal class MonitoringStationTestData: IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                    new char[][]
                    {
                        new char[] {'.', '#', '.', '.', '#' },
                        new char[] {'.', '.', '.', '.', '.' },
                        new char[] {'#', '#', '#', '#', '#' },
                        new char[] {'.', '.', '.', '.', '#' },
                        new char[] {'.', '.', '.', '#', '#' }
                    },
                    8
            };
            yield return new object[]
            {
                    new char[][]
                    {
                        new char[] {'.', '.', '.', '.', '.', '.', '#', '.', '#', '.' },
                        new char[] {'#', '.', '.', '#', '.', '#', '.', '.', '.', '.' },
                        new char[] {'.', '.', '#', '#', '#', '#', '#', '#', '#', '.' },
                        new char[] {'.', '#', '.', '#', '.', '#', '#', '#', '.', '.' },
                        new char[] {'.', '#', '.', '.', '#', '.', '.', '.', '.', '.' },
                        new char[] {'.', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
                        new char[] {'#', '.', '.', '#', '.', '.', '.', '.', '#', '.' },
                        new char[] {'.', '#', '#', '.', '#', '.', '.', '#', '#', '#' },
                        new char[] {'#', '#', '.', '.', '.', '#', '.', '.', '#', '.' },
                        new char[] {'.', '#', '.', '.', '.', '.', '#', '#', '#', '#' },
                    },
                    33
            };
            yield return new object[]
            {
                    new char[][]
                    {
                        new char[] {'#','.','#','.','.','.','#','.','#','.' },
                        new char[] {'.','#','#','#','.','.','.','.','#','.' },
                        new char[] {'.','#','.','.','.','.','#','.','.','.' },
                        new char[] {'#','#','.','#','.','#','.','#','.','#' },
                        new char[] {'.','.','.','.','#','.','#','.','#','.' },
                        new char[] {'.','#','#','.','.','#','#','#','.','#' },
                        new char[] {'.','.','#','.','.','.','#','#','.','.' },
                        new char[] {'.','.','#','#','.','.','.','.','#','#' },
                        new char[] {'.','.','.','.','.','.','#','.','.','.' },
                        new char[] {'.','#','#','#','#','.','#','#','#','.' },
                    },
                    35
            };


        }
            
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

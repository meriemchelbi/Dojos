using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DojoTemplateTestProject
{
    public class Staircase
    {
        public void staircase(int n)
        {
            var matrix = new string[n, n];

            for (int i = 0; i < n; i++)
            {
                var noOfStairs = i + 1;
                var noOfSpaces = n - noOfStairs;

                for (int sp = 0; sp < noOfSpaces; sp++)
                    matrix[i, sp] = " ";

                for (int h = noOfSpaces; h < n; h++)
                    matrix[i, h] = "#";
            }

            for (int k = 0; k < n; k++)
            {
                for (int l = 0; l < n; l++)
                    Console.Write(matrix[k, l]);
                
                Console.Write('\n');
            }
        }

        [Fact]
        public void Test()
        {
            staircase(5);
        }
    }

}

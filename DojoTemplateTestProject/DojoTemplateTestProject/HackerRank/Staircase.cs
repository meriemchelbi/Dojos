using System;
using Xunit;

namespace DojoTemplateTestProject.HackerRank
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

                Console.Write(Environment.NewLine);
            }
        }

        [Fact]
        public void Test()
        {
            staircase2(5);
        }

        public void staircase2(int n)
        {
            var noOfStairs = 1;

            while (noOfStairs++ < n)
            {
                var stairs = new string('#', noOfStairs);
                var spaces = new string(' ', n - noOfStairs);
                string line = string.Concat(spaces, stairs);
                Console.WriteLine(line);
            }
        }


        public void staircase3(int totalStairs)
        {
            for (int noOfStairs = 1; noOfStairs <= totalStairs; noOfStairs++)
            {
                Console.WriteLine(
                    new string('#', noOfStairs) +
                    new string(' ', totalStairs - noOfStairs));
            }
        }
    }

}

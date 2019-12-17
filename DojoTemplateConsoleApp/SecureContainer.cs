using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class SecureContainer
    {

        public bool HasOnlyIncreasingDigits(int password)
        {
            var passwordString = password.ToString();
            var hasOnlyIncreasingDigits = true;

            for (int i = 0; i < passwordString.Length - 1; i++)
            {
                if (passwordString[i] > passwordString[i + 1])
                {
                    hasOnlyIncreasingDigits = false;
                    break;
                }
            }

            return hasOnlyIncreasingDigits;
        }

        public int FindNumberOfMatches(int lowerBound, int higherBound)
        {
            var matches = 0;

            for (int value = lowerBound; value < higherBound; value++)
            {
                if (HasTwoAdjacentMatchingDigits(value) && HasOnlyIncreasingDigits(value))
                {
                    Console.WriteLine(value);
                    matches++;
                }
            }

            return matches;
        }

        public bool HasTwoAdjacentMatchingDigits(int password)
        {
            return password.ToString().GroupBy(c => c).Any(c => c.Count() == 2);
        }
    }
}

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
            var hasTwo = false;
            var passwordString = password.ToString();

            foreach (var character in passwordString)
            {
                var charToCompare = character;
                var count = 0;

                foreach (var number in passwordString)
                {
                    if (number.Equals(charToCompare))
                    {
                        count++;
                    }
                }
                
                if (count == 2)
                {
                    hasTwo = true;
                    break;
                }
            }

            return hasTwo;

            // With Linq:
            // return password.ToString().GroupBy(c => c).Any(c => c.Count() == 2);
            // Mike's solution:
            //for (int i = 0; i < digits.Count - 1; i++)
            //{
            //    if (digits[i] == digits[i + 1]
            //        && (i == 0 || digits[i] != digits[i - 1])
            //        && (i == digits.Count - 2 || digits[i] != digits[i + 2]))
            //        return true;
            //}
        }
    }
}

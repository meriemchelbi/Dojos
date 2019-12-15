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

        // implement with Linq by finding out whether single instance of double digit in collection
        public bool HasTwoAdjacentMatchingDigits(int password)
        {
            var passwordString = password.ToString();
            var hasTwoAdjacentMatchingDigits = false;
            var tempValue = false;

            for (int i = 1; i < passwordString.Length - 1; i++)
            {
                hasTwoAdjacentMatchingDigits =
                    (passwordString[i].Equals(passwordString[i - 1]) && !passwordString[i].Equals(passwordString[i + 1]) && (i == 1 || tempValue == true)) ? true
                    : ((i == (passwordString.Length - 2)) && (!passwordString[i].Equals(passwordString[i - 1]) && passwordString[i].Equals(passwordString[i + 1]))) ? true : false;

                if (hasTwoAdjacentMatchingDigits) break;

                tempValue = (passwordString[i].Equals(passwordString[i + 1]) && !passwordString[i].Equals(passwordString[i - 1])) ? true : false;

                if (passwordString[i].Equals(passwordString[i - 1]) && passwordString[i].Equals(passwordString[i + 1]))
                {
                    i += 2;
                    tempValue = false;
                }
            }

            return hasTwoAdjacentMatchingDigits;
        }
    }
}

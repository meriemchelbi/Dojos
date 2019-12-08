using System;
using System.Collections.Generic;
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
            int value = lowerBound;

            while (value >= lowerBound && value <= higherBound)
            {
                if (HasTwoAdjacentMatchingDigits(value) && HasOnlyIncreasingDigits(value))
                {
                    matches++;
                }

                value++;
            }

            return matches;
        }

        public bool HasTwoAdjacentMatchingDigits(int password)
        {
            var passwordString = password.ToString();
            var hasTwoAdjacentMatchingDigits = false;
            var tempValue = false;

            for (int i = 0; i < passwordString.Length - 1; i++)
            {
                if (passwordString[i].Equals(passwordString[i + 1]) && !hasTwoAdjacentMatchingDigits)
                {
                    hasTwoAdjacentMatchingDigits = true;
                    tempValue = true;
                }
                else if (passwordString[i].Equals(passwordString[i + 1]) && tempValue)
                {
                    hasTwoAdjacentMatchingDigits = false;
                }
                else
                {
                    tempValue = false;
                }
            }

            return hasTwoAdjacentMatchingDigits;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DojoTemplateTestProject
{
    public class RepeatedString
    {
        public long repeatedString(string s, long n)
        {
            var countInString = CountInString(s);
            var sInN = n / s.Length;

            long result = countInString * sInN;

            var remainder = n % s.Length;
            if (remainder != 0)
            {
                var sample = s.Substring(0, (int)remainder);
                result += CountInString(sample);
            }

            return result;
        }

        private int CountInString(string s)
        {
            var countInString = 0;

            foreach (var letter in s)
            {
                if (letter == 'a')
                    countInString += 1;
            }

            return countInString;
        }

        [Theory]
        [InlineData("abcac", 10, 4)]
        [InlineData("aba", 10, 7)]
        [InlineData("a", 1000000000000, 1000000000000)]
        public void Test(string repeated, long sampleLength, long expected)
        {
            var result = repeatedString(repeated, sampleLength);

            Assert.Equal(expected, result);
        }
    }
}

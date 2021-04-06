using System;
using System.Collections.Generic;
using Xunit;

namespace DojoTemplateTestProject
{
    public class LongestCommonSubstring
    {
        public int SubstringDiff(int k, string s1, string s2)
        {
            var longest = CalculateDiff(k, s1, s2);

            return longest;
        }
        private int CalculateDiff(int k, string s1, string s2)
        {
            var noOfDifferences = 0;
            var longest = 0;

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                    noOfDifferences += 1;
            }

            if (noOfDifferences > k)
            {
                var substrings1 = GetSubstrings(s1);
                var substrings2 = GetSubstrings(s2);

                for (int i = 0; i < substrings1.Length; i++)
                {
                    var diffLength = CalculateDiff(k, substrings1[i], substrings2[i]);
                    longest = diffLength > longest ? diffLength : longest;
                }

                return longest;
            }

            else
                return s1.Length;
        }

        private string[] GetSubstrings(string s)
        {
            //var substrings = new List<string>();

            //var substringLength = s.Length - 1;
            throw new NotImplementedException();
        }


        [Theory]
        [InlineData(1, "abcd", "bbca")]
        public void Test(int maxDiff, string s1, string s2)
        {
            var result = SubstringDiff(maxDiff, s1, s2);

            Assert.Equal(3, result);
        }
    }
}

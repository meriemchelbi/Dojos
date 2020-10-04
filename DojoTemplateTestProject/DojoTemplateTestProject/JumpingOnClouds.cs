using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DojoTemplateTestProject
{
    public class JumpingOnClouds
    {
        // https://www.hackerrank.com/challenges/jumping-on-the-clouds/problem
        public int jumpingOnClouds(int[] clouds)
        {
            var jumps = 0;

            for (int i = 0; i < clouds.Length - 1; i++)
            {
                if (clouds[i+1] == 1 ||
                    (i < clouds.Length - 2 && clouds[i + 2] == 0))
                {
                    jumps += 1;
                    i++;
                }

                else
                {
                    jumps += 1;
                }
            }

            return jumps;
        }

        [Theory]
        [InlineData(4, 0, 0, 1, 0, 0, 1, 0)]
        [InlineData(3, 0, 1, 0, 0, 0, 1, 0)]
        [InlineData(3, 0, 1, 0, 0, 1, 0)]
        public void Test(int expected, params int[] clouds)
        {
            var result = jumpingOnClouds(clouds);

            Assert.Equal(expected, result);
        }
    }
}

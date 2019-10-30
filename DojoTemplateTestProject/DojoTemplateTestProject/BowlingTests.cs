using System;
using Xunit;

namespace DojoTemplateTestProject
{
    public class BowlingTests
    {
        [Fact]
        public void TestLoadFrames()
        {

        }

        [InlineData("X X X X X X X X X X X X", "101010101010101010101010", 300)] // all strikes
        [InlineData("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", "90909090909090909090", 90)] // I'm not very good, but at least I'm consistent
        [InlineData("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5", "555555555555555555555", 150)] // all spares
        [InlineData("X 45 7/ 3- X X 5/ 22 X 4/8", "104573301010552210468", 143)] // mix of strikes, spares & misses
        [InlineData("9- 52 -/ 71 -- 16 80 11 43 -7", "905201071001680114307", 72)] // miss & spare in same frame
        [Theory]
        public void TestCalculateTotalScore()
        {

        }
    }
}

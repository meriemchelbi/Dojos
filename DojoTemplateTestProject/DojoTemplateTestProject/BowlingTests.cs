using DojoTemplateConsoleApp;
using System;
using System.Collections.Generic;
using Xunit;

namespace DojoTemplateTestProject
{
    public class BowlingTests
    {
        
        [Theory]
        [ClassData(typeof(FramesTestDataClass))]
        public void TestLoadFrames(string scores, List<Frame> expectedFrameScores)
        {
            // actual = call LoadFrames with scores as argument

            // assert that number of frames in expected = actual

            // For i in length of expected frame scores, assert that
            // expected.Framei.roll1 = actual.framei.roll1
            // expected.Framei.roll2 = actual.framei.roll2
            // expected.Framei.isStrike = actual.framei.isStrike
            // expected.Framei.isSpare = actual.framei.isSpare
            

        }

        [InlineData("X X X X X X X X X X X X", 300)] // all strikes
        [InlineData("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", 90)] // I'm not very good, but at least I'm consistent
        [InlineData("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5", 150)] // all spares
        [InlineData("X 45 7/ 3- X X 5/ 22 X 4/8", 143)] // mix of strikes, spares & misses
        [InlineData("9- 52 -/ 71 -- 16 80 11 43 -7", 72)] // miss & spare in same frame
        [Theory]
        public void TestCalculateTotalScore(string scores, int totalScore)
        {

        }
    }
}

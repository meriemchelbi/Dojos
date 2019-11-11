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
        public void LoadFramesLoadsAllScoreFrames(string scores, List<Frame> expectedFrames)
        {
            var bowlingGame = new BowlingGame(scores);
            var actualFrames = bowlingGame.Frames;
            
            // Correct number of frames created
            Assert.Equal(expectedFrames.Count, actualFrames.Count);
            
            // Frames created with correct data
            for (int i = 0; i < expectedFrames.Count; i++)
            {
                Assert.Equal(expectedFrames[i].Roll1, actualFrames[i].Roll1);
                Assert.Equal(expectedFrames[i].Roll2, actualFrames[i].Roll2);
                Assert.Equal(expectedFrames[i].IsStrike, actualFrames[i].IsStrike);
                Assert.Equal(expectedFrames[i].IsSpare, actualFrames[i].IsSpare);
            }
            
        }

        [InlineData("X X X X X X X X X X X X", 300)] // all strikes
        [InlineData("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", 90)] // I'm not very good, but at least I'm consistent
        [InlineData("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5", 150)] // all spares
        [InlineData("9- 52 -/ 71 -- 16 X 11 43 -7", 76)] // mix of strikes, spares & misses, incl miss & spare in same frame
        [Theory]
        public void CalculateTotalScoreCalculatesCorrectScore(string scores, int expectedTotalScore)
        {
            var bowlingGame = new BowlingGame(scores);
            var totalScore = bowlingGame.TotalScore;

            Assert.Equal(expectedTotalScore, totalScore);

        }
    }
}

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
            bowlingGame.LoadFrames();
            
            // Correct number of frames created
            Assert.Equal(expectedFrames.Count, bowlingGame.Scores.Count);
            
            // Frames created with correct data
            for (int i = 0; i < expectedFrames.Count; i++)
            {
                Assert.Equal(expectedFrames[i].Roll1, bowlingGame.Scores[i].Roll1);
                Assert.Equal(expectedFrames[i].Roll2, bowlingGame.Scores[i].Roll2);
                Assert.Equal(expectedFrames[i].IsStrike, bowlingGame.Scores[i].IsStrike);
                Assert.Equal(expectedFrames[i].IsSpare, bowlingGame.Scores[i].IsSpare);
            }
            
        }

        [InlineData("X X X X X X X X X X X X", 300)] // all strikes
        [InlineData("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", 90)] // I'm not very good, but at least I'm consistent
        [InlineData("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5", 150)] // all spares
        [InlineData("9- 52 -/ 71 -- 16 X 11 43 -7", 72)] // mix of strikes, spares & misses, incl miss & spare in same frame
        [Theory]
        public void CalculateTotalScoreCalculatesCorrectScore(string scores, int expectedTotalScore)
        {
            var bowlingGame = new BowlingGame(scores);
            bowlingGame.LoadFrames();
            var totalScore = bowlingGame.CalculateTotalScore();

            Assert.Equal(expectedTotalScore, totalScore);

        }
    }
}

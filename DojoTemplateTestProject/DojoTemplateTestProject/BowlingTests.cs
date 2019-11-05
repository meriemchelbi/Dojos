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
            // actual = call LoadFrames with scores as argument
            var bowlingGame = new BowlingGame(scores);
            bowlingGame.LoadFrames();
            
            // assert that number of frames in expected = actual
            Assert.Equal(expectedFrames.Count, bowlingGame.Scores.Count);
            Assert.Equal(expectedFrames, bowlingGame.Scores);

            // For i in length of expected frame scores, assert that
            // expected.Framei.roll1 = actual.framei.roll1
            // expected.Framei.roll2 = actual.framei.roll2
            // expected.Framei.IsStrike = actual.framei.IsStrike
            // expected.Framei.IsSpare = actual.framei.IsSpare


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

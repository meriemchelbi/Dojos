using DojoTemplateConsoleApp;
using System;
using System.Collections.Generic;
using Xunit;

namespace DojoTemplateTestProject
{
    public class BowlingTests
    {
        
        [Theory]
        [ClassData(typeof(LoadFramesTestData))]
        public void LoadFramesLoadsAllScoreFrames(string scores, List<Frame> expectedFrames)
        {
            var framesLoader = new FramesLoader();
            var actualFrames = framesLoader.LoadFrames(scores);
            
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

        [Theory]
        [ClassData(typeof(CalculateScoresTestData))]
        public void CalculateTotalScoreCalculatesCorrectScore(List<Frame> frames, int expectedTotalScore)
        {
            var scoreCalculator = new ScoreCalculator();
            var totalScore = scoreCalculator.CalculateTotalScore(frames);

            Assert.Equal(expectedTotalScore, totalScore);

        }
    }
}

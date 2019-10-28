using DojoTemplateConsoleApp;
using System;
using System.Collections.Generic;
using Xunit;

namespace DojoTemplateTestProject
{
    public class BowlingTests
    {
        [Theory]
        [InlineData("X X X X X X X X X X X X", "101010101010101010101010", 300)]
        [InlineData("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", "90909090909090909090", 90)]
        [InlineData("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5", "555555555555555555555", 150)]
        [InlineData("X 45 7/ 3- X X 5/ 22 X 4/8", "104573301010552210468", 143)]
        [InlineData("9- 52 2- 71 -- 16 80 11 43 -7", "90522071001680114307",57)]
        public void TestScoresLoadedAndCalculated(string inputScores, string expectedScoresString, int totalScore)
        {
            // ARRANGE
            var bowlingGame = new BowlingGame();


            // ACT
            var actualScores = bowlingGame.LoadScores(inputScores);
            string actualScoresString = string.Empty;
            foreach (var score in actualScores)
            {
                var scoreString = score.ToString();
                actualScoresString += scoreString;
            }
            var actualScore = bowlingGame.CalculateTotalScore(actualScores);

            // ASSERT
            Assert.Equal(expectedScoresString, actualScoresString);
            Assert.Equal(totalScore, actualScore);
        }

    }
}

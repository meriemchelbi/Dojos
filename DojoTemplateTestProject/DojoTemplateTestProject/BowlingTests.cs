using DojoTemplateConsoleApp;
using System;
using System.Collections.Generic;
using Xunit;

namespace DojoTemplateTestProject
{
    public class BowlingTests
    {
        [Theory]
        [InlineData("X X X X X X X X X X X X", "101010101010101010101010")]
        [InlineData("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", "90909090909090909090")]
        [InlineData("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5", "555555555555555555555")]
        [InlineData("X 45 7/ 3- X X 5/ 22 X 4/8", "104573301010552210468")]
        [InlineData("9- 52 2- 7/ -- 16 8/ 11 43 -7", "90522073001682114307")]
        [InlineData("9- 52 2- 71 -- 16 80 11 43 -7", "90522071001680114307")]
        public void TestScoresLoaded(string inputScores, string expectedScoresString)
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

            // ASSERT
            Assert.Equal(expectedScoresString, actualScoresString);
        }

        [Theory]
        [InlineData("101010101010101010101010", 300)]
        [InlineData("90909090909090909090", 90)]
        [InlineData("555555555555555555555", 150)]
        [InlineData("104573301010552210468", 143)]
        [InlineData("90522071001680114307", 57)]
        public void TestCalculateTotalScore(string scores, int totalScore)
        {
            // ARRANGE
            var bowlingGame = new BowlingGame();
            var scoresList = new List<int>();
            for (int i = 0; i < scores.Length; i++)
            {
                if (i < scores.Length - 1 && (Equals((scores[i].ToString() + scores[i + 1].ToString()), "10")))
                {
                    scoresList.Add(10);
                    i++;
                }

                else
                {
                    var score = int.Parse(scores[i].ToString());
                    scoresList.Add(score);
                }
            }
                
            // ACT
            var actualScore = bowlingGame.CalculateTotalScore(scoresList);

            // ASSERT
            Assert.Equal(totalScore, actualScore);

        }
    }
}

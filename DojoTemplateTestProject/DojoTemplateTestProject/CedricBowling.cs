using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DojoTemplateTestProject
{
    public class CedricBowling
    {
        public int CalculateScore(string game)
        {
            var result = 0;

            for (var i = 0; i < game.Length; i++)
            {
                switch (game[i])
                {
                    case 'X': // Strike has the next two rolls who count as bonus
                        result += CalculateRollScore(game, i);
                        result += CalculateRollScore(game, i + 1);
                        result += CalculateRollScore(game, i + 2);
                        break;
                    case '/': // Spare has the next roll who count as bonus
                        result += CalculateRollScore(game, i);
                        result += CalculateRollScore(game, i + 1);
                        break;
                    default:
                        result += CalculateRollScore(game, i);
                        break;
                }

                // When the last frame is a Strike or Spare there are bonuses (already counted in CalculateRollScore())
                if (game[i] == '/' && i == game.Length - 2) break;
                if (game[i] == 'X' && i == game.Length - 3) break;
            }

            return result;
        }

        private int CalculateRollScore(string game, int index)
        {
            if (index < 0 || index >= game.Length) return 0;

            switch (game[index])
            {
                case '-': return 0;
                case 'X': return 10;
                case '/': return 10 - int.Parse(game[index - 1] + "");
                default: return int.Parse(game[index] + "");
            }
        }
    }

    public class CedricBowlingTests
    {
        [Theory]
        [InlineData("XXXXXXXXXXXX", 300)]
        [InlineData("9-9-9-9-9-9-9-9-9-9-", 90)]
        [InlineData("5/5/5/5/5/5/5/5/5/5/5", 150)]
        [InlineData("X457/3-XX5/22X4/8", 143)]
        [InlineData("9-522-71--16801143-7", 57)]
        public void CalculateScore(string game, int score)
        {
            // Act
            var result = new CedricBowling().CalculateScore(game);

            // Assert
            Assert.Equal(score, result);
            
        }
    }
}

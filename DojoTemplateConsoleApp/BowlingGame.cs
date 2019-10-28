using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// http://codingdojo.org/kata/Bowling/
/// </summary>
namespace DojoTemplateConsoleApp
{
    public class BowlingGame
    {
        public IList<int> LoadScores(string inputScores)
        {
            var scores = new List<int>();
            var trimmedScores = inputScores.Replace(" ", String.Empty);
            
            for (int i = 0; i < trimmedScores.Length; i++)
            {
                switch (trimmedScores[i])
                {
                    case 'X':
                        scores.Add(10);
                        break;
                    case '/':
                        var remainder = int.Parse(trimmedScores[i - 1].ToString());
                        scores.Add(10 - remainder);
                        break;
                    case '-':
                        scores.Add(0);
                        break;
                    default:
                        var score = int.Parse(trimmedScores[i].ToString());
                        scores.Add(score);
                        break;

                }
                
            }
            
            return scores;
        }

        public int CalculateTotalScore(IList<int> scores)
        {
            var totalScore = 0;

            for (int i = 0; i < scores.Count; i++)
            {
                if (scores[i] == 10)
                {
                    totalScore += 10 + scores[i + 1] + scores[i + 2];

                    if (i == (scores.Count - 3))
                    {
                        break;
                    }
                }

                else if ((i < (scores.Count - 2)) && (scores[i] + scores[i + 1]) == 10)
                {
                    totalScore += 10 + scores[i + 2];

                    if (i == (scores.Count - 3))
                    {
                        break;
                    }
                    else
                    {
                        i ++;
                    }
                }

                else
                {
                    totalScore += scores[i] + scores[i + 1];
                    i++;
                }
            }

            return totalScore;
        }
    }
}

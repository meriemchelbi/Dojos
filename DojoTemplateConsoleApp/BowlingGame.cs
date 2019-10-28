using System;
using System.Collections.Generic;
using System.Text;


// http://codingdojo.org/kata/Bowling/

namespace DojoTemplateConsoleApp
{
    public class BowlingGame
    {
        public IList<int> Scores { get; private set; }

        public int TotalScore { get; private set; }

        private readonly string inputScores;

        public BowlingGame(string inputScores)
        {
            this.inputScores = inputScores;
            Scores = LoadScores();
            TotalScore = CalculateTotalScore();
        }
        
        private IList<int> LoadScores()
        {
            var scores = new List<int>();
            var trimmedScores = inputScores.Replace(" ", string.Empty);
            
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

        private int CalculateTotalScore()
        {
            var totalScore = 0;

            for (int i = 0; i < Scores.Count; i++)
            {
                if (Scores[i] == 10)
                {
                    totalScore += 10 + Scores[i + 1] + Scores[i + 2];

                    if (i == (Scores.Count - 3))
                    {
                        break;
                    }
                }

                else if ((i < (Scores.Count - 2)) && (Scores[i] + Scores[i + 1]) == 10)
                {
                    totalScore += 10 + Scores[i + 2];

                    if (i == (Scores.Count - 3))
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
                    totalScore += Scores[i] + Scores[i + 1];
                    i++;
                }
            }

            return totalScore;
        }
    }
}

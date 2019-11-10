using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class BowlingGame
    {
        public IList<Frame> Scores { get; private set; }
        private readonly string _scores;
        
        public BowlingGame(string scores)
        {
            
            this._scores = scores;
            Scores = new List<Frame>();
        }


        public void LoadFrames()
        {
            var trimmedScores = this._scores.Replace(" ", "");
            
            for (int index = 0; index < trimmedScores.Length; index++)
            {
                var currentElement = trimmedScores[index];

                switch (currentElement)
                {
                    case 'X':
                        AddStrikeFrame();
                        break;
                    default:
                        switch (index)
                        {
                            case 20:
                                AddFrame(currentElement, '0');
                                break;
                            default:
                                var nextElement = trimmedScores[index + 1];
                                AddFrame(currentElement, nextElement);
                                index++; //TODO: refactor to increment in loop logic only?
                                break;
                        }
                        break;
                        
                }


            }

        }

        private void AddFrame(char currentElement, char nextElement)
        {
            var frame = new Frame();

            switch (currentElement)
            {
                case '-':
                    frame.Roll1 = 0;
                    break;
                default:
                    frame.Roll1 = int.Parse(currentElement.ToString());
                    break;
            }

            switch (nextElement)
            {
                case '-':
                    frame.Roll2 = 0;
                    break;
                case '/':
                    frame.Roll2 = (10 - frame.Roll1);
                    frame.IsSpare = true;
                    break;
                default:
                    frame.Roll2 = int.Parse(nextElement.ToString());
                    break;
            }

            Scores.Add(frame);
        }

        private void AddStrikeFrame()
        {
            var frame = new Frame() { IsStrike = true, Roll1 = 10, Roll2 = 0 };
            Scores.Add(frame);
        }

        public object CalculateTotalScore()
        {
            throw new NotImplementedException();
        }
    }
}

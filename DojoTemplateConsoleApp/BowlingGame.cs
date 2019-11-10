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
            int increment;

            for (int index = 0; index < trimmedScores.Length; index += increment)
            {
                var currentElement = trimmedScores[index];
                Frame newFrame;

                switch (currentElement)
                {
                    case 'X':
                        newFrame = AddFrame(currentElement, '0');
                        break;
                    default:
                        switch (index)
                        {
                            case 20: // If final frame is a spare. 
                                newFrame = AddFrame(currentElement, '0');
                                break;
                            default:
                                var nextElement = trimmedScores[index + 1];
                                newFrame = AddFrame(currentElement, nextElement);
                                break;
                        }
                        break;
                }

                increment = newFrame.IsStrike switch
                {
                    true => 1,
                    false => 2
                };

            }


        }

        private Frame AddFrame(char currentElement, char nextElement)
        {
            var frame = new Frame();

            switch (currentElement)
            {
                case 'X':
                    frame.Roll1 = 10;
                    frame.IsStrike = true;
                    break;
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
            return frame;
        }


        public object CalculateTotalScore()
        {
            throw new NotImplementedException();
        }
    }
}

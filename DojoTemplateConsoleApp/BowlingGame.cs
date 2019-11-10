using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class BowlingGame
    {
        public IList<Frame> Frames 
        {
            get
            {
                if (_frames.Count == 0)
                {
                    LoadFrames();
                }
                return _frames;
            }
            private set { }
        }
        public int TotalScore
        {
            get
            {
                if (_totalScore == 0)
                {
                    CalculateTotalScore();
                }
                return _totalScore;
            }
            private set { }
        }



        private readonly string _scores;
        private readonly IList<Frame> _frames;
        private int _totalScore;
        private readonly FrameScoringStrategyRepository _frameScoringStrategyRepository;

        public BowlingGame(string scores)
        {
            
            _scores = scores;
            _frames = new List<Frame>();
            _totalScore = 0;
            _frameScoringStrategyRepository = new FrameScoringStrategyRepository();

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

            _frames.Add(frame);
            return frame;
        }


        public void CalculateTotalScore()
        {
            for (int i = 0; i < 10; i++)
            {
                var currentFrame = Frames[i];

                _totalScore += currentFrame.Roll1 + currentFrame.Roll2;

                if (currentFrame.IsSpare)
                {
                    _totalScore += _frameScoringStrategyRepository.FrameScoringStrategies["Spare"]
                        (new List<Frame>() { Frames[i + 1] }); 
                }
                else if (currentFrame.IsStrike)
                {
                    _totalScore += _frameScoringStrategyRepository.FrameScoringStrategies["Strike"]
                        (new List<Frame>() { Frames[i + 1], Frames[i + 2] });

                }
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    
    public class ScoreCalculator
    {
      
        private int _totalScore;
        private readonly FrameScoringStrategyFactory _frameScoringStrategyRepository;
        
        public ScoreCalculator()
        {
            
            _totalScore = 0;
            _frameScoringStrategyRepository = new FrameScoringStrategyFactory();

        }


        public int CalculateTotalScore(List<Frame> frames)
        {
            for (var i = 0; i < 10; i++)

            {
                var currentFrame = frames[i];

                _totalScore += currentFrame.Roll1 + currentFrame.Roll2;

                if (currentFrame.IsSpare)
                {
                    // lookup func from dictionary
                    _totalScore += _frameScoringStrategyRepository.FrameScoringStrategies["Spare"]
                        (frames, i); 

                }
                else if (currentFrame.IsStrike)
                {
                    // using helper method instead of func
                    _totalScore += FrameScoringStrategyFactory.GetStrikeFrameSupplement(frames, i);
                }

            }

            return _totalScore;

        }
    }
}

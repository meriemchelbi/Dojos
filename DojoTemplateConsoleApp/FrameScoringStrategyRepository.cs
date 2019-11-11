using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    class FrameScoringStrategyRepository
    {
        public Dictionary<string, Func<IList<Frame>, int, int>> FrameScoringStrategies;

        public FrameScoringStrategyRepository()
        {
            FrameScoringStrategies = new Dictionary<string, Func<IList<Frame>, int, int>>
            {
                {"Spare", GetSpareFrameSupplement },
                {"Strike", GetStrikeFrameSupplement }
            };
        }

        private int GetSpareFrameSupplement(IList<Frame> frames, int currentFrameIndex)
        {
            var spareSupplement = frames[currentFrameIndex + 1].Roll1;

            return spareSupplement;
        }

        private int GetStrikeFrameSupplement(IList<Frame> frames, int currentFrameIndex)
        {
            int strikeSupplement;
            
            switch (frames[0].IsStrike)
            {
                case true:
                    strikeSupplement = frames[currentFrameIndex].Roll1 + frames[currentFrameIndex + 1].Roll1;
                    break;
                case false:
                    strikeSupplement = frames[currentFrameIndex + 1].Roll1 + frames[currentFrameIndex + 1].Roll2;
                    break;
            }
            
            return strikeSupplement;
        }
    }
}

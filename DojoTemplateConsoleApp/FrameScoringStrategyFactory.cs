using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    class FrameScoringStrategyFactory
    {
        public Dictionary<string, Func<IList<Frame>, int, int>> FrameScoringStrategies;

        public FrameScoringStrategyFactory()
        {
            FrameScoringStrategies = new Dictionary<string, Func<IList<Frame>, int, int>>
            {
                {"Spare", GetSpareFrameSupplement },
                {"Strike", GetStrikeFrameSupplement }
            };
            
        }

        public static int GetSpareFrameSupplement(IList<Frame> frames, int currentFrameIndex)
        {
            var spareSupplement = frames[currentFrameIndex + 1].Roll1;
            return spareSupplement;

        }


        public static int GetStrikeFrameSupplement(IList<Frame> frames, int currentFrameIndex)
        {

            var strikeSupplement = frames[0].IsStrike
                ? (frames[currentFrameIndex].Roll1 + frames[currentFrameIndex + 1].Roll1)
                : (frames[currentFrameIndex + 1].Roll1 + frames[currentFrameIndex + 1].Roll2);

            return strikeSupplement;
        }
    }
}

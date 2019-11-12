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

        private static int GetSpareFrameSupplement(IList<Frame> frames, int currentFrameIndex)
        {
            var spareSupplement = frames[currentFrameIndex + 1].Roll1;
            return spareSupplement;

        }


        private static int GetStrikeFrameSupplement(IList<Frame> frames, int currentFrameIndex)
        {

            var strikeSupplement = frames[0].IsStrike
                ? (frames[currentFrameIndex].Roll1 + frames[currentFrameIndex + 1].Roll1)
                : (frames[currentFrameIndex + 1].Roll1 + frames[currentFrameIndex + 1].Roll2);

            return strikeSupplement;
        }
    }
}

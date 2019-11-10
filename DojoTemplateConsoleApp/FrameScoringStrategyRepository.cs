using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    class FrameScoringStrategyRepository
    {
        public Dictionary<string, Func<List<Frame>, int>> FrameScoringStrategies;

        public FrameScoringStrategyRepository()
        {
            FrameScoringStrategies = new Dictionary<string, Func<List<Frame>, int>>
            {
                {"Spare", new Func<List<Frame>, int>(GetSpareFrameSupplement) },
                {"Strike", new Func<List<Frame>, int>(GetStrikeFrameSupplement) }
            };
        }

        private int GetSpareFrameSupplement(List<Frame> frames)
        {
            var spareSupplement = frames[0].Roll1;

            return spareSupplement;
        }

        private int GetStrikeFrameSupplement(List<Frame> frames)
        {
            int strikeSupplement;
            
            switch (frames[0].IsStrike)
            {
                case true:
                    strikeSupplement = frames[0].Roll1 + frames[1].Roll1;
                    break;
                case false:
                    strikeSupplement = frames[0].Roll1 + frames[0].Roll2;
                    break;
            }
            
            return strikeSupplement;
        }
    }
}

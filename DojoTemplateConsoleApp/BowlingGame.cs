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
        }


        public void LoadFrames()
        {
            // trim scores
            // variable strikeFrame = false
            // case X > strikeFrame = true, isStrike = true
            // case / > strikeFrame = false, isSpare = true
            // case - > strikeFrame = false
            // default > strikeFrame = false

            // while strikeFrame == false
            // 

            throw new NotImplementedException();
        }

        public object CalculateTotalScore()
        {
            throw new NotImplementedException();
        }
    }
}

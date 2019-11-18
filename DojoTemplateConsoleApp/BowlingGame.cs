using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class BowlingGame
    {
        private readonly FramesLoader _framesLoader;
        private readonly ScoreCalculator _scoreCalculator;
        private readonly string _scores;


        public BowlingGame(string scores)
        {
            _scores = scores;
            _framesLoader = new FramesLoader();
            _scoreCalculator = new ScoreCalculator();
        }
        public void Play()
        {
            var frames = _framesLoader.LoadFrames(_scores);
            _scoreCalculator.CalculateTotalScore(frames);
        }
    }
}

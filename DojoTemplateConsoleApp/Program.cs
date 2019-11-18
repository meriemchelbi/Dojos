using System;

namespace DojoTemplateConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("What are the scores, George Dawes?");
                var scores = Console.ReadLine();
                // TODO: validate scores input
                var bowlingGame = new BowlingGame(scores);
                var totalScore = bowlingGame.Play();
                Console.WriteLine(totalScore);
            }
            
        }
    }
}

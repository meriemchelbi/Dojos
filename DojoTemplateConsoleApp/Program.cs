using System;

namespace DojoTemplateConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What are the scores, George Dawes? \n> ");
            var scores = Console.ReadLine();
            // TODO: validate scores input
            var bowlingGame = new BowlingGame(scores);
            bowlingGame.Play();
        }
    }
}

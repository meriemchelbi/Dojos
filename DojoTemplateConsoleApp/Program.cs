using System;
using System.Linq;

namespace DojoTemplateConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = new string[]
            {
                "mov 42 a",
                "dec a",
                "dec a",
                "inc a",
                "inc a",
                "dec a",
                "mov 40 b",
                "dec b",
                "dec b",
                "inc b",
            };

            var carriageNames = new string[] { "a", "b", "c"};
            var train = new Train(carriageNames);

            foreach (var command in commands)
            {
                var commandSplit = command.Split(' ');
                switch (commandSplit[0])
                {
                    case "mov":
                        train.Carriages.Single(x => x.CarriageName == commandSplit[2]).NumberOfSeatsRemaining =
                            int.Parse(commandSplit[1]);
                        break;
                    case "dec":
                        train.Carriages.Single(x => x.CarriageName == commandSplit[1]).Board();
                        break;
                    case "inc":
                        train.Carriages.Single(x => x.CarriageName == commandSplit[1]).Alight();
                        break;
                }

            }

            Console.WriteLine($"Number Of Seats Remaining in a : {train.Carriages.Single(x => x.CarriageName == "a").NumberOfSeatsRemaining}");
            Console.WriteLine($"Number Of Seats Remaining in b : {train.Carriages.Single(x => x.CarriageName == "b").NumberOfSeatsRemaining}");
            Console.WriteLine($"Number Of Seats Remaining in Train : {train.Carriages.Sum(x => x.NumberOfSeatsRemaining)}");

        }
    }
}

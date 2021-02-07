using System;

namespace DojoTemplateConsoleApp.UserInterface
{
    public class CallerInterface : ICallerInterface
    {
        private readonly IConsole _console;
        private readonly IFloorValidator _floorValidator;

        public CallerInterface(IConsole console, IFloorValidator floorValidator)
        {
            _console = console;
            _floorValidator = floorValidator;
        }

        public bool CheckForCall()
        {
            _console.WriteLine("Would you like to call the lift? Y/N");
            var response = _console.ReadLine().ToUpperInvariant();

            switch (response)
            {
                case "Y":
                    return true;
                case "N":
                    return false;
                default:
                    Console.WriteLine("Input not recognised");
                    return false;
            }
        }

        public int GetDestination()
        {
            _console.WriteLine("What is your destination? Please input a number between -1 and 6.");
            var response = _console.ReadLine();
            var destination = int.Parse(response);

            var isValidDestination = _floorValidator.ValidateFloor(destination);

            if (!isValidDestination)
            {
                Console.WriteLine("That is not a valid floor.");
                GetDestination();
            }

            return destination;
        }

        public int GetOrigin()
        {
            _console.WriteLine("What is your current floor? Please input a number between -1 and 6.");
            var response = _console.ReadLine();
            var origin = int.Parse(response);

            var isValidOrigin = _floorValidator.ValidateFloor(origin);

            if (!isValidOrigin)
            {
                _console.WriteLine("That is not a valid floor.");
                GetOrigin();
            }

            return origin;
        }
    }
}

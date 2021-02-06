using System;

namespace DojoTemplateConsoleApp.UserInterface
{
    public class InputCapturer : IInputCapturer
    {
        private readonly IFloorValidator _floorValidator;

        public InputCapturer(IFloorValidator floorValidator)
        {
            _floorValidator = floorValidator;
        }

        public bool CheckForCall()
        {
            Console.WriteLine("Would you like to call the lift? Y/N");
            var response = Console.ReadLine().ToUpperInvariant();

            switch (response)
            {
                case "Y":
                    return true;
                case "N":
                    return false;
                default:
                    Console.WriteLine("Input not recognised");
                    return CheckForCall();
            }
        }

        public int GetDestination()
        {
            Console.WriteLine("What is your destination? Please input a number between -1 and 6.");
            var response = Console.ReadLine();
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
            Console.WriteLine("What is your current floor? Please input a number between -1 and 6.");
            var response = Console.ReadLine();
            var origin = int.Parse(response);

            var isValidOrigin = _floorValidator.ValidateFloor(origin);

            if (!isValidOrigin)
            {
                Console.WriteLine("That is not a valid floor.");
                GetOrigin();
            }

            return origin;
        }
    }
}

using System;

namespace DojoTemplateConsoleApp.UserInterface
{
    public class InputCapturer : IInputCapturer
    {
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
            throw new NotImplementedException();
        }

        public int GetOrigin()
        {
            throw new NotImplementedException();
        }
    }
}

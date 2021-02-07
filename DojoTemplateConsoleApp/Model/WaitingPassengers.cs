using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.Model
{
    public class WaitingPassengers
    {
        public Queue<Passenger> JobQueue { get; set; }

        public WaitingPassengers()
        {
            JobQueue = new Queue<Passenger>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"There are {JobQueue.Count} passengers waiting\n");
            foreach (var passenger in JobQueue)
            {
                sb.Append($"{passenger}\n");
            }

            return sb.ToString(); 
        }
    }
}

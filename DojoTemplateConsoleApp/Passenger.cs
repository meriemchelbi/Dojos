namespace DojoTemplateConsoleApp
{
    public class Passenger
    {

        public int Origin { get; set; }
        public int Destination { get; set; }
        public Direction Direction
        {
            get { return GetDirection(); }
        }

        public Passenger(int origin, int destination)
        {
            Origin = origin;
            Destination = destination;
        }

        private Direction GetDirection()
        {
            if (Origin > Destination)
            {
                return Direction.Down;
            }

            else
            {
                return Direction.Up;
            }
        }
    }
}

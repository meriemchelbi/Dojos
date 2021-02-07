namespace DojoTemplateConsoleApp.Model
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

        public override string ToString()
        {
            return $"Passenger going {Direction}. Origin: {Origin}, Destination: {Destination}.";
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

namespace DojoTemplateConsoleApp
{
    public class FloorValidator : IFloorValidator
    {
        public bool ValidateFloor(int floorNumber)
        {
            return floorNumber >= -1 && floorNumber <= 6;
        }
    }
}

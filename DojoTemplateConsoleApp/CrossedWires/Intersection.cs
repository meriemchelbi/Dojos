namespace DojoTemplateConsoleApp.CrossedWires
{
    public class Intersection
    {
        public (int, int) Coordinates { get; set; }
        public Segment OverlappingSegmentW1 { get; set; }
        public Segment OverlappingSegmentW2 { get; set; }
        public int StepsToIntersectionW1 { get; set; }
        public int StepsToIntersectionW2 { get; set; }
    }
}

using DojoTemplateConsoleApp.MonitoringStation;
using System.Collections;
using System.Collections.Generic;

namespace DojoTemplateTestProject.MonitoringStationTests
{
    internal class CastRayTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<SpaceTile>
                {
                    new SpaceTile(0, 0),
                    new SpaceTile(1, 2),
                    new SpaceTile(2, 1),
                    new SpaceTile(2, 2)
                },
                new List<SpaceTile>
                {
                    new SpaceTile(0, 0),
                    new SpaceTile(1, 1),
                    new SpaceTile(2, 2)
                },
                0,
                3
            };
            yield return new object[]
            {
                new List<SpaceTile>
                {
                    new SpaceTile(1, 0),
                    new SpaceTile(4, 0),
                    new SpaceTile(0, 2),
                    new SpaceTile(1, 2),
                    new SpaceTile(2, 2),
                    new SpaceTile(3, 2),
                    new SpaceTile(4, 2),
                    new SpaceTile(4, 3),
                    new SpaceTile(3, 4),
                    new SpaceTile(4, 4)
                },
                new List<SpaceTile>
                {
                    new SpaceTile(1, 0),
                    new SpaceTile(2, 1),
                    new SpaceTile(3, 2),
                    new SpaceTile(4, 3),
                },
                6,
                0
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
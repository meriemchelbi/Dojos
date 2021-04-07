using System;
using System.Linq;
using Xunit;

namespace DojoTemplateTestProject.HackerRank
{
    public class MiniMax
    {
        public void MinMax(int[] arr)
        {
            var orderedArr = arr.OrderBy(i => i).ToArray();
            long lowest = 0;
            long highest = 0;

            for (int i = 0; i < 4; i++)
                lowest += orderedArr[i];

            for (int i = 4; i > 0; i--)
                highest += orderedArr[i];

            Console.WriteLine(lowest + " " + highest);

            var ordered = arr.OrderBy(i => i);
            var low = ordered.Take(4).Sum();
            var high = ordered.TakeLast(4).Sum();
        }

        public void MinMax2(int[] arr)
        {
            var ordered = arr.OrderBy(i => i).Cast<long>();
            var low = ordered.Take(4).Sum();
            var high = ordered.TakeLast(4).Sum();

            Console.WriteLine(low + " " + high);
        }

        public void MinMaxOldDotnet(int[] arr)
        {
            var low = arr.OrderBy(i => i)
                        .Cast<long>()
                        .Take(4).Sum();
            var high = arr.OrderByDescending(i => i)
                        .Cast<long>()
                        .Take(4).Sum();

            Console.WriteLine(low + " " + high);
        }

        [Theory]
        [InlineData(1659655705, 2484892405, 426980153, 354802167, 142980735, 968217435, 734892650)]
        [InlineData(2181931615, 2894274113, 254961783, 604179258, 462517083, 967304281, 860273491)]
        public void Test(long expectedLow, long expectedHighparams, params int[] input)
        {
            MinMaxOldDotnet(input);
        }
    }
}

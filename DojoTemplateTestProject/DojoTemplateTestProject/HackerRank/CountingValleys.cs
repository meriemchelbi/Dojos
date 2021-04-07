using Xunit;

namespace DojoTemplateTestProject.HackerRank
{
    // https://www.hackerrank.com/challenges/counting-valleys/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=warmup&h_r=next-challenge&h_v=zen
    public class CountingValleys
    {
        public int countingValleys(int steps, string path)
        {
            var noOfValleys = 0;

            var level = 0;

            foreach (var step in path)
            {
                if (step == 'D')
                {
                    if (level == 0)
                        noOfValleys += 1;

                    level -= 1;
                }

                if (step == 'U')
                {
                    level += 1;
                }
            }

            return noOfValleys;
        }

        [Theory]
        [InlineData(8, "UDDDUDUU", 1)]
        [InlineData(12, "DDUUDDUDUUUD", 2)]
        public void Test(int steps, string path, int expected)
        {
            var result = countingValleys(steps, path);

            Assert.Equal(expected, result);
        }
    }
}

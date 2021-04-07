using Xunit;

namespace DojoTemplateTestProject.HackerRank
{
    public class PlusMinus
    {
        public decimal[] plusMinus(int[] arr)
        {
            decimal positives = 0;
            decimal negatives = 0;
            decimal zeros = 0;

            foreach (var entry in arr)
            {
                if (entry < 0)
                {
                    negatives++;
                    continue;
                }

                if (entry == 0)
                {
                    zeros++;
                    continue;
                }

                if (entry > 0)
                {
                    positives++;
                    continue;
                }
            }

            var noOfElements = arr.Length;
            positives = decimal.Round(positives / noOfElements, 6);
            negatives = decimal.Round(negatives / noOfElements, 6);
            zeros = decimal.Round(zeros / noOfElements, 6);

            return new decimal[] { positives, negatives, zeros };
        }

        [Theory]
        [InlineData(0.400000, 0.400000, 0.200000, 1, 1, 0, -1, -1)]
        [InlineData(0.500000, 0.333333, 0.166667, -4, 3, -9, 0, 4, 1)]
        public void Test(decimal positiveValues,
                         decimal negativeValues,
                         decimal zeros,
                         params int[] numbers)
        {
            var result = plusMinus(numbers);

            Assert.Equal(positiveValues, result[0]);
            Assert.Equal(negativeValues, result[1]);
            Assert.Equal(zeros, result[2]);
        }
    }
}

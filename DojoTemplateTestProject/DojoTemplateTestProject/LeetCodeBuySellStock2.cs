using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DojoTemplateTestProject
{
    public class LeetCodeBuySellStock2
    {
        public int MaxProfit(int[] prices)
        {
            // if prices are in descending order, return 0
            var descending = prices.OrderByDescending(p => p);
            if (prices.SequenceEqual(descending))
                return 0;

            var holding = 0;
            var profit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                var currentPrice = prices[i];
                var remainingPrices = new ArraySegment<int>(prices, i, prices.Length - i);
                var highestRemainingPrice = remainingPrices.Max();

                // if not holding and current is highest price remaining, continue
                if (holding == 0 && currentPrice == highestRemainingPrice)
                    continue;

                // if not holding, buy
                if (holding == 0)
                {
                    holding = currentPrice;
                    continue;
                }

                // if holding and current is higher than holding, sell & add to profit
                if (holding != 0 && currentPrice > holding)
                {
                    profit += currentPrice - holding;
                    holding = 0;
                }
            }

            return profit;
        }

        [Theory]
        [InlineData(7, 7, 1, 5, 3, 6, 4)]
        [InlineData(4, 1, 2, 3, 4, 5)]
        [InlineData(0, 7, 6, 4, 3, 1)]
        public void TestMaxProfit(int expectedMaxProfit, params int[] prices)
        {
            var result = MaxProfit(prices);

            Assert.Equal(expectedMaxProfit, result);
        }
    }
}

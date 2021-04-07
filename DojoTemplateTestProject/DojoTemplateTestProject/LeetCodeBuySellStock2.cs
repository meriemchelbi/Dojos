using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DojoTemplateTestProject
{
    public class LeetCodeBuySellStock2
    {
        private int _strategy1Profit = 0;
        private int _strategy2Profit = 0;
        private int _strategy3Profit = 0;

        public int MaxProfit(int[] prices)
        {
            // if prices are in descending order, return 0
            var descending = prices.OrderByDescending(p => p);
            if (prices.SequenceEqual(descending))
                return 0;

            // if prices are in ascending order, return highest minus lowest
            var ascending = prices.OrderBy(p => p);
            if (prices.SequenceEqual(ascending))
                return prices.Last() - prices.First();

            //ExecuteStrategy(prices, SellStrategy1);
            //ExecuteStrategy(prices, SellStrategy2);
            //ExecuteStrategy(prices, SellStrategy3);

            var holding = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                var currentPrice = prices[i];
                var currentPriceProfit = currentPrice - holding;
                var remainingPrices = new ArraySegment<int>(prices, i, prices.Length - i);
                var highestRemainingPrice = remainingPrices.Max();
                var lowestRemainingPrice = remainingPrices.Min();
                var maxRemainingProfit = remainingPrices.Select(p => highestRemainingPrice - p).Max();
                //var maxProfitPrice = highestRemainingPrice - maxRemainingProfit;

                if (holding == 0 &&
                    (currentPrice == highestRemainingPrice ||
                    remainingPrices.Last() == highestRemainingPrice
                    && remainingPrices.First() != lowestRemainingPrice)
                    )
                    continue;

                // if not holding, buy
                if (holding == 0)
                {
                    holding = currentPrice;
                    continue;
                }

                if (holding != 0)
                {
                    if (highestRemainingPrice - holding >= maxRemainingProfit)
                    {
                        _strategy3Profit += maxRemainingProfit;
                        holding = 0;
                    }
                    else if (currentPrice > holding)
                    {
                        _strategy3Profit += currentPrice - holding;
                        holding = 0;
                    }
                }
            }



            var profits = new List<int> { _strategy1Profit, _strategy2Profit, _strategy3Profit };
            
            return profits.Max();
        }

        public void ExecuteStrategy(int[] prices, Func<int[], int, int> sellStrategy)
        {
            var holding = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                var currentPrice = prices[i];
                var remainingPrices = new ArraySegment<int>(prices, i, prices.Length - i);
                var highestRemainingPrice = remainingPrices.Max();
                var lowestRemainingPrice = remainingPrices.Min();

                if (holding == 0 &&
                    (currentPrice == highestRemainingPrice ||
                    remainingPrices.Last() == highestRemainingPrice
                    && remainingPrices.First() != lowestRemainingPrice)
                    )
                    continue;

                // if not holding, buy
                if (holding == 0)
                {
                    holding = currentPrice;
                    continue;
                }

                if (holding != 0)
                {
                    holding = sellStrategy(remainingPrices.ToArray(), holding);
                }
            }
        }

        public int SellStrategy1(int[] remainingPrices, int holding)
        {
            // sell whenever you hit a higher value
            var currentPrice = remainingPrices.First();
            
            if (currentPrice > holding)
            {
                _strategy1Profit += currentPrice - holding;
                holding = 0;
            }

            return holding;
        }
        
        public int SellStrategy2(int[] remainingPrices, int holding)
        {
            var currentPrice = remainingPrices.First();
            var highestRemainingPrice = remainingPrices.Max();

            if (currentPrice == highestRemainingPrice)
            {
                _strategy2Profit += currentPrice - holding;
                holding = 0;
            }

            return holding;
        }
        
        public int SellStrategy3(int[] remainingPrices, int holding)
        {
            var currentPrice = remainingPrices.First();
            var highestRemainingPrice = remainingPrices.Max();
            var currentPriceProfit = currentPrice - holding;
            var maxRemainingProfit = remainingPrices.Select(p => highestRemainingPrice - p).Max();
            var maxProfitPrice = highestRemainingPrice - maxRemainingProfit;

            if (holding == maxProfitPrice)
            {
                _strategy3Profit += maxRemainingProfit;
                holding = 0;
            }
            else if (currentPrice > holding)
            {
                _strategy3Profit += currentPrice - holding;
                holding = 0;
            }

            return holding;
        }

        [Theory]
        [InlineData(7, 7, 1, 5, 3, 6, 4)]
        [InlineData(4, 1, 2, 3, 4, 5)]
        [InlineData(0, 7, 6, 4, 3, 1)]
        [InlineData(7, 6, 1, 3, 2, 4, 7)]
        public void TestMaxProfit(int expectedMaxProfit, params int[] prices)
        {
            var result = MaxProfit(prices);

            Assert.Equal(expectedMaxProfit, result);
        }
    }
}

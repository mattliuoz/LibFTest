using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibFTest
{
    public class MaxTradeCalculator
    {
        //This exercise is pretty much about finding two data:
        //The largest profit and the lowest buy in price
        //Performance consideration: Given this data set are collected in one second interval, so it shouldn't be too big for a day worth of data, and therefor I didn't over do the performance tunning side.
        public static StockExchangeSummary GetMaxProfit(int[] stockPricesYesterday)
        {
            //There's no point to get the profit of only one price available
            if (stockPricesYesterday.Length < 2)
            {
                throw new ArgumentException("Stock prices should have at least two prices.");
            }

            if (stockPricesYesterday.Any(s => s <= 0))
            {
                //Assumption: 0 or below will consider as invalid value
                throw new ArgumentException("Stock prices contain some invalid value, it should never be 0.");
            }
            //Setting initial values for buy in and sell prices
            //those potential values are used for storing intermediate value and if pass the check, then it will pass the value to the bestBuyin or bestSell variables
            int bestBuyInPrice = stockPricesYesterday[0];
            int bestBuyInPriceIndex = 0;

            int potentialBestBuyInPrice = stockPricesYesterday[0];
            int potentialBestBuyInPriceIndex = 0;

            int bestSellPrice = 0;
            int bestSellPriceIndex = 1;

            int maxProfit = 0;

            for (int i = 0; i < stockPricesYesterday.Length; i++)
            {
                int potentialSellPrice = stockPricesYesterday[i];

                int potentialProfit = potentialSellPrice - potentialBestBuyInPrice;

                maxProfit = Math.Max(maxProfit, potentialProfit);
                //If current iteration is getting a maxProfit, then reassign the bestSell and bestBuy variables
                if (maxProfit == potentialProfit)
                {
                    bestSellPriceIndex = i;
                    bestSellPrice = potentialSellPrice;
                    bestBuyInPrice = potentialBestBuyInPrice;
                    bestBuyInPriceIndex = potentialBestBuyInPriceIndex;
                }

                //If current iteration has lowest price ever, then set the value to potentialBestBuy
                //We will need this as potential values since this could be false alarm, in the case of maxProfit was in the past of then lowest buy in prices through out the day
                potentialBestBuyInPrice = Math.Min(bestBuyInPrice, potentialSellPrice);

                if (potentialBestBuyInPrice == stockPricesYesterday[i])
                {
                    potentialBestBuyInPriceIndex = i;
                }
            }

            if (maxProfit == 0)
            {
                //Assumption: I assume that if market is bad today, then just return 0 to indicate such.
                var summary = new StockExchangeSummary(0, 0, 0, 0, 0);
                summary.SetNotes("Not a good day to trade.");
                return summary;
            }
            //Assumption: I assume we only need to provide one record of max profit, in case of multiple occurs, we just return the last one.
            return new StockExchangeSummary(maxProfit, bestBuyInPrice, bestBuyInPriceIndex, bestSellPrice, bestSellPriceIndex);
        }
    }
}

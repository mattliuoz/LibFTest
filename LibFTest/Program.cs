using System;

namespace LibFTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Assumption: Inputs are all integer, but I am aware that it is not likely to happen in real life.
            //This is just for demostrating how it works. I will make sure stockPricesYesterday is input from args if its for real life scenario 
            var stockPricesYesterday = new int[] { 10, 7, 5, 8, 11, 2, 5 };
            var maxStockExchangeSummary = MaxTradeCalculator.GetMaxProfit(stockPricesYesterday);
            Console.WriteLine($"maxProfit: {maxStockExchangeSummary.MaxProfit}");
            Console.WriteLine($"bestBuyInPrice:{maxStockExchangeSummary.BestBuyInPrice} at {maxStockExchangeSummary.BestBuyInPriceIndex}");
            Console.WriteLine($"bestSellPrice:{maxStockExchangeSummary.BestSellPrice} at {maxStockExchangeSummary.BestSellPriceIndex}");
        }
    }
}

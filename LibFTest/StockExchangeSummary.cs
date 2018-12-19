namespace LibFTest
{
    public class StockExchangeSummary
    {
        public int MaxProfit { get; }
        public int BestBuyInPrice { get; }
        public int BestBuyInPriceIndex { get; }
        public int BestSellPrice { get; }
        public int BestSellPriceIndex { get; }
        public string Notes { get; private set; }

        public StockExchangeSummary(int maxProfit, int bestBuyInPrice, int bestBuyInPriceIndex, int bestSellPrice, int bestSellPriceIndex)
        {
            MaxProfit = maxProfit;
            BestBuyInPrice = bestBuyInPrice;
            BestBuyInPriceIndex = bestBuyInPriceIndex;
            BestSellPrice = bestSellPrice;
            BestSellPriceIndex = bestSellPriceIndex;
        }

        public void SetNotes(string notes)
        {
            Notes = notes;
        }
    }
}

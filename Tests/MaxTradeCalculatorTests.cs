using LibFTest;
using System;
using Xunit;

namespace Tests
{
    public class MaxTradeCalculatorTests
    {
        [Fact]
        public void GetMaxProfit_should_return_summary_when_prices_are_in_timely_order_asc()
        {
            var stockPricesYesterday = new int[] { 2, 5, 7, 8, 10, 11 };

            var summary = MaxTradeCalculator.GetMaxProfit(stockPricesYesterday);

            Assert.Equal(2, summary.BestBuyInPrice);
            Assert.Equal(0, summary.BestBuyInPriceIndex);
            Assert.Equal(11, summary.BestSellPrice);
            Assert.Equal(5, summary.BestSellPriceIndex);
            Assert.Equal(9, summary.MaxProfit);
            Assert.Null(summary.Notes);
        }

        [Fact]
        public void GetMaxProfit_should_return_summary_with_notes_when_prices_are_in_timely_order_desc()
        {
            var stockPricesYesterday = new int[] {11,10,9,8,7 };

            var summary = MaxTradeCalculator.GetMaxProfit(stockPricesYesterday);

            Assert.Equal(0, summary.BestBuyInPrice);
            Assert.Equal(0, summary.BestBuyInPriceIndex);
            Assert.Equal(0, summary.BestSellPrice);
            Assert.Equal(0, summary.BestSellPriceIndex);
            Assert.Equal(0, summary.MaxProfit);
            Assert.Equal("Not a good day to trade.", summary.Notes);
        }

        [Fact]
        public void GetMaxProfit_should_return_exception_when_only_one_price()
        {
            var stockPricesYesterday = new int[] { 11};

            var exception = Assert.Throws<ArgumentException>(() => MaxTradeCalculator.GetMaxProfit(stockPricesYesterday));
            
            Assert.Equal("Stock prices should have at least two prices.", exception.Message);
        }

        [Fact]
        public void GetMaxProfit_should_return_exception_when_price_is_less_than_0()
        {
            var stockPricesYesterday = new int[] { 11, -1 };

            var exception = Assert.Throws<ArgumentException>(() => MaxTradeCalculator.GetMaxProfit(stockPricesYesterday));

            Assert.Equal("Stock prices contain some invalid value, it should never be 0.", exception.Message);
        }

        [Fact]
        public void GetMaxProfit_should_return_exception_when_price_is_0()
        {
            var stockPricesYesterday = new int[] { 11, 0 };

            var exception = Assert.Throws<ArgumentException>(() => MaxTradeCalculator.GetMaxProfit(stockPricesYesterday));

            Assert.Equal("Stock prices contain some invalid value, it should never be 0.", exception.Message);
        }
        [Fact]
        public void GetMaxProfit_should_return_summary_when_lowest_prices_are_in_the_end()
        {
            var stockPricesYesterday = new int[] { 7, 5,  11, 8, 10, 2};

            var summary = MaxTradeCalculator.GetMaxProfit(stockPricesYesterday);

            Assert.Equal(5, summary.BestBuyInPrice);
            Assert.Equal(1, summary.BestBuyInPriceIndex);
            Assert.Equal(11, summary.BestSellPrice);
            Assert.Equal(2, summary.BestSellPriceIndex);
            Assert.Equal(6, summary.MaxProfit);
            Assert.Null(summary.Notes);
        }


        [Fact]
        public void GetMaxProfit_should_return_summary_when_highst_prices_are_in_the_begining()
        {
            var stockPricesYesterday = new int[] { 11,5, 2, 8, 10};

            var summary = MaxTradeCalculator.GetMaxProfit(stockPricesYesterday);

            Assert.Equal(2, summary.BestBuyInPrice);
            Assert.Equal(2, summary.BestBuyInPriceIndex);
            Assert.Equal(10, summary.BestSellPrice);
            Assert.Equal(4, summary.BestSellPriceIndex);
            Assert.Equal(8, summary.MaxProfit);
            Assert.Null(summary.Notes);
        }

        [Fact]
        public void GetMaxProfit_should_return_last_summary_when_multiple_max_profit_occurs()
        {
            var stockPricesYesterday = new int[] { 11, 5, 2, 8, 10, 2, 8, 10 };

            var summary = MaxTradeCalculator.GetMaxProfit(stockPricesYesterday);

            Assert.Equal(2, summary.BestBuyInPrice);
            Assert.Equal(5, summary.BestBuyInPriceIndex);
            Assert.Equal(10, summary.BestSellPrice);
            Assert.Equal(7, summary.BestSellPriceIndex);
            Assert.Equal(8, summary.MaxProfit);
            Assert.Null(summary.Notes);
        }
    }

}

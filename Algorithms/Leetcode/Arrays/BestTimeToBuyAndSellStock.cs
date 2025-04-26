namespace Algorithms.DataStructures.Arrays;

public class BestTimeToBuyAndSellStock
{
    public int MaxProfit(int[] prices)
    {
        if (prices == null || prices.Length <= 1) return 0;

        var maxProfit = 0;
        var minPrice = prices[0];

        // 3, 2, 6, 5, 0, 3
        for (var i = 1; i < prices.Length; i++)
        {
            minPrice = Math.Min(minPrice, prices[i]);
            if (prices[i] - minPrice > maxProfit) maxProfit = prices[i] - minPrice;
        }

        return maxProfit;
    }
}
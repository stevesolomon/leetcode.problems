// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/528/week-1/3287/

public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices == null || prices.Length < 2) {
            return 0;
        }
        
        int maxProfit = 0;
        int purchasePrice = 0;
        bool buying = true;
        
        // Every day we need to consider first if we are buying or selling.
        // If we are buying, we won't buy until the next day's price goes up (we buy at the bottom).
        // If we are selling, we won't sell until the next day's price goes down (we sell at the top).
        for (int i = 0; i < prices.Length - 1; i++) {
            if (buying && prices[i + 1] > prices[i]) {
                purchasePrice = prices[i];
                buying = false;
            } else if (!buying && prices[i + 1] < prices[i]) {
                maxProfit += prices[i] - purchasePrice;
                buying = true;
            }
        }
        
        // On the last day, if we have to sell, let's sell.
        if (!buying) {
            maxProfit += prices[prices.Length - 1] - purchasePrice;
        }
        
        return maxProfit;
    }
}
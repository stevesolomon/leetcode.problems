// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/submissions/

public class Solution {
    private const int BUY = 0;
    private const int SELL = 1;
    private const int COOLDOWN = 2;
    
    public int MaxProfit(int[] prices) {
        if (prices == null || prices.Length < 2) {
            return 0;
        }
        
        // Stores best profits for each day covering what may have been our LAST
        // operation (buy, sell, or cooldown) at any time prior in history.
        int[,] lookup = new int[prices.Length + 1, 3];
        
        // Initialize our values
        lookup[0, BUY] = int.MinValue;
        lookup[0, SELL] = 0;
        lookup[0, COOLDOWN] = 0;
        
        for (int i = 1; i <= prices.Length; i++) {
            int currPrice = prices[i - 1];
            
            // If we're considering buying this day, then we have to have cooled down, so take the maximum
            // profit from the previous day's COOLDOWN, subtracting the price we're paying today.
            // (Alternatively, also consider the max profit we were in in the last day if we could BUY, perhaps
            //  it doesn't make sense to buy today at all either).
            lookup[i, BUY] = Math.Max(lookup[i - 1, BUY], lookup[i - 1, COOLDOWN] - currPrice);
            
            // For selling, just get the best profit when we last bought and add in the price.
            lookup[i, SELL] = lookup[i - 1, BUY] + currPrice;
            
            lookup[i, COOLDOWN] = Math.Max(lookup[i - 1, COOLDOWN], lookup[i - 1, SELL]);
        }
        
        int best = Math.Max(lookup[lookup.GetLength(0) - 1, SELL], lookup[lookup.GetLength(0) - 1, COOLDOWN]);
        
        return best < 0 ? 0 : best;
    }
}
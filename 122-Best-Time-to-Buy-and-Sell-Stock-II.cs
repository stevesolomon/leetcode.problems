// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/

public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices == null || prices.Length < 2) {
            return 0;
        }
        
        int maxProfit = 0;
        
        // Every day we can either be a buyer or a seller.
        //   - If we don't hold a stock we can be a buyer, but we only want to buy if
        //     the price tomorrow will be higher than the price today.
        //   - If we hold a stock we can be a seller, but we only want to sell if 
        //     the price tomorrow will be lower than the price today.
        bool canBuy = true;
        int pricePaid = 0;
        
        for (int day = 0; day < prices.Length - 1; day++) {
            if (canBuy && prices[day + 1] > prices[day]) {
                canBuy = false;
                pricePaid = prices[day];
            } else if (!canBuy) {
                if (prices[day + 1] < prices[day]) {
                    canBuy = true;
                    maxProfit += prices[day] - pricePaid;
                }
            }
        }
        
        // If we're still holding on the last day then sell
        if (!canBuy) {
            maxProfit += prices[prices.Length - 1] - pricePaid;
        }        
        
        return maxProfit;
    }
}
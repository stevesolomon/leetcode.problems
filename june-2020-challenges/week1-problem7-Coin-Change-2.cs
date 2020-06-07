// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3353/

public class Solution {
    public int Change(int amount, int[] coins) {
        if (coins == null ) {
            return 0;
        } else if (amount == 0) {
            return 1;
        }
        
        // Let's use a lookup table where each element i corresponds to the
        // number of combinations of coins we can use to create amount i.
        // We'll build this up iteration by iteration, where each iteration
        // adds on an additional coin.
        int[,] lookupAmts = new int[coins.Length + 1, amount + 1]; 
        
        // Seed no-change-required cases (amt = 0)
        for (int i = 0; i <= coins.Length; i++) {
            lookupAmts[i, 0] = 1;
        }
        
        // Seed use of 0 coins
        for (int i = 1; i <= amount; i++) {
            lookupAmts[0, i] = 0;
        }
        
        for (int coinIdx = 1; coinIdx <= coins.Length; coinIdx++) {
            
            // We can only use this particular coin at the moment.
            // Let's consider how many ways we can build up each amount.
            // We'll update each value based on values from the previous row (one less coin value)
            // Element[coinIdx, X], where X = Y - coins[coinIdx] is our lookup for
            // Element Y (as we can clearly use Element[coinIdx, X] coins to equal Y in 
            // addition to however many we could do for this amount with one less coin.
            for (int amt = 1; amt <= amount; amt++) {
                
                // We know we can build up at least this many without using the new coin.
                lookupAmts[coinIdx, amt] = lookupAmts[coinIdx - 1, amt];
                
                // If the current amount - currCoin is less than zero we clearly can't create
                // this amount with the current coin (it's too large).
                if (amt - coins[coinIdx - 1] >= 0) {
                    lookupAmts[coinIdx, amt] += lookupAmts[coinIdx, amt - coins[coinIdx - 1]];
                } 
            }
        }
        
        return lookupAmts[coins.Length, amount];        
    }
}
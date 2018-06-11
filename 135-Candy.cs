// https://leetcode.com/problems/candy/description/

public class Solution {
    public int Candy(int[] ratings) {
        int[] candies = new int[ratings.Length];
        
        // Every child must get at least one candy.
        for (int i = 0; i < ratings.Length; i++) {
            candies[i] = 1;
        }
        
        // Now go through each element...
        // If the next element is higher, we need to add one to the next element.
        for (int i = 0; i < ratings.Length - 1; i++) {
            if (ratings[i] < ratings[i + 1]) {
                candies[i + 1] = candies[i] + 1;
            }
        }
        
        // And then backwards to consider cases where the next element
        // is lower...
        for (int i = ratings.Length - 1; i > 0; i--) {
            if (ratings[i - 1] > ratings[i]) {
                candies[i - 1] = Math.Max(candies[i - 1], candies[i] + 1);
            }
        }
        
        int totalCandies = 0;
        
        for (int i = 0; i < ratings.Length; i++) {
            totalCandies += candies[i];
        }
        
        return totalCandies;
    }
}
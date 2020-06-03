// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3349/
// This solution can be improved by not using Math.Abs during sorting, allowing us to have half the list
// guaranteed to go to City A, and the other half to City B.

public class Solution {
    public int TwoCitySchedCost(int[][] costs) {
        if (costs == null || costs.Length == 0) {
            return 0;
        }
        
        // We want to first take the elements with the largest disparity in cost
        // and send these to the cheaper city. Then we'll work our way down 
        // in overall cost disparity.
        IEnumerable<int[]> sortedCosts = costs.ToList().OrderByDescending(a => Math.Abs(a[0] - a[1]));
        
        int totalCost = 0;
        int numToCityA = 0;
        int numToCityB = 0;
        int maxToCity = costs.Length / 2;        
        
        foreach (int[] cost in sortedCosts) {            
            if (numToCityA >= maxToCity) {
                totalCost += cost[1];
                numToCityB++;
            } else if (numToCityB >= maxToCity) {
                totalCost += cost[0];
                numToCityA++;
            } else if (cost[0] < cost[1]) {
                totalCost += cost[0];
                numToCityA++;
            } else {
                totalCost += cost[1];
                numToCityB++;
            }
        }
        
        return totalCost;
    }
}
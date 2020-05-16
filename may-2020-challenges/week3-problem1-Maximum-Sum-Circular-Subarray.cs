// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/536/week-3-may-15th-may-21st/3330/

public class Solution {
    public int MaxSubarraySumCircular(int[] A) {
        if (A == null || A.Length == 0) {
            return 0;
        } else if (A.Length == 1) {
            return A[0];
        }
        
        // We'll use a modification of Kadane's algorithm where
        // we look for both the max and min sums in the array,
        // as well as a total rolling sum.
        // Our end result is either the max sum that we found in the (non-circular) array,
        // or the total sum - the min sum.
        // Why? Because totalSum - minSum gives us a "circular" portion of the array
        // with the minimum portion cut out.
        int maxSum = int.MinValue;
        int currMaxSum = 0;
        
        int minSum = int.MaxValue;
        int currMinSum = 0;
        int totalSum = 0;
        
        foreach(int num in A)
        {
            currMaxSum = Math.Max(currMaxSum + num, num);
            maxSum = Math.Max(maxSum, currMaxSum);
            
            currMinSum = Math.Min(currMinSum + num, num);
            minSum = Math.Min(minSum, currMinSum);
            
            totalSum += num;
        }
        
        return maxSum > 0 ? Math.Max(maxSum, totalSum - minSum) : maxSum;
    }
}
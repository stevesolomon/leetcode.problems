// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/528/week-1/3285/

public class Solution {
    public int MaxSubArray(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return 0;
        } else if (nums.Length == 1) {
            return nums[0];
        }
        
        // Iterate through each element building up a running sum.
        // If our sum is < 0, reset back to 0 and start again from 
        // the next element (if we go below 0 there's no point in taking
        // anything prior as the next element will automatically give us
        // a higher starting "sum").
        int sum = 0;
        int bestSum = int.MinValue;
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
            
            bestSum = Math.Max(bestSum, sum);
            
            if (sum < 0) {
                sum = 0;
            }
        }
        
        return bestSum;        
    }
}
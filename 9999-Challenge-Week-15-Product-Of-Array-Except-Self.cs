// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/530/week-3/3300/

public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        if (nums == null || nums.Length == 1) {
            return nums;
        }
        
        int[] leftToRightPrefix = new int[nums.Length];
        int[] rightToLeftPrefix = new int[nums.Length];
        int[] results = new int[nums.Length];
        
        
        int leftToRightVal = 1;
        int rightToLeftVal = 1;
        for (int i = 0; i < nums.Length; i++) {
            leftToRightVal *= nums[i];
            rightToLeftVal *= nums[nums.Length - i - 1];
            
            leftToRightPrefix[i] = leftToRightVal;
            rightToLeftPrefix[nums.Length - i - 1] = rightToLeftVal;
        }
        
        // Our result at X is leftToRight[X-1] * rightToLeft[X+1]
        // 0 and len-1 are special cases we'll just handle directly.
        results[0] = rightToLeftPrefix[1];
        results[nums.Length - 1] = leftToRightPrefix[nums.Length - 2];
        
        for (int i = 1; i < nums.Length - 1; i++) {
            results[i] = leftToRightPrefix[i - 1] * rightToLeftPrefix[i + 1];
        }
        
        return results;
    }
}
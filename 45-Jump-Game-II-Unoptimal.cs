// https://leetcode.com/problems/jump-game-ii/description/
// This is an unoptimal O(n^2) solution.

public class Solution {
    public int Jump(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return -1;
        } else if (nums.Length == 1) {
            return 0;
        }
        
        int[] minHops = new int[nums.Length];
        minHops[nums.Length - 1] = 0;
        
        // Work our way backwards, figuring out the best number of hops
        // we can take at each stage.
        for (int i = nums.Length - 2; i >= 0; i--) {
            
            // If we have a 0, we can't go anywhere at all.
            if (nums[i] == 0) {
                minHops[i] = int.MaxValue;
                continue;
            }
            
            int range = nums[i];            
            int minVal = int.MaxValue;            
            
            for (int j = i + 1; j <= i + range && j < nums.Length; j++) {
                minVal = Math.Min(minVal, minHops[j]);
            }
            
            // (Make sure we don't have an int overflow if we can only jump
            //  to a position that has a 0).
            minHops[i] = minVal == int.MaxValue ? int.MaxValue : minVal + 1;
        }
        
        return minHops[0];
    }
}
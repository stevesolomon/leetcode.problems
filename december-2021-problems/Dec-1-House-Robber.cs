// https://leetcode.com/problems/house-robber/submissions/

public class Solution {
    public int Rob(int[] nums) {
        if (nums == null || nums.Length < 1) {
            return 0;
        } else if (nums.Length == 1) {
            return nums[0];
        }
        
        int[] lookup = new int[nums.Length];
        
        // Most profit considering just the first house is the first house's profit.
        lookup[0] = nums[0];
        
        // Most profit considering just the first two houses is the best of the two.
        lookup[1] = Math.Max(nums[0], nums[1]);
        
        // For all other houses, our best profit is either:
        //   Take from current house + best profit from two houses back
        //   Don't take from current house, therefore just the best profit from one house back
        for (int i = 2; i < nums.Length; i++) {
            lookup[i] = Math.Max(lookup[i - 1], nums[i] + lookup[i - 2]);
        }
        
        return lookup[nums.Length - 1];        
    }
}
// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/528/week-1/3283/

public class Solution {
    public int SingleNumber(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return 0;
        } else if (nums.Length == 1) {
            return nums[0];
        }
        
        // xor every element with each other. The remaining
        // value is our unmatched "pair".
        int val = nums[0];
        
        for (int i = 1; i < nums.Length; i++) {
            val ^= nums[i];
        }
        
        return val;        
    }
}
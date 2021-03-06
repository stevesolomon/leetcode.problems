// https://leetcode.com/problems/wiggle-subsequence/description/

public class Solution {
    public int WiggleMaxLength(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return 0;
        }
        
        int up = 1, down = 1;
        
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] > nums[i - 1]) {
                up = down + 1;
            } else if (nums[i] < nums[i - 1]) {
                down = up + 1;
            }
        }
        
        return up > down ? up : down;
    }
}
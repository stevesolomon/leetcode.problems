// https://leetcode.com/problems/jump-game/submissions/

public class Solution {
    public bool CanJump(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return false;
        }
        
        if (nums.Length == 1) {
            return true;
        }
        
        // We'll keep track of the furthest 'reach' our jumps could have
        // at each index. If this ever drops to 0 we can't make it.
        int reach = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            reach = Math.Max(reach, nums[i]);
            
            if (reach <= 0) {
                return false;
            }
            
            if (reach + i >= nums.Length - 1) {
                return true;
            }
            
            reach--;
        }
        
        return true;
    }
}
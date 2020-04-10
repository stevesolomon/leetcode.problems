// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/528/week-1/3286/

public class Solution {
    public void MoveZeroes(int[] nums) {
        if (nums == null || nums.Length < 2) {
            return;
        }
        
        int earliestZeroIdx = 0;
        int earliestNumIdx = 0;
        
        while (true) {
            
            // Find the earliest zero...
            while (earliestZeroIdx < nums.Length && nums[earliestZeroIdx] != 0) {
                earliestZeroIdx++;
            }
            
            earliestNumIdx = earliestZeroIdx + 1;
            
            // Now find the earliest num idx to swap with it
            while (earliestNumIdx < nums.Length && nums[earliestNumIdx] == 0) {
                earliestNumIdx++;
            }
            
            // Run out of numbers to swap...?
            if (earliestNumIdx >= nums.Length) {
                break;
            }
            
            // Swap them
            int temp = nums[earliestZeroIdx];
            nums[earliestZeroIdx] = nums[earliestNumIdx];
            nums[earliestNumIdx] = temp;
        }        
        
        return;        
    }
}
// https://leetcode.com/problems/non-decreasing-array/description/

public class Solution {
    public bool CheckPossibility(int[] nums) {
        if (nums == null || nums.Length <= 2) {
            return true;
        }
        
        int countNotDecreasing = 0;
        int countNotIncreasing = 0;
        
        int maxVal = nums[0];
        int minVal = nums[nums.Length - 1];
        
        // Check how many elements violate the constraint while moving forward.
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] < maxVal) {
                countNotIncreasing++;
            } else {
                maxVal = nums[i];
            }
        }
        
        // And then how many violate the reverse while going backwards...
        for (int i = nums.Length - 1; i >= 0; i--) {
            if (nums[i] > minVal) {
                countNotDecreasing++;
            } else {
                minVal = nums[i];
            }
        }
        
        // As long as only one element violated in either of the directions we can fix it.
        return countNotDecreasing <= 1 || countNotIncreasing <= 1;
    }
}
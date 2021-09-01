// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/617/week-5-august-29th-august-31st/3958/

public class Solution {
    public int FindMin(int[] nums) {
        if (nums == null || nums.Length == 0) {
            throw new ArgumentNullException(nameof(nums));
        }
        
        if (nums.Length == 1) {
            return nums[0];
        }
        
        if (nums.Length == 2) {
            return nums[0] < nums[1] ? nums[0] : nums[1];
        }
        
        // Perform a modified binary search.
        // - If nums[mid] < nums[mid-1] we've found our target.
        // - If our high is less than our mid, that tells us the 
        //   rotation is between mid and high.
        // - Otherwise, our rotation is between low and mid.
        int low = 0;
        int high = nums.Length - 1;
        
        while (low < high) {
            int mid = low + (high - low) / 2;
            
            if (mid != 0 && nums[mid] < nums[mid - 1]) {
                return nums[mid];
            }
            
            if (nums[high] < nums[mid]) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        
        return nums[low];
    }
}
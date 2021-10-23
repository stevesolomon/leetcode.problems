// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/

public class Solution {
    public int FindMin(int[] nums) {
        if (nums == null || nums.Length == 0) {
            throw new ArgumentException();
        } else if (nums.Length == 1) {
            return nums[0];
        }
        
        // We'll use a binary search to find the minimum value
        // Because the array is rotated, we have to modify the search
        // conditions when we decide which segment to investigate.
        int low = 0;
        int high = nums.Length - 1;
        
        while (low < high) {
            
            // If we hit a case where nums[low] < nums[high] we've clearly
            // reached an unrotated portion of the array in our search and, as a result
            // nums[low] is the smallest number
            if (nums[low] < nums[high]) {
                return nums[low];
            }
            
            int mid = low + (high - low) / 2;
            
            // We have a few cases we need to consider
            // (Remember that if we get this far low...high is rotated in some way otherwise we would have returned early above).
            //   nums[low] > nums[mid]
            //      --> The rotation must be present somewhere in low...mid
            //   nums[low] < nums[mid]
            //      --> We have good ordering from low...mid, so the rotation must be present somewhere in mid...high
            //   nums[low] == nums[mid]
            //      --> We have duplicate values across low...mid
            //         --> If nums[low] also == nums[high], reduce our search space by 1 on each side.
            //         --> Otherwise, search from mid+1...high as there's the non-duplicate section.
            if (nums[low] > nums[mid]) {
                high = mid;
            } else if (nums[low] < nums[mid]) {
                low = mid;
            } else {
                if (nums[low] == nums[high]) {
                    low++;
                    high--;
                } else {
                    low = mid + 1;
                }
            }
        }
        
        return nums[low];
    }
}
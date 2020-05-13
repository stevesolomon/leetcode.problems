// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3327/

public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return -1;
        } else if (nums.Length == 1) {
            return nums[0];
        }
        
        // Perform a modified binary search.
        // At every iteration, check if we have a duplicate
        // number to the right or left of our position. We can ignore
        // that duplicate in our divided search space.
        // But... how do we choose which side to search?
        // We know that we've removed 2 elements from the search space (the 2 dupes)
        // Therefore the single element must be in the remaining n - 2 elements, and n is
        // of odd length. 
        // Therefore either the right or left side of the remaining search space will be
        // even (containing only pairs of dupes) and the other odd in size (pairs of dupes + unique).
        // We only need bother to search the odd side as it must have the unique num.
        int low = 0;
        int high = nums.Length - 1;
        
        while (low < high) {
            int mid = low + ((high - low) / 2);
            
            // Handle edges of the array - clearly we've found the unique number.
            if (mid == 0 || mid == nums.Length - 1) {
                return nums[mid];
            }
            
            // Is our pair to our left...?
            if (nums[mid - 1] == nums[mid]) {
                // Then our search space is either [low...mid-2] or [mid+1...high]
                int rightSize = high - mid;
                if (rightSize % 2 == 0) {
                    // Lower side is odd length
                    high = mid - 2;
                } else {
                    // Higher side is odd length
                    low = mid + 1;
                }
            } else if (nums[mid] == nums[mid + 1]) {
                // Then our search space is either [mid+2...high] or [low...mid-1]
                int rightSize = high - mid - 1;
                if (rightSize % 2 == 0) {
                    // Lower side is odd length
                    high = mid - 1;
                } else {
                    // Higher side is odd length
                    low = mid + 2;
                }
            } else {
                // Found no duplicate. We have our element!
                return nums[mid];
            }
        }
        
        return nums[low];
    }
}
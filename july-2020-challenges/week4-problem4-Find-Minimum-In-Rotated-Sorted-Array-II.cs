// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/547/week-4-july-22nd-july-28th/3401/

public class Solution {
    public int FindMin(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return int.MinValue;
        } else if (nums.Length == 1) {
            return nums[0];
        }
        
        // Perform a modified binary search.
        // We need to find the pivot point, which is the point in the array
        // where nums[i] < nums [i - 1].    
        int lo = 0;
        int hi = nums.Length - 1;
        
        while (lo < hi) {
            
            int mid = lo + ((hi - lo) / 2);
            
            // Base case: no rotation in the minimum candidate portion, so we're done!
            if (nums[lo] < nums[hi]) {
                return nums[lo];
            }
            
            // Otherwise, we have a few cases:
            // (1) lo > mid, meaning the rotation is somewhere in lo->mid
            // (2) lo < mid, meaning the pivot is somewhere in mid->hi
            // (3) lo == mid:
            //        - If lo == hi as well, we have to narrow our scope
            //        - Otherwise just search mid->hi
            if (nums[lo] > nums[mid]) {
                hi = mid; // Not -1 because lo > mid, so we can't discount mid here as the min val.
            } else if (nums[lo] < nums[mid]) {
                lo = mid + 1; // +1 because lo < mid, so mid is no longer in the running as a min val.
            } else {
                if (nums[lo] == nums[hi]) {
                    // Just narrow the scope of our search as we have duplicate values.
                    lo++;
                    hi--;
                } else {
                    // lo != hi, and lo == mid, which implies the pivot must be on the hi side.
                    lo = mid + 1;
                }
            }
            
        }
               
        return nums[lo];
    }
}
// https://leetcode.com/problems/longest-increasing-subsequence/description/

public class Solution {
    public int LengthOfLIS(int[] nums) {
        
        if (nums == null || nums.Length == 0) {
            return 0;
        } else if (nums.Length == 1) {
            return 1;
        }
        
        int longest = 0;
        int[] lengthLookup = new int[nums.Length];
        
        for (int i = 0; i < lengthLookup.Length; i++) {
            lengthLookup[i] = 1;
        }
        
        // Start our subsequence at every element after the first  
        // We're going to build up our length lookup table by testing
        // if this num is less than each number before it in order to build
        // up the longest sub-sequences possible at each position.
        for (int i = 1; i < nums.Length; i++) {   
            
            for (int j = 0; j < i; j++) {
                // Don't update our length lookup if the current length is greater than
                // what we'd get if we took the lookup at j + 1.
                if (nums[i] > nums[j] && lengthLookup[i] <= lengthLookup[j]) {
                    lengthLookup[i] = lengthLookup[j] + 1;
                }
            }
        }    
        
        for (int i = 0; i < lengthLookup.Length; i++) {
            if (lengthLookup[i] > longest) {
                longest = lengthLookup[i];
            }
        }
        
        return longest;
    }
}
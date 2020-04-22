// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/529/week-2/3298/

public class Solution {
    public int FindMaxLength(int[] nums) {
        if (nums == null || nums.Length < 2) {
            return 0;
        }
        
        // Let's generate a special prefix-sum.
        // 1's increase the sum by 1 at each element.
        // 0's decrease by 1 at each element.
        // We store this in a Dictionary where the key is the prefix sum
        // and the value the index we first saw it.
        // If we find a matching key in the Dictionary we have a contiguous
        // array with matching #s of 0s and 1s. 
        // Why...? In order to go from a prefix sum of, say, 3 back to 3
        // X elements later, we must have had equal numbers of +1 and -1s!
        Dictionary<int, int> prefixSums = new Dictionary<int, int>();
        prefixSums.Add(0, -1); // Initial entry for entire array as we start at 0.
        
        int sum = 0;
        int longest = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i] == 0 ? -1 : 1;
            
            if (prefixSums.ContainsKey(sum)) {
                longest = Math.Max(longest, i - prefixSums[sum]);
            } else {
                prefixSums.Add(sum, i);
            }
        }
        
        return longest;
    }
}
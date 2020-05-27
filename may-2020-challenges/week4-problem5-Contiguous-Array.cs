// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/537/week-4-may-22nd-may-28th/3341/

public class Solution {
    public int FindMaxLength(int[] nums) {
        if (nums == null || nums.Length < 2) {
            return 0;
        }
        
        // Let's build up a special prefix sum where at each element
        // a '1' adds 1 to the sum, and a '0' subtracts 1.
        // In essence, any subarray with an equal number of 1's and 0's from, say,
        // [i..j] must have a prefix sum where sum(i-1) == sum(j).
        // Why sum(i-1)? Because if there are an equal numbers of 1s and 0s from [i..j]
        // that implies that the total contribution of that subarray to the prefix sum is 0,
        // so we end up with the same number we had coming into the subarray (at sum(i-1)).
        // So how do we find these...? We can use a Dictionary to store first-seen
        // indices for prefix sums and use that to look up later occurrences.
        Dictionary<int, int> lookup = new Dictionary<int, int>();
        int prefixSum = 0;
        int longestFound = 0;
        
        lookup.Add(0, -1);
        
        for (int i = 0; i < nums.Length; i++) {
            prefixSum += nums[i] == 1 ? 1 : -1;
            
            if (!lookup.ContainsKey(prefixSum)) {
                lookup.Add(prefixSum, i);
            } else {
                int length = i - lookup[prefixSum];
                longestFound = Math.Max(longestFound, length);
            }
        }
        
        return longestFound;
    }
}
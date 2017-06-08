// https://leetcode.com/problems/subarray-sum-equals-k/#/description

public class Solution {
    public int SubarraySum(int[] nums, int k) {
        
        int[] prefixSums = new int[nums.Length];
        Dictionary<int, List<int>> prefixSumLookup = new Dictionary<int, List<int>>();
        
        int sum = 0;
        int totalSets = 0;
        
        // Calculate the prefix sums and store them
        // Store them in a dictionary as well for faster lookup later.
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
            
            prefixSums[i] = sum;
            
            if (!prefixSumLookup.ContainsKey(sum)) {
                prefixSumLookup.Add(sum, new List<int>());
            }
            
            prefixSumLookup[sum].Add(i);
        }
        
        for (int i = 0; i < nums.Length; i++) {
            // Figure out what kind of value we need in order to hit the target.
            int valueNeeded = prefixSums[i] - k;
            
            // If we have the value already this is a set.
            if (valueNeeded == 0) {
                totalSets++;
            } 
            
            // Also check if we have this in the Dictionary for more sets...
            if (prefixSumLookup.ContainsKey(valueNeeded)) {
                // We do!
                // Are any of the elements listed less than our current element?
                // If so, they form a set!
                foreach (int index in prefixSumLookup[valueNeeded]) {
                    if (index < i) {
                        totalSets++;
                    }
                }
            }
        }
        
        return totalSets;
    }
}
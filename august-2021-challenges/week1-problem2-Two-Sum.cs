// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/613/week-1-august-1st-august-7th/3836/

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        if (nums == null || nums.Length < 2) {
            return new int[2];
        }
        
        int[] result = new int[2];
        
        // Stores a number we still need to reach the target, along with
        // one of the indices used.
        Dictionary<int, int> remainder = new Dictionary<int, int>();
        
        for (int i = 0; i < nums.Length; i++) {
            
            // We found a pair that gets us to the target.
            if (remainder.ContainsKey(nums[i])) {
                result[0] = remainder[nums[i]];
                result[1] = i;
                return result;
            }
            
            // Add target - nums[i] to the dict. as this is
            // the next number we need to actually hit the target.
            int val = target - nums[i];
            
            // We only need to return one pair of indices, so we don't
            // care about storing all indices with this remainder value.
            if (!remainder.ContainsKey(val)) {
                remainder.Add(val, i);
            }
        }
        
        return result;        
    }
}
// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/640/week-5-september-29th-september-30th/3993/

public class Solution {
    public bool CanPartitionKSubsets(int[] nums, int k) {
        if (nums == null || nums.Length < k) {
            return false;
        }
        
        // Quick check: for a solution at all, sum(nums) % k == 0
        int sum = 0;
        foreach (int num in nums) {
            sum += num;
        }
        
        if (sum % k != 0) {
            return false;
        }
        
        // Otherwise, we'll just use a greedy backtracking algorithm
        // that keeps trying to build up each k set.
        bool[] used = new bool[nums.Length];
        
        return CanPartitionKSubsets(nums, used, 0, sum / k, sum / k, k);            
    }
    
    private bool CanPartitionKSubsets(int[] nums, bool[] used, int index, int remaining, int target, int k) {
        if (k == 0) {
            return true;
        }
        
        if (remaining == 0) {
            return CanPartitionKSubsets(nums, used, 0, target, target, k - 1);
        }
        
        if (remaining < 0 || index >= nums.Length) {
            return false;
        }
        
        for (int i = index; i < nums.Length; i++) {
            if (used[i]) {
                continue;
            }
            
            // Try taking nums[i].
            used[i] = true;
            
            bool success = CanPartitionKSubsets(nums, used, i + 1, remaining - nums[i], target, k);
            
            if (success) {
                return true;
            }
            
            used[i] = false;
        }
        
        return false;
    }
}
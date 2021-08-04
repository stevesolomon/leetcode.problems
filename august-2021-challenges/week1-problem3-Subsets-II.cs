// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/613/week-1-august-1st-august-7th/3837/

public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        IList<IList<int>> results = new List<IList<int>>();
        if (nums == null || nums.Length == 0) {
            return results;
        }
        
        Array.Sort(nums);
        
        GeneratePowerSet(nums, 0, new List<int>(), results);
        
        return results;
    }
    
    private void GeneratePowerSet(int[] nums, int idx, List<int> currResult, IList<IList<int>> results) {
        
        results.Add(new List<int>(currResult));
        
        if (idx >= nums.Length) {
            return;
        }
        
        // Try all numbers from here on up.
        for (int i = idx; i < nums.Length; i++) {
            
            // Check for the same number..
            if (i > idx && nums[i] == nums[i - 1]) {
                continue;
            }
            
            currResult.Add(nums[i]);
            GeneratePowerSet(nums, i + 1, currResult, results);
            currResult.RemoveAt(currResult.Count - 1);            
        }
    }
}
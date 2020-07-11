// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/545/week-2-july-8th-july-14th/3387/

public class Solution {
    
    private List<IList<int>> results = new List<IList<int>>();
    
    public IList<IList<int>> Subsets(int[] nums) {
        if (nums == null) {
            return new List<IList<int>>();
        }
        
        // For each element in nums, we can consider taking it, or not taking it.
        // Every possible step therein will generate a unique set.
        GenerateSubsets(nums, 0, new List<int>());
        
        return results;        
    }
    
    private void GenerateSubsets(int[] nums, int idx, List<int> curr) {
        
        // Out of numbers to choose? We have a set.
        if (idx >= nums.Length) {
            results.Add(new List<int>(curr));
            return;
        }
        
        // Generate all sets without the current number...
        GenerateSubsets(nums, idx + 1, curr);
        
        // And then all sets with the current number...
        curr.Add(nums[idx]);
        GenerateSubsets(nums, idx + 1, curr);
        
        // And then finally clean up after ourselves...
        curr.RemoveAt(curr.Count - 1);
    }
}
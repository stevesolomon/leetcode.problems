// https://leetcode.com/problems/subsets-ii/description/

public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return new List<IList<int>> { new List<int>(nums) };
        }
        
        List<IList<int>> results = new List<IList<int>>();
        HashSet<string> cachedResults = new HashSet<string>();
        SortedDictionary<int, int> intCounts = new SortedDictionary<int, int>();
        
        GeneratePerms(results, cachedResults, intCounts, new List<int>(), nums, 0);
        
        return results;
    }
    
    private void GeneratePerms(
        List<IList<int>> results,
        HashSet<string> cachedResults,
        SortedDictionary<int, int> intCounts,
        List<int> currResult,
        int[] nums,
        int idx) {
        
        // If we're at the end of the set of nums, add this permutation to our
        // result set as long as we haven't seen it before.
        if (idx == nums.Length) {
            string key = GenerateIntCountsString(intCounts);
            
            if (!cachedResults.Contains(key)) {
                cachedResults.Add(key);
                
                results.Add(new List<int>(currResult));
            }
            
            return;
        }
        
        // Otherwise, consider adding and not adding the current number.
        GeneratePerms(results, cachedResults, intCounts, currResult, nums, idx + 1);
        
        currResult.Add(nums[idx]);
        
        if (!intCounts.ContainsKey(nums[idx])) {
            intCounts.Add(nums[idx], 0);
        }
        
        intCounts[nums[idx]]++;
        
        GeneratePerms(results, cachedResults, intCounts, currResult, nums, idx + 1);
        currResult.RemoveAt(currResult.Count - 1);
        intCounts[nums[idx]]--;
    }
    
    public string GenerateIntCountsString(SortedDictionary<int, int> intCounts) {
        StringBuilder sb = new StringBuilder();
        
        foreach (int key in intCounts.Keys) {
            if (intCounts[key] > 0) {
                sb.Append(key);
                sb.Append(intCounts[key]);
            }
        }
        
        return sb.ToString();
    }
}
// https://leetcode.com/problems/permutations-ii/description/

public class Solution {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        List<IList<int>> results = new List<IList<int>>();
        
        if (nums == null || nums.Length == 0) {
            return results;
        } else if (nums.Length == 1) {
            results.Add(new List<int> { nums[0] });
            return results;
        }        
        
        // First, build up a dictionary of every unique num and the
        // number of times it has appeared.
        Dictionary<int, int> numCounts = new Dictionary<int, int>();
        
        foreach (int num in nums) {
            if (!numCounts.ContainsKey(num)) {
                numCounts.Add(num, 0);
            }
            
            numCounts[num]++;
        }
        
        // Then, build up our permutation set.
        int totalNums = nums.Length;
        List<int> currResult = new List<int>();
        BuildPermutations(results, currResult, numCounts, 0, totalNums);
        
        return results;
    }
    
    private void BuildPermutations(
        List<IList<int>> results,
        List<int> currResult,
        Dictionary<int, int> numCounts,
        int currStep,
        int totalSteps) {
        
        if (currStep == totalSteps) {
            results.Add(new List<int>(currResult));
            return;
        }
        
        // At every step, iterate through all keys in numCounts where the value 
        // is at least 1, and BuildPermutations from it.
        foreach (int key in numCounts.Keys.ToList()) {
            if (numCounts[key] == 0) {
                continue;
            }
            
            currResult.Add(key);
            numCounts[key]--;
            
            BuildPermutations(results, currResult, numCounts, currStep + 1, totalSteps);
            
            // Don't forget to reset the value before moving on!
            numCounts[key]++;
            currResult.RemoveAt(currResult.Count - 1);
        }
    }
}
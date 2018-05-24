// https://leetcode.com/problems/combination-sum/description/

public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        
        IList<IList<int>> results = new List<IList<int>>();
        
        if (candidates == null || candidates.Length == 0) {
            return results;
        }
        
        // First remove any duplicates from the input, as well as
        // numbers that are too large, and get a sorted list.
        HashSet<int> valsSeen = new HashSet<int>();
        List<int> vals = new List<int>();
        
        foreach (int candidate in candidates) {
            if (!valsSeen.Contains(candidate) && candidate <= target) {
                valsSeen.Add(candidate);
                vals.Add(candidate);
            }
        }
        
        vals.Sort();     
        
        // ref to make it very clear that we'll be modifying the list
        BuildSolution(ref results, new List<int>(), vals, 0, target);
        
        return results;
    }
    
    private void BuildSolution(ref IList<IList<int>> results,
                               IList<int> tempResult, 
                               IList<int> candidates,
                               int startIdx,
                               int target) {
        if (target < 0) {
            return;
        } else if (target == 0) {
            results.Add(new List<int>(tempResult));
        } else {
            for (int i = startIdx; i < candidates.Count; i++) {
                tempResult.Add(candidates[i]);
                
                BuildSolution(ref results, tempResult, candidates, i, target - candidates[i]);
                
                tempResult.Remove(candidates[i]);
            }
        }        
    }
}
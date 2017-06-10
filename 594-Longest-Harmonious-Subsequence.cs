// https://leetcode.com/problems/longest-harmonious-subsequence/#/description

public class Solution {
    public int FindLHS(int[] nums) {
        
        if (nums == null || nums.Length < 2) {
            return 0;
        }
        
        Dictionary<int, int> numCounts = new Dictionary<int, int>();
        
        foreach (int num in nums) {
            if (!numCounts.ContainsKey(num)) {
                numCounts.Add(num, 0);
            }
            
            numCounts[num]++;
        }
        
        int longestSequence = 0;
        
        foreach (int key in numCounts.Keys) {
            if (numCounts.ContainsKey(key + 1)) {
                int length = numCounts[key] + numCounts[key + 1];
                
                longestSequence = length > longestSequence ? length : longestSequence;
            }
        }
        
        return longestSequence;
    }
}
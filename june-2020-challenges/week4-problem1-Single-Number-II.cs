// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/542/week-4-june-22nd-june-28th/3368/
// Note this solution does not use constant memory.

public class Solution {
    public int SingleNumber(int[] nums) {
        if (nums == null || nums.Length < 1) {
            return -1;
        }
        
        Dictionary<int, int> counts = new Dictionary<int, int>();
        
        foreach (var num in nums) {
            if (!counts.ContainsKey(num)) {
                counts.Add(num, 0);
            }
            
            counts[num]++;
        }
        
        foreach (var kvp in counts) {
            if (kvp.Value == 1) {
                return kvp.Key;
            }
        }
        
        return -1;
    }
}
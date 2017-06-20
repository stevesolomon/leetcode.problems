// https://leetcode.com/problems/single-number-ii/#/solutions

public class Solution {
    public int SingleNumber(int[] nums) {
        Dictionary<int, int> counts = new Dictionary<int, int>();
        
        foreach (var num in nums) {
            if (!counts.ContainsKey(num)) {
                counts.Add(num, 0);
            }
            
            counts[num]++;
        }
        
        return counts.Where(d => d.Value == 1).First().Key;
    }
}
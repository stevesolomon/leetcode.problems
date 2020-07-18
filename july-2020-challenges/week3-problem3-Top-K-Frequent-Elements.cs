// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/546/week-3-july-15th-july-21st/3393/

public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {        
        if (nums == null || nums.Length < k || k == 0) {
            return new int[0];
        }
        
        int[] results = new int[k];
        Dictionary<int,int> lookup = new Dictionary<int, int>();
        
        foreach (var num in nums) {
            if (!lookup.ContainsKey(num)) {
                lookup.Add(num, 0);
            }
            
            lookup[num]++;
        }
                
        foreach (var val in lookup.OrderByDescending(l => l.Value)) {
            if (k == 0) {
                break;
            }
            
            results[k - 1] = val.Key;
            k--;
        }
        
        return results;
    }
}
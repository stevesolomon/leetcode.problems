// https://leetcode.com/problems/delete-and-earn/description/

public class Solution {
    public int DeleteAndEarn(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return 0;
        }        
        
        Dictionary<int, int> numCounts = new Dictionary<int, int>();
        int minValue = int.MaxValue;
        int maxValue = int.MinValue;
        
        foreach (int num in nums) {
            if (!numCounts.ContainsKey(num)) {
                numCounts.Add(num, 0);
                minValue = Math.Min(minValue, num);
                maxValue = Math.Max(maxValue, num);
            }
            
            numCounts[num]++;
        }
        
        // We start with our minValue as our curr value, and initialize
        // it with the total value as if we took all the nums of minValue.
        int last = 0;
        int curr = numCounts[minValue] * minValue;
        
        for (int i = minValue + 1; i <= maxValue; i++) {
            int temp = curr;
            
            // Our new best is either the last value we had + the current index's value
            // or our "current" value.
            // The former implies we took "odds", and the latter "evens".
            curr = Math.Max(last + (numCounts.ContainsKey(i) ? numCounts[i] : 0) * i, curr);
            last = temp;
        }
        
        return curr;        
    }
}
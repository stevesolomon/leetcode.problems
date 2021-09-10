// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/637/week-2-september-8th-september-14th/3970/

public class Solution {
    public int NumberOfArithmeticSlices(int[] nums) {
        
        if (nums == null || nums.Length < 3) {
            return 0;
        }
        
        // For this problem we'll use a 1D lookup array where element i
        // corresponds to considering only elements 0...i in nums.
        // Each lookup entry will contain a Dictionary where the:
        //    Key => A difference between 2 values in subarray 0..i
        //    Value => How many times that difference was observed in the subarray
        List<Dictionary<long, int>> lookup = new List<Dictionary<long, int>>();
        int result = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            lookup.Add(new Dictionary<long, int>());
            
            for (int j = 0; j < i; j++) {
                long currDiff = (long) nums[i] - (long) nums[j];
                
                if (!lookup[i].ContainsKey(currDiff)) {
                    lookup[i].Add(currDiff, 0);
                }
                
                lookup[i][currDiff]++;
                
                // Now... from 0...j (where j < i) did we also see this difference?
                // If so, that implies we can include i in all of those possible subsequences.
                if (lookup[j].ContainsKey(currDiff)) {
                    lookup[i][currDiff] += lookup[j][currDiff];
                    
                    // And we want to include this count in our result.
                    // But ONLY if we get this match in j.
                    // Why? Because if the 0...j subarray also had two numbers where the difference
                    //      was currDiff, then with nums[i] we can form a subsequence.
                    result += lookup[j][currDiff];
                }                
            }
        }
        
        return result;        
    }
}
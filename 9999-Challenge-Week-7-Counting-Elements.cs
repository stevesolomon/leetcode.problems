// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/528/week-1/3289/

public class Solution {
    public int CountElements(int[] arr) {
        if (arr == null || arr.Length < 2) {
            return 0;
        }
        
        // We will use a HashSet to store unmatched (lower) numbers.
        HashSet<int> toMatch = new HashSet<int>();
        
        int totalCount = 0;
        
        // Loop once to generate our dictionary.
        foreach (var val in arr) {
            if (!toMatch.Contains(val)) {
                toMatch.Add(val);
            }
        }
        
        // Loop a second time to decide which matches we have
        foreach (var val in arr) {
            if (toMatch.Contains(val + 1)) {
                totalCount++;
            }
        }       
        
        return totalCount;
    }
}
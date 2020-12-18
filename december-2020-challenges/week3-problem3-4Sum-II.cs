// https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/571/week-3-december-15th-december-21st/3569/

public class Solution {
    public int FourSumCount(int[] A, int[] B, int[] C, int[] D) {
        if (A == null || B == null || C == null || D == null) {
            return 0;
        } else if (A.Length < 1 || B.Length < 1 || C.Length < 1 || D.Length < 1) {
            return 0;
        }
        
        Dictionary<int, int> partials = new Dictionary<int, int>();
        
        // Compute partial/first half tuple values and store them in a dictionary.
        // Make sure we keep track of how many of each partial value we've found, as
        // each instance will represent a unique tuple in the end.
        foreach (var aVal in A) {
            foreach (var bVal in B) {
                int partialVal = aVal + bVal;
                
                if (!partials.ContainsKey(partialVal)) {
                    partials.Add(partialVal, 0);
                }
                
                partials[partialVal]++;
            }
        }
        
        int totalTuples = 0;
        
        // Now compute the partial/second-half tuple values and try to map them
        // to the values we computes in the first half.
        foreach (var cVal in C) {
            foreach (var dVal in D) {
                int partialVal = cVal + dVal;
                
                if (partials.ContainsKey(-partialVal)) {
                    totalTuples += partials[-partialVal];
                }
            }
        }
        
        return totalTuples;
    }
}
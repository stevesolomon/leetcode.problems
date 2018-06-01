// https://leetcode.com/problems/4sum-ii/description/

public class Solution {
    public int FourSumCount(int[] A, int[] B, int[] C, int[] D) {
        
        int total = 0;
        
        if (A == null || B == null || C == null || D == null || A.Length == 0) {
            return total;
        }
        
        // We need to use a dictionary to store the targets, not a HashSet,
        // as we may have duplicate values for -(a + b) and, if so, we need
        // to consider each one in turn when we find a (c + d) pair that 
        // hits the target.
        Dictionary<int, int> targets = new Dictionary<int, int>();
        
        // First, iterate through all possible combinations of (A,B) and store
        // the (negative) value in a HashSet.
        foreach (int a in A) {
            foreach (int b in B) {
                int val = -(a + b);
                if (!targets.ContainsKey(val)) {
                    targets.Add(val, 0);
                }
                
                targets[val]++;
            }
        }
        
        // Now, iterate through all possible combinations of (C,D) looking for
        // matching values
        foreach (int c in C) {
            foreach (int d in D) {
                int val = c + d;
                
                if (targets.ContainsKey(val)) {
                    total += targets[val];
                }
            }
        }
        
        return total;        
    }
}
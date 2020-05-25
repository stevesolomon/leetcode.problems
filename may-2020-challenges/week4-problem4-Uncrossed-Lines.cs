// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/537/week-4-may-22nd-may-28th/3340/

public class Solution {
    public int MaxUncrossedLines(int[] A, int[] B) {
        if (A == null || A.Length == 0 || B == null || B.Length == 0) {
            return 0;
        }
        
        // Lookup[a,b] stores how many lines we can form given A[0..a] and B[0..b].
        int [,] lookup = new int[A.Length, B.Length];
        
        // Prefill lookups where A or B are only single elements.
        for (int i = 0; i < A.Length; i++) {
            // If the current A element equals B[0], then we know we have a guaranteed line.
            // If not, take the previous lookup value for A[i-1] and B[0].
            lookup[i,0] = A[i] == B[0] ? 1 : i > 0 ? lookup[i-1, 0] : 0;
        }
        
        for (int i = 0; i < B.Length; i++) {
            lookup[0,i] = A[0] == B[i] ? 1 : i > 0 ? lookup[0, i-1] : 0;
        }
        
        // Now go through the rest of the A, B length combinations.
        // At every step, if A[a] == B[b] we know we can, guaranteed, add one more
        // line than we could with A[0..a-1], B[0..b-1] as this line is on the edge of the "front"
        // we are growing through A and B.
        // If they are not equal then we can still form the same number of lines as we could with
        // either A[0..a-1], B[0..b], or A[0..a], B[0..b-1] subarrays..
        for (int a = 1; a < A.Length; a++) {
            for (int b = 1; b < B.Length; b++) {
                if (A[a] == B[b]) {
                    lookup[a,b] = lookup[a - 1, b - 1] + 1;
                } else {
                    lookup[a,b] = Math.Max(lookup[a, b - 1], lookup[a - 1, b]);
                }
            }
        }
        
        return lookup[A.Length - 1, B.Length - 1];
    }
}
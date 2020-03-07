// https://leetcode.com/problems/maximum-width-ramp/

public class Solution {
    public int MaxWidthRamp(int[] A) {
        if (A == null || A.Length < 2) {
            return 0;
        }
        
        // Traverse the array from left-to-right and build up a set of indices corresponding to 
        // decreasing values in the array.
        // Why do we only care about decreasing values? Because we're searching for candidate starting indices
        // and any *higher* value we find is guaranteed to form a suboptimal solution (as we could have used a previous lower value).
        // *Lower* values, on the other hand, may give us more options for matching and should still be considered.
        Stack<int> decreasingIndices = new Stack<int>();        
        
        for (int i = 0; i < A.Length; i++) {
            if (decreasingIndices.Count == 0 || A[i] < A[decreasingIndices.Peek()]) {
                decreasingIndices.Push(i);
            }
        }
        
        int bestLen = 0;
        
        // Now traverse the array from right-to-left. These are our candidate ending indices. At each one, let's match them
        // against our candidate starting indices as far to the "left" (bottom of the stack) as we can.
        // We can obviously pop the matched values from the stack, as any subsequent values we test against them, even if
        // matching, will form a suboptimal solution (as we're traversing right-to-left here and our candidate ending index is decreasing).
        for (int i = A.Length - 1; i >= 0; i--) {
            
            while (decreasingIndices.Count > 0 && A[i] >= A[decreasingIndices.Peek()]) {
                var leftIdx = decreasingIndices.Pop();
                
                bestLen = Math.Max(bestLen, i - leftIdx);
            }
            
            if (decreasingIndices.Count == 0) {
                break;
            }
        }
        
        return bestLen;   
    }
}
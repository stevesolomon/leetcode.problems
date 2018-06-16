// https://leetcode.com/problems/max-chunks-to-make-sorted/description/

public class Solution {
    public int MaxChunksToSorted(int[] arr) {
        
        if (arr == null || arr.Length == 0 || arr.Length == 1) {
            return 1;
        }
        
        int max = int.MinValue;
        int numChunks = 0;
        
        for (int i = 0; i < arr.Length; i++) {
            max = Math.Max(max, arr[i]);
            
            // As soon as we find a maximum value in our current chunk that
            // matches the element index, we can close this chunk off.
            // (as this implies that the largest value thus far is this one, and it
            // matches the current element index, meaning we can sort everything before
            // it and expect a perfectly matched up chunk).
            if (max == i) {
                numChunks++;
            }
        }
        
        return numChunks;
    }
}
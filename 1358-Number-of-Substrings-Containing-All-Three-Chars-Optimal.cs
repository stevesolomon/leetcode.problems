// https://leetcode.com/problems/number-of-substrings-containing-all-three-characters/submissions/
// Unlike my initial solution this uses lookup arrays storing the next closest index for each character at every position.

public class Solution {
    public int NumberOfSubstrings(string s) {
        
        if (string.IsNullOrWhiteSpace(s) || s.Length < 3) {
            return 0;
        }
        
        int len = s.Length;
        
        // First build an array for each character.
        // Each element in the array stores the next closest index (>= curr idx only) 
        // containing this character.
        int[] aIdx = new int[len];
        int[] bIdx = new int[len];
        int[] cIdx = new int[len];    
        
        aIdx[len-1] = s[len-1] == 'a' ? len-1 : -1;
        bIdx[len-1] = s[len-1] == 'b' ? len-1 : -1;
        cIdx[len-1] = s[len-1] == 'c' ? len-1 : -1;
        
        for (int i = s.Length - 2; i >= 0; i--) {
            char c = s[i];
            
            switch (c) {
                case 'a':
                    aIdx[i] = i;
                    bIdx[i] = bIdx[i + 1];
                    cIdx[i] = cIdx[i + 1];
                    break;
                case 'b':
                    aIdx[i] = aIdx[i + 1];
                    bIdx[i] = i;
                    cIdx[i] = cIdx[i + 1];
                    break;
                case 'c':
                default:
                    aIdx[i] = aIdx[i + 1];
                    bIdx[i] = bIdx[i + 1];
                    cIdx[i] = i;
                    break;
            }
        }
        
        // Now, go through every starting index in the string. What we are looking for is the 
        // first indices for each of the letters after (or on) this starting index. This tells us the
        // smallest size of the subset we can construct starting from i, say, i...j.
        // We can then add every i...j+k for k = 0 to s.Length - i (or simply add s.Length - j to the return value).
        int totalSubstrings = 0;
        
        for (int i = 0; i < s.Length - 2; i++) {
            
            // The earliest occurrence of each character is described by index i
            // in their respective arrays.
            int aBest = aIdx[i];
            int bBest = bIdx[i];
            int cBest = cIdx[i];
            
            // If we didn't find at least one char we won't find them later either,
            // so we might as well end the search early.
            if (aBest == -1 || bBest == -1 || cBest == -1) {
                break;
            }
            
            // Otherwise, take the greatest index, and that forms the minimum size substring.
            int lastIdx = Math.Max(aBest, Math.Max(bBest, cBest));
            
            totalSubstrings += s.Length - lastIdx;
        }
        
        return totalSubstrings;
    }
}
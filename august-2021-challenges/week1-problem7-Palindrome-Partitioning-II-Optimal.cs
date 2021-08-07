// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/613/week-1-august-1st-august-7th/3872/

public class Solution {
    public int MinCut(string s) {
        
        if (string.IsNullOrWhiteSpace(s) || s.Length == 1) {
            return 0;
        }
        
        int length = s.Length;
        
        // Stores whether or not the substring [i,j] is a palindrome.
        bool[,] palindromeLookups = new bool[length,length];
        
        // minCuts[i] stores the minimal number of cuts needed for a substring from 0..i.
        int[] minCuts = new int[length];
        
        // For every 0..i length of string...
        for (int endIdx = 0; endIdx < length; endIdx++) {
            
            // Start off assuming every character requires a cut.
            minCuts[endIdx] = endIdx;
            
            // For every substring from 0...i, we want to check if we have a palindrome
            for (int startIdx = 0; startIdx <= endIdx; startIdx++) {                
                
                // We're working with a palindrome if:
                // The current characters at the start and end of our substring are equal 
                // AND
                //    Our inner substring (start + 1, end - 1) is also a palindrome
                //  OR
                //    Our start and end indices are right next to each other (or the same idx).
                if (s[startIdx] == s[endIdx] && (startIdx + 1 >= endIdx || palindromeLookups[startIdx + 1, endIdx - 1])) {
                    
                    // Mark this substring as a palindrome
                    palindromeLookups[startIdx, endIdx] = true;
                    
                    // Because we're working with a palindrome, the minimum cuts necessary
                    // for the substring 0...i are either going to be 0 (if we never moved j
                    // then j == 0 and thus we're looking at the whole substring), or
                    // the minimum of our best solution thus far for this substring length,
                    // or the substring from 0...j-1 (+1, as we've had to introduce another cut here,
                    // forming the substrings 0...j-1, and j...i.
                    minCuts[endIdx] = startIdx == 0 ? 0 : Math.Min(minCuts[endIdx], minCuts[startIdx - 1] + 1);
                }
            }
        }
        
        return minCuts[length - 1];
    }
}
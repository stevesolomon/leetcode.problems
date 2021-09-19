// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/638/week-3-september-15th-september-21st/3980/

public class Solution {
    public int NumDistinct(string s, string t) {        
        // Let's consider a 2D Dynamic Programming approach here.
        // With an n * m matrix (n = s.len, m = t.len).
        // lookup[i][j] tells us how many combinations we can create
        // given the first i chars in s (so: 0..i-1), and j chars in j.
        int[][] lookup = new int[s.Length + 1][];
        
        for(int i = 0; i < lookup.Length; i++) {
            lookup[i] = new int[t.Length + 1];
            
            // If we have a 0-length t string, we can form a single subsequence
            // (by simply not including any characters from s)
            lookup[i][0] = 1;
        }       
        
        
        for (int sIdx = 1; sIdx <= s.Length; sIdx++) {            
            for (int tIdx = 1; tIdx <= t.Length; tIdx++) {
                // Condition where we don't take the character.
                // In this case, we're in the same situation as when we 
                // considered this substring of t with the previous substring of s.
                lookup[sIdx][tIdx] = lookup[sIdx - 1][tIdx];
                
                // Consider the condition were we DO take the character.
                // In this case, we can extend all subsequences produced from 
                // the previously smaller substrings of s and t we considered.
                if (s[sIdx - 1] == t[tIdx - 1]) {
                    lookup[sIdx][tIdx] += lookup[sIdx - 1][tIdx - 1];
                }
            }
        }
        
        return lookup[s.Length][t.Length];
    }
}
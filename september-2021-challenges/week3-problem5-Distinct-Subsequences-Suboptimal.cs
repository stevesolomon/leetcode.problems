// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/638/week-3-september-15th-september-21st/3980/

public class Solution {
    public int NumDistinct(string s, string t) {        
        // We can either take, or not take, each character.
        // We only want to take a character if it matches the current
        // character in the index of t that we need to fill.
        // We'll do this recursively, and keep track of which
        // index we're looking at in s, and which index we're tracking in t.
        return NumDistinct(s, t, 0, 0);
    }
    
    private int NumDistinct(string s, string t, int sIdx, int tIdx) {
        
        // Base case: we've found a match
        if (tIdx >= t.Length) {
            return 1;
        }
        
        // Base case: we're out of string s with no match.
        if (sIdx >= s.Length) {
            return 0;
        }
        
        // We have a match. Try both taking it, and NOT taking it.
        int val = 0;
        if (s[sIdx] == t[tIdx]) {
            val = NumDistinct(s, t, sIdx + 1, tIdx + 1);
        }
        
        // Handle the case where we don't take this character.
        return val + NumDistinct(s, t, sIdx + 1, tIdx);
    }
}
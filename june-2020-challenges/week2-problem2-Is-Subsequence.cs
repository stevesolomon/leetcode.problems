// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/540/week-2-june-8th-june-14th/3355/

public class Solution {
    public bool IsSubsequence(string s, string t) {
        if (string.IsNullOrWhiteSpace(s) && !string.IsNullOrWhiteSpace(t)) {
            return true;
        } else if (string.IsNullOrWhiteSpace(t) && !string.IsNullOrWhiteSpace(s)) {
            return false;
        }
        
        int sIdx = 0;
        int tIdx = 0;
        
        while (sIdx < s.Length && tIdx < t.Length) {
            if (t[tIdx] == s[sIdx]) {
                sIdx++;
            }
            
            tIdx++;        
        }
        
        return sIdx == s.Length;
    }
}
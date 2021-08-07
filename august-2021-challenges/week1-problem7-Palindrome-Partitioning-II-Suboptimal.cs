// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/613/week-1-august-1st-august-7th/3872/
// Not an optimal solution.

public class Solution {
    public int MinCut(string s) {
        
        if (string.IsNullOrWhiteSpace(s) || s.Length == 1 || IsPalindrome(s)) {
            return 0;
        } else if (s.Length == 2) {
            return 1;
        }
        
        return MinCut(s, 0) - 1;
    }
    
    private int MinCut(string s, int startIdx) {
        if (startIdx == s.Length) {
            return 0;
        }
        
        int count = int.MaxValue;
        
        for (int i = startIdx; i < s.Length; i++) {
            if (IsPalindrome(s.Substring(startIdx, i - startIdx + 1))) {
                count = Math.Min(count, MinCut(s, i + 1) + 1);
            }
        }
        
        return count;
    }
    
    public bool IsPalindrome(string s) {
        int start = 0;
        int end = s.Length - 1;
        
        while (start < end) {
            if (s[start] != s[end]) {
                return false;
            }
            
            start++;
            end--;
        }
        
        return true;
    }
}
// https://leetcode.com/explore/featured/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3411/

public class Solution {
    public bool IsPalindrome(string s) {
        if (string.IsNullOrWhiteSpace(s)) {
            return true;
        }
        
        s = s.ToLowerInvariant();
        
        int startIdx = 0;
        int endIdx = s.Length - 1;
        
        while (startIdx <= endIdx) {
            while (startIdx < endIdx && !char.IsLetterOrDigit(s[startIdx])) {
                startIdx++;
            }
                   
            while (endIdx > startIdx && !char.IsLetterOrDigit(s[endIdx])) {
                endIdx--;
            }
            
            if (s[startIdx] != s[endIdx]) {
                return false;
            }
            
            startIdx++;
            endIdx--;
        }
        
        return true;
    }
}
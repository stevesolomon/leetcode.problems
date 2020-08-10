// https://leetcode.com/explore/featured/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3419/

public class Solution {
    public int TitleToNumber(string s) {
        if (string.IsNullOrWhiteSpace(s)) {
            return 0;
        }
        
        int val = 0;
        
        foreach (char c in s) {
            val *= 26;
            val += c - 'A' + 1;
        }
        
        return val;
    }
}
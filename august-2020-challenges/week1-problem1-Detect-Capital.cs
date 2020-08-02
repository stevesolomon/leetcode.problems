// https://leetcode.com/explore/featured/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3409/

public class Solution {
    public bool DetectCapitalUse(string word) {
        if (string.IsNullOrWhiteSpace(word)) {
            return true;
        }
        
        int upperCount = 0;
        bool hasLower = false;
        
        foreach (char c in word) {
            if (c >= 'A' && c <= 'Z') {
                if (hasLower) {
                    return false;
                }
                
                upperCount++;
            } else {
                hasLower = true;
            }
        }
        
        if (hasLower && upperCount > 1) {
            return false;
        }
        
        return true;
    }
}
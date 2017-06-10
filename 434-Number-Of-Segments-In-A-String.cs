// https://leetcode.com/problems/number-of-segments-in-a-string/#/description

public class Solution {
    public int CountSegments(string s) {
        if (string.IsNullOrWhiteSpace(s)) {
            return 0;
        }
        
        int segments = 1;
        bool onSpace = false;
        
        int i = 0;
        
        // Get to the first non-space character
        while (s[i] == ' ') { 
            i++; 
        }
        
        for (; i < s.Length; i++) {
            if (s[i] == ' ') {
                onSpace = true;
            } else {
                if (onSpace) {
                    onSpace = false;
                    segments++;
                }
            }
        }
        
        return segments;
    }
}
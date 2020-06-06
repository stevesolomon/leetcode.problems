// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3350/

public class Solution {
    public void ReverseString(char[] s) {
        if (s == null || s.Length < 2) {
            return;
        }
        
        int frontIdx = 0;
        int backIdx = s.Length - 1;
        
        while(frontIdx < backIdx) {
            char temp = s[frontIdx];
            
            s[frontIdx] = s[backIdx];
            s[backIdx] = temp;
            
            frontIdx++;
            backIdx--;
        }
    }
}
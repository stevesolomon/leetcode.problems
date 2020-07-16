// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/546/week-3-july-15th-july-21st/3391/

public class Solution {
    public string ReverseWords(string s) {
        if (string.IsNullOrWhiteSpace(s)) {
            return string.Empty;
        }
        
        StringBuilder sb = new StringBuilder();
        int i = s.Length - 1;
        
        // Starting at the end of the string, figure out where each word is
        while (i >= 0) {
            
            // Skip spaces
            while (i >= 0 && s[i] == ' ') {
                i--;
            }
            
            // Check if we only had spaces for the remainder of the string...
            if (i < 0) {
                break;
            }
            
            int wordStartIdx = i;
            
            // Now move to the next space
            while (i >= 0 && s[i] != ' ') {
                i--;
            }
            
            // Now copy from i + 1 to wordStartIdx
            sb.Append(s, i + 1, wordStartIdx - i);
            sb.Append(" ");
        }
        
        // Remove the last trailing space we added.
        sb.Remove(sb.Length - 1, 1);
        
        return sb.ToString();        
    }
}
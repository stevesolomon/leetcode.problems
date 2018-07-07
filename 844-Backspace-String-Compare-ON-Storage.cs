// https://leetcode.com/problems/backspace-string-compare/description/

public class Solution {
    public bool BackspaceCompare(string S, string T) {
        if (S == null && T  == null) {
            return true;
        } else if (S == null || T == null) {
            return false;
        }
        
        string sString = GenerateString(S);
        string tString = GenerateString(T);
        
        return sString.Equals(tString);
    }
    
    private string GenerateString(string str) {
        StringBuilder sb = new StringBuilder();
        
        foreach (char c in str) {
            if (c == '#') {
                if (sb.Length > 0) {
                    sb.Length--;
                }
                continue;
            }
            
            sb.Append(c);
        }
        
        return sb.ToString();
    }
}
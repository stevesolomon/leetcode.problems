// https://leetcode.com/problems/backspace-string-compare/description/

public class Solution {
    public bool BackspaceCompare(string S, string T) {
        if (S == null && T  == null) {
            return true;
        } else if (S == null || T == null) {
            return false;
        }
        
        int sPos = S.Length - 1, tPos = T.Length - 1;
        
        while (sPos >= 0 || tPos >= 0) {
            
            // Find next valid position in S
            int numBackspace = 0;
            
            while (sPos >= 0) {
                if (S[sPos] == '#') {
                    numBackspace++;
                    sPos--;
                    continue;
                } else if (numBackspace > 0) {
                    numBackspace--;
                    sPos--;
                    continue;
                }
                
                break;
            }
            
            // And then the next valid position in T
            numBackspace = 0;
            
            while (tPos >= 0) {
                if (T[tPos] == '#') {
                    numBackspace++;
                    tPos--;
                    continue;
                } else if (numBackspace > 0) {
                    numBackspace--;
                    tPos--;
                    continue;
                }
                
                break;
            }
            
            // The two chars better be equal
            if ((sPos >= 0 && tPos < 0) || (sPos < 0 && tPos >= 0)) {
                return false;
            } else if (sPos >= 0 && tPos >= 0) {
                if (S[sPos] != T[tPos]) {
                    return false;
                }
            }
            
            sPos--;
            tPos--;
        }
        
        return true;            
    }
}
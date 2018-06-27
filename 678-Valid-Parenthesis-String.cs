// https://leetcode.com/problems/valid-parenthesis-string/description/

public class Solution {
    public bool CheckValidString(string s) {
        
        if (string.IsNullOrWhiteSpace(s)) {
            return true;
        } else if (s[0] == ')') {
            return false;
        }
        
        int minOpenLeftParen = 0;
        int maxOpenLeftParen = 0;
        
        // Keep track of the minimum and maximum possible left parens we could have "open".
        // The only time these will diverge is when we encounter a '*' character, as we could
        // potentially choose a ')' (closing an open paren) or a '(' (opening a new open paren).
        // If at any point both go below 0, we have an invalid string (as we must have too many ')'s).
        // If only the minOpenLeftParen goes below 0, reset it back to 0 (this will "rewrite" some of the 
        // '*'s we previously chose as ')'s into empty strings).
        
        for (int i = 0; i < s.Length; i++) {
            char curr = s[i];
            
            if (curr == '*') {
                minOpenLeftParen--;
                maxOpenLeftParen++;
            } else if (curr == ')') {
                minOpenLeftParen--;
                maxOpenLeftParen--;
            } else {
                minOpenLeftParen++;
                maxOpenLeftParen++;
            }
            
            if (minOpenLeftParen < 0 && maxOpenLeftParen < 0) {
                return false;
            }
            
            minOpenLeftParen = Math.Max(minOpenLeftParen, 0);
        }
        
        return minOpenLeftParen == 0;        
    }
}
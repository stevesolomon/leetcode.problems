// https://leetcode.com/problems/repeated-substring-pattern/description/ 

public class Solution {
    public bool RepeatedSubstringPattern(string s) {
        
        if (string.IsNullOrWhiteSpace(s)) {
            return true;
        }
        
        int right = 0;
        int left = 1;
        
        while (true) {
            
            // Increment left until we have the same character as right
            while (left < s.Length && s[left] != s[right]) {
                left++;
            }
            
            // If left is outside of the string we're done.
            if (left >= s.Length) {
                break;
            }
            
            // Otherwise, s[right] == s[left]. We could have a repeated substring
            // To check this, we'll step one forward with each, ensuring that the character's
            // continue to match until we reach the end of the string.
            int testRight = right;
            int testLeft = left;
            
            // First check if it's impossible to form substrings.
            // If our string isn't a multiple of the substring length we can't.
            int substringLength = left - right;            
            if (s.Length % substringLength == 0) {
                while (testLeft < s.Length && s[testRight] == s[testLeft]) {
                    testRight++;
                    testLeft++;
                }
            
                // If we made it to the end of the strng we have a repeated substring.
                if (testLeft == s.Length) {
                    return true;
                }
            }
            
            // Otherwise, at the current right/left indices we didn't have a repeated
            // substring, but we may have others elsewhere (consider: abcabczabcabcz).
            // So continue searching where we left off.
            left++;
        }        
        
        return false;
    }
}
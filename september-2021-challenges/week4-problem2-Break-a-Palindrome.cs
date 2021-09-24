// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/639/week-4-september-22nd-september-28th/3985/

public class Solution {
    public string BreakPalindrome(string palindrome) {
        if (string.IsNullOrWhiteSpace(palindrome) || palindrome.Length == 1) {
            return string.Empty;
        }
        
        StringBuilder sb = new StringBuilder(palindrome);
        
        // Find the first non-a character and switch to a.
        // If we reach the end of the string then just switch the last char
        // to a b, as this implies the entire string is 'a'.
        for (int i = 0; i < palindrome.Length / 2; i++) {
            if (palindrome[i] != 'a') {
                sb[i] = 'a';
                return sb.ToString();
            }
        }
        
        sb[sb.Length - 1] = 'b';
        return sb.ToString();
    }
}
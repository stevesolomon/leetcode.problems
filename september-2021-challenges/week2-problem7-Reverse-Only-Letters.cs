// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/637/week-2-september-8th-september-14th/3974/

public class Solution {
    public string ReverseOnlyLetters(string s) {
        if (string.IsNullOrWhiteSpace(s)) {
            return s;
        }
        
        StringBuilder sb = new StringBuilder();
        
        int left = 0;
        int right = s.Length - 1;
        
        char[] reversed = new char[s.Length];
        
        while (left <= right) {
            
            // If left or right is not an English character
            // then just apply it at its exact index in the reversed array.
            // Otherwise, apply left to the right index and vice versa.
            if (!char.IsLetter(s[left])) {
                reversed[left] = s[left];
                left++;
            } else if (!char.IsLetter(s[right])) {
                reversed[right] = s[right];
                right--;
            } else {
                reversed[left] = s[right];
                reversed[right] = s[left];
                
                left++;
                right--;
            }
        }
        
        return new string(reversed);
    }
}
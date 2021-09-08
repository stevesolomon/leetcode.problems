// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/637/week-2-september-8th-september-14th/3968/

public class Solution {
    public string ShiftingLetters(string s, int[] shifts) {
        if (string.IsNullOrWhiteSpace(s) || shifts == null || shifts.Length != s.Length) {
            return s;
        }
        
        // Build up a reverse prefix-sum in shifts to identify how many times
        // each indexed letter is actually going to be shifted.
        for (int i = shifts.Length - 2; i >= 0; i--) {
            // Make sure to % 26 the numbers as they could be very large.
            // As we're just working with lowercase ascii letters we only need
            // to worry about shifting across 26 possibilities.
            shifts[i] += (shifts[i + 1] % 26);
        }
        
        // Now shift all of the letters in our string.
        StringBuilder sb = new StringBuilder();
        
        for (int i = 0; i < s.Length; i++) {
            int charInt = (int) s[i] - (int) 'a';
            charInt = (charInt + shifts[i]) % 26;
            charInt += (int) 'a';
            sb.Append((char) charInt);
        }
        
        return sb.ToString();
    }
}
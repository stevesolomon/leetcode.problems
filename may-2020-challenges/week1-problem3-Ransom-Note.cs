// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/534/week-1-may-1st-may-7th/3318/

public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        if (string.IsNullOrWhiteSpace(ransomNote)) {
            return true;
        } else if (string.IsNullOrWhiteSpace(magazine)) {
            return false;
        }
        
        Dictionary<char, int> letters = new Dictionary<char, int>();
        
        foreach (char c in magazine) {
            if (!letters.ContainsKey(c)) {
                letters.Add(c, 0);
            }
            
            letters[c]++;
        }
        
        foreach (char c in ransomNote) {
            if (!letters.ContainsKey(c) || letters[c] <= 0) {
                return false;
            }
            
            letters[c]--;
        }
        
        return true;
    }
}
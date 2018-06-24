// https://leetcode.com/problems/valid-anagram/description/

public class Solution {
    public bool IsAnagram(string s, string t) {
        
        if (s == null && t == null) {
            return true;
        } else if (s == null || t == null) {
            return false;
        } else if (s.Length != t.Length) {
            return false;
        }
        
        Dictionary<char, int> charCounts = new Dictionary<char, int>();
        
        foreach (char c in s) {
            if (!charCounts.ContainsKey(c)) {
                charCounts.Add(c, 0);
            }
            
            charCounts[c]++;
        }
        
        foreach (char c in t) {
            if (!charCounts.ContainsKey(c)) {
                return false;
            }
            
            charCounts[c]--;
            
            if (charCounts[c] == 0) {
                charCounts.Remove(c);
            }
        }
        
        return charCounts.Keys.Count == 0;
    }
}
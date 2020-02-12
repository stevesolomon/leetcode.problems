// https://leetcode.com/problems/word-pattern/

public class Solution {
    public bool WordPattern(string pattern, string str) {
        if (string.IsNullOrWhiteSpace(pattern) && string.IsNullOrWhiteSpace(str)) {
            return true;
        } else if (string.IsNullOrWhiteSpace(pattern) || string.IsNullOrWhiteSpace(str)) {
            return false;
        }
        
        string[] strs = str.Split(' ');
        Dictionary<char, string> mapping = new Dictionary<char, string>();
        HashSet<string> observedWords = new HashSet<string>();
        
        if (pattern.Length != strs.Length) {
            return false;
        }
        
        // Iterate through each character in the pattern.
        // If we don't have it in the dictionary, add it, and assign the value to the current index in the str array.
        // If we do have it in the dictionary, the mapped value must equal the current index in the str array.
        for (int i = 0; i < pattern.Length; i++) {
            char c = pattern[i];
            
            if (!mapping.ContainsKey(c)) {
                
                if (observedWords.Contains(strs[i])) {
                    return false;
                }
                
                mapping.Add(c, strs[i]);
                observedWords.Add(strs[i]);
                continue;
            }
            
            if (!mapping[c].Equals(strs[i])) {
                return false;
            }
        }
        
        return true;        
    }
}
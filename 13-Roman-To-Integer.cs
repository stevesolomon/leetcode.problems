// https://leetcode.com/problems/roman-to-integer/description/

public class Solution {
    
    private Dictionary<char, int> lookup = new Dictionary<char, int> 
    {
        {'i', 1},
        {'v', 5},
        {'x', 10},
        {'l', 50},
        {'c', 100},
        {'d', 500},
        {'m', 1000}
    };
    
    public int RomanToInt(string s) {
        
        if (string.IsNullOrWhiteSpace(s)) {
            return 0;
        }
        
        s = s.ToLowerInvariant();
        
        int intVal = 0;
        int charIdx = 0;
        
        while (charIdx < s.Length) {
            // Test our special rules.
            if (s[charIdx] == 'i' && charIdx < s.Length - 1 && (s[charIdx + 1] == 'x' || s[charIdx + 1] == 'v')) {
                intVal += lookup[s[charIdx + 1]] - lookup[s[charIdx]];
                charIdx++;
            } else if (s[charIdx] == 'x' && charIdx < s.Length - 1 && (s[charIdx + 1] == 'l' || s[charIdx + 1] == 'c')) {
                intVal += lookup[s[charIdx + 1]] - lookup[s[charIdx]];
                charIdx++;
            } else if (s[charIdx] == 'c' && charIdx < s.Length - 1 && (s[charIdx + 1] == 'd' || s[charIdx + 1] == 'm')) {
                intVal += lookup[s[charIdx + 1]] - lookup[s[charIdx]];
                charIdx++;
            } else {
                // No special rules apply, just add the value directly.
                intVal += lookup[s[charIdx]];
            }
            
            charIdx++;
        }
        
        return intVal;
    }
}
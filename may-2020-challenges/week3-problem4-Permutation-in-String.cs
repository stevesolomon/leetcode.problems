// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/536/week-3-may-15th-may-21st/3333/

public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (string.IsNullOrWhiteSpace(s1) || string.IsNullOrWhiteSpace(s2) || 
           s1.Length > s2.Length) {
            return false;
        }
        
        // We'll create a sliding window of length s1 to traverse s2.
        // We'll use two character frequency dictionaries:
        //   - One static one storing all char freqs in s1.
        //   - One dynamic one that stores char freqs in s2's sliding window.
        // As we move the window, we'll remove the char that dropped off from s2's window
        // and add the char that was added.
        // We could use a 26-char array to optimize here but let's go generic.
        Dictionary<char, int> targetFreqs = new Dictionary<char, int>();
        Dictionary<char, int> windowFreqs = new Dictionary<char, int>();
        
        foreach (char c in s1) {
            if (!targetFreqs.ContainsKey(c)) {
                targetFreqs.Add(c, 0);
            }
            
            targetFreqs[c]++;
        }
        
        for (int i = 0; i < s1.Length; i++) {
            char c = s2[i];
            
            if (!windowFreqs.ContainsKey(c)) {
                windowFreqs.Add(c, 0);
            }
            
            windowFreqs[c]++;
        }
        
        if (FreqsMatch(targetFreqs, windowFreqs)) {
            return true;
        }
        
        int windowStart = 1;
        int windowEnd = s1.Length;
        
        while (windowEnd < s2.Length) {
            windowFreqs[s2[windowStart - 1]]--;
            char newChar = s2[windowEnd];
            
            if (!windowFreqs.ContainsKey(newChar)) {
                windowFreqs.Add(newChar, 0);
            }
            
            windowFreqs[newChar]++;
            
            if (FreqsMatch(targetFreqs, windowFreqs)) {
                return true;
            }
            
            windowStart++;
            windowEnd++;
        }
        
        return false;        
    }
    
    private bool FreqsMatch(Dictionary<char, int> targetFreqs, Dictionary<char, int> windowFreqs) {
        foreach (var key in targetFreqs.Keys) {
            if (!windowFreqs.ContainsKey(key) || windowFreqs[key] != targetFreqs[key]) {
                return false;
            }
        }
        
        return true;
    }
}
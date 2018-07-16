// https://leetcode.com/problems/longest-substring-with-at-least-k-repeating-characters/description/

public class Solution {
    public int LongestSubstring(string s, int k) {
        if (string.IsNullOrWhiteSpace(s)) {
            return 0;
        } else if (k == 0 || k == 1) {
            return s.Length;
        } else if (k > s.Length) {
            return 0;
        }
        
        return LongestSubstringHelper(s, k, 0, s.Length);
    }
    
    private int LongestSubstringHelper(string s, int target, int startIdx, int endIdx) {
        
        if (startIdx >= endIdx) {
            return 0;
        }
        
        // Get our character counts
        Dictionary<char, int> charCounts = new Dictionary<char, int>();
        
        for (int i = startIdx; i < endIdx; i++) {
            char ch = s[i];
            
            if (!charCounts.ContainsKey(ch)) {
                charCounts.Add(ch, 0);
            }
            
            charCounts[ch]++;
        }
        
        bool atTarget = true;
        List<int> breaks = new List<int>();
        
        // Is every character at the target? Return this length.
        for (int i = startIdx; i < endIdx; i++) {
            if (charCounts[s[i]] < target) {
                atTarget = false;
                breaks.Add(i);
            }
        }
        
        if (atTarget) {
            return endIdx - startIdx;
        }
        
        int bestLen = int.MinValue;
        
        // Otherwise, recurse into the substrings and return the best length.
        for (int i = 0; i < breaks.Count; i++) {
            bestLen = Math.Max(bestLen, LongestSubstringHelper(s, target, startIdx, breaks[i]));
            startIdx = breaks[i] + 1;
        }
        
        bestLen = Math.Max(bestLen, LongestSubstringHelper(s, target, startIdx, endIdx));
        
        return bestLen;
    }
}
// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/536/week-3-may-15th-may-21st/3332/

public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(p)) {
            return new List<int>();
        } else if (p.Length > s.Length) {
            return new List<int>();
        }
        
        // First get a dictionary of all letter frequencies in the 'p' string.
        // Then we'll use a sliding window of p.Length size in s to test 
        // all substrings.
        Dictionary<char, int> targetFreqs = new Dictionary<char, int>();
        
        foreach (var c in p) {
            if (!targetFreqs.ContainsKey(c)) {
                targetFreqs.Add(c, 0);
            }
            
            targetFreqs[c]++;
        }
        
        // Now, we only have to iterate through the first p.Length
        // chars in s to build up our initial frequency table.
        // After that, we just slide the window and remove the single
        // char that has dropped off and add the single char that was introduced.
        Dictionary<char, int> sourceFreqs = new Dictionary<char, int>();
        List<int> results = new List<int>();
        
        int startIdx = 0;
        int endIdx = p.Length - 1;
        
        for (int i = startIdx; i <= endIdx; i++) {
            char c = s[i];
            
            if (!sourceFreqs.ContainsKey(c)) {
                sourceFreqs.Add(c, 0);
            }
            
            sourceFreqs[c]++;
        }
        
        
        
        if (FreqsMatch(targetFreqs, sourceFreqs)) {
            results.Add(startIdx);
        }
        
        while (endIdx < s.Length - 1) {
            sourceFreqs[s[startIdx]]--;
            
            startIdx++;
            endIdx++;
            
            char c = s[endIdx];
            
            if (!sourceFreqs.ContainsKey(c)) {
                sourceFreqs.Add(c, 0);
            }
            
            sourceFreqs[c]++;
            
            if (FreqsMatch(targetFreqs, sourceFreqs)) {
                results.Add(startIdx);
            }
        }
        
        return results;
    }
    
    private bool FreqsMatch(Dictionary<char, int> target, Dictionary<char, int> source) {
        foreach (var key in target.Keys) {
            
            if (target[key] == 0) {
                continue;
            }
            
            if (!source.ContainsKey(key) || target[key] != source[key]) {
                return false;
            }
        }
        
        return true;
    }
        
}
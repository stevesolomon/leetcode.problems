// https://leetcode.com/problems/repeated-dna-sequences/description/

public class Solution {
    public IList<string> FindRepeatedDnaSequences(string s) {
        
        List<string> results = new List<string>();
        
        if (string.IsNullOrWhiteSpace(s) || s.Length < 11) {
            return results;
        } 
        
        Dictionary<string, int> occurrences = new Dictionary<string, int>();
        
        // Should definitely pack the window in an int instead of SB, because
        // SB.Remove is O(n) but this is good enough for this :)
        StringBuilder window = new StringBuilder();
        
        for (int i = 0; i < s.Length; i++) {
            
            if (window.Length >= 10) {
                window.Remove(0, 1);
            }
            
            window.Append(s[i]);
            
            string currWindow = window.ToString();
            
            if (!occurrences.ContainsKey(currWindow)) {
                occurrences.Add(currWindow, 0);
            }
            
            occurrences[currWindow]++;
        }        
        
        foreach (var key in occurrences.Keys) {
            if (occurrences[key] > 1) {
                results.Add(key);
            }
        }
        
        return results;
    }
}
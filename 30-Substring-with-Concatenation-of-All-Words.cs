// https://leetcode.com/problems/substring-with-concatenation-of-all-words/

public class Solution {
    public IList<int> FindSubstring(string s, string[] words) {
        
        List<int> results = new List<int>();
        
        if (string.IsNullOrWhiteSpace(s) || words == null || words.Length == 0) {
            return results;
        }
        
        // Build up a dictionary of words (we may have duplicate words so we need to include counts).
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();
        int totalMatchLength = 0;
        int singleWordLength = words[0].Length;
        
        foreach (string word in words) {
            if (!wordCounts.ContainsKey(word)) {
                wordCounts.Add(word, 0);
            }
            
            wordCounts[word]++;
            totalMatchLength += singleWordLength;
        }
        
        // Now, starting at every start index in s, try to match all of the words.
        for (int i = 0; i < s.Length - totalMatchLength + 1; i++) {
            
            int remainingMatchLength = totalMatchLength;
            Dictionary<string, int> currMatches = new Dictionary<string, int>(wordCounts);
            
            // From this starting index, try to match up all words.
            // If we don't find a match at any point we can break early.
            for (int j = i; j < s.Length - remainingMatchLength + 1; j++) {
                            
                // Try to grab a match of a single word.
                string substr = s.Substring(j, singleWordLength);
            
                // We have a match.
                if (currMatches.ContainsKey(substr) && currMatches[substr] > 0) {
                    currMatches[substr]--;

                    // Move our pointer out the length of this word,
                    // and decrement our current match length as well.
                    j += singleWordLength - 1;
                    remainingMatchLength -= singleWordLength;
                } else {
                    break;
                }
            
                // Have we found all matches? If so, we're done.
                if (remainingMatchLength == 0) {
                    results.Add(i);
                    break;
                }
            }
        }
        
        
        return results;
    }
}
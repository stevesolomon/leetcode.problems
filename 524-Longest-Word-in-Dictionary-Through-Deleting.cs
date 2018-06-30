// https://leetcode.com/problems/longest-word-in-dictionary-through-deleting/description/
// Note that this solution exceeds the time limit on one of the longer test cases.

public class Solution {
    public string FindLongestWord(string s, IList<string> d) {
        if (string.IsNullOrWhiteSpace(s)) {
            return string.Empty;
        } else if (d == null || d.Count == 0) {
            return string.Empty;
        }
        
        int smallestString = int.MaxValue;
        TrieNode root = new TrieNode();
        
        for (int i = 0; i < d.Count; i++) {
            root.AddWord(d[i], 0);
            smallestString = Math.Min(smallestString, d[i].Length);
        }
        
        Queue<Tuple<TrieNode, int>> traversal = new Queue<Tuple<TrieNode, int>>();
        HashSet<char> visited = new HashSet<char>();
        
        int longestWord = int.MinValue;
        List<string> candidateWords = new List<string>();   
        
        for (int i = 0; i <= s.Length - smallestString; i++) {
            if (root.Children.ContainsKey(s[i]) && !visited.Contains(s[i])) {
                traversal.Enqueue(new Tuple<TrieNode, int>(root.Children[s[i]], i + 1));
                visited.Add(s[i]);
                
                if (root.Children[s[i]].EndsWord) {
                    candidateWords.Add(root.Children[s[i]].Word);
                    longestWord = 1;
                }
            }
        }
        
        while (traversal.Count > 0) {
            visited.Clear();
            Tuple<TrieNode, int> currTuple = traversal.Dequeue();    
            
            TrieNode curr = currTuple.Item1;
            int startIdx = currTuple.Item2;
            
            // Does this TrieNode end a word at least as long as the longest we've found so far?
            if (curr.EndsWord && curr.Word.Length >= longestWord) {
                // Then add it to our candidate words!
                candidateWords.Add(curr.Word);
                longestWord = curr.Word.Length;
            }
            
            // From our current TrieNode, enqueue any children from any of the other
            // characters in our string.
            for (int i = startIdx; i < s.Length; i++) {
                if (curr.Children.ContainsKey(s[i]) && !visited.Contains(s[i])) {
                    traversal.Enqueue(new Tuple<TrieNode, int>(curr.Children[s[i]], i + 1));
                    visited.Add(s[i]);
                }
            }
        }
        
        // Finally, scan our candidateWords for the longest word.
        List<string> longestWords = new List<string>();
        
        foreach (string word in candidateWords) {
            if (word.Length == longestWord) {
                longestWords.Add(word);
            }
        }
        
        longestWords.Sort();
        
        return longestWords.Count == 0 ? string.Empty : longestWords[0];
    }
}

public class TrieNode {
    public Dictionary<char, TrieNode> Children { get; private set; }
    
    public bool EndsWord { get; private set; }
    
    public string Word { get; private set; }
    
    public TrieNode() {
        Children = new Dictionary<char, TrieNode>();
    }
    
    public void AddWord(string word, int idx) {
        if (idx == word.Length) {
            this.EndsWord = true;
            this.Word = word;
            return;
        }
        
        if (!Children.ContainsKey(word[idx])) {
            Children.Add(word[idx], new TrieNode());
        }
        
        Children[word[idx]].AddWord(word, idx + 1);
    }
}
// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/548/week-5-july-29th-july-31st/3406/

public class Solution {
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        if (string.IsNullOrWhiteSpace(s) || wordDict == null || wordDict.Count == 0) {
            return new List<string>();
        }
        
        Trie trie = new Trie();
        
        foreach (var word in wordDict) {
            trie.AddWord(word);
        }
        
        // Quick exit if we don't have the characters we need...
        foreach (char c in s) {
            if (!trie.CharSet.Contains(c)) {
                return new List<string>();
            }
        }
        
        List<List<string>> results = new List<List<string>>();        
        trie.FindAllValidWordSequences(s, 0, new List<string>(), results);
        
        List<string> finalResults = new List<string>();
        
        foreach (var res in results) {
            finalResults.Add(string.Join(' ', res));
        }
        
        return finalResults;
    }
}

public class Trie {
    public TrieNode Root { get; set; }
    
    public HashSet<char> CharSet { get; set; }
    
    public Trie() {
        Root = new TrieNode();
        CharSet = new HashSet<char>();
    }
    
    public void AddWord(string word) {
        TrieNode curr = Root;
        
        foreach (var c in word) {
            if (!curr.Children.ContainsKey(c)) {
                curr.Children.Add(c, new TrieNode());
            }      
            curr = curr.Children[c];
            
            CharSet.Add(c);  
        }
        
        curr.EndsWord = true;
    }
    
    public void FindAllValidWordSequences(string s, int idx, List<string> currSeq, List<List<string>> results) {
        // We want to keep searching in the Trie for any word in our string
        // as we progress index-by-index. When we find a word, we want to branch
        // off from there: either we take that word, or we don't.
        
        // Reached the end of the string, add our currSeq to our results
        if (idx >= s.Length) {
            results.Add(new List<string>(currSeq));
            return;
        }
        
        // Otherwise search fresh...        
        TrieNode curr = Root;
        int currIdx = idx;
        
        while (currIdx < s.Length && curr != null) {
            
            char currChar = s[currIdx++];
            
            // No further word to be matched? We've done all we can here.
            if (!curr.Children.ContainsKey(currChar)) {
                return;
            }
            
            curr = curr.Children[currChar];
            
            // Did we find a word?
            if (curr.EndsWord) {
                
                // Consider taking it, and then searching deeper
                currSeq.Add(s.Substring(idx, currIdx - idx));
                FindAllValidWordSequences(s, currIdx, currSeq, results);
                
                // Clean up as we will want to consider not taking the word as well...
                currSeq.RemoveAt(currSeq.Count - 1);
            }
            
        }
    }
}

public class TrieNode {
    public Dictionary<char, TrieNode> Children { get; set; }
    
    public bool EndsWord { get; set; }
    
    public TrieNode() {
        this.Children = new Dictionary<char, TrieNode>();
    }
}
// https://leetcode.com/problems/distinct-echo-substrings/
// This fails the last few test cases due to TLE. Will look at optimizing...

public class Solution {
    public int DistinctEchoSubstrings(string text) {
        if (string.IsNullOrWhiteSpace(text)) {
            return 0;
        }
        
        Trie trie = new Trie();
        HashSet<string> results = new HashSet<string>();
        
        for (int i = 0; i < text.Length; i++) {
            string result = trie.AddString(text.Substring(i, text.Length - i), i);
            
            if (result != null && !results.Contains(result)) {
                results.Add(result);
            }
        }
        
        return results.Count;
    }
}

public class TrieNode {
    public Dictionary<char, TrieNode> children;
    public HashSet<int> indices;
    
    public TrieNode() {
        children = new Dictionary<char, TrieNode>();
        indices = new HashSet<int>();
    }
}

public class Trie {
    
    public TrieNode root;
    
    public Trie() {
        // Root remains empty.
        root = new TrieNode();
    }
    
    public string AddString(string str, int startIdx) {
        TrieNode curr = root;
        string echoString = null;
                
        for (int i = 0; i < str.Length; i++) {
            if (!curr.children.ContainsKey(str[i])) {
                curr.children.Add(str[i], new TrieNode());
            }
            
            curr = curr.children[str[i]];

            if (curr.indices.Contains(startIdx - 1)) {
                echoString = str.Substring(0, i + 1) + str.Substring(0, i + 1);
            }

            curr.indices.Add(startIdx + i);
        }
        
        return echoString;
    }
}
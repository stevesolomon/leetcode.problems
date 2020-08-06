// https://leetcode.com/explore/featured/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3413/

public class WordDictionary {

    private Trie trie;
    
    /** Initialize your data structure here. */
    public WordDictionary() {
        trie = new Trie();
    }
    
    /** Adds a word into the data structure. */
    public void AddWord(string word) {
        trie.AddWord(word);
    }
    
    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word) {
        return trie.HasWord(word);
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
            this.CharSet.Add(c);  
        }
        
        curr.EndsWord = true;
    }
    
    public bool HasWord(string word) {
        return this.HasWord(word, 0, this.Root);
    }
    
    private bool HasWord(string word, int idx, TrieNode curr) {
        if (idx == word.Length) {
            return curr.EndsWord;
        }
        
        if (word[idx] == '.') {
            // Wild card, try searching from all children                
            foreach (var kvp in curr.Children) {
                if (this.HasWord(word, idx + 1, kvp.Value)) {
                    return true;
                }
            }
            
            // Didn't find anything, return false;
            return false;
        } else {
            // Keep working our way through the word...
            if (!curr.Children.ContainsKey(word[idx])) {
                return false;
            }
            
            return this.HasWord(word, idx + 1, curr.Children[word[idx]]);
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

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */
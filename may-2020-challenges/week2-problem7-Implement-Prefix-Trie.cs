// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3329/

public class Trie {
    
    TrieNode root;

    /** Initialize your data structure here. */
    public Trie() {
        this.root = new TrieNode();
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {
        TrieNode curr = root;
        
        foreach (char c in word) {
            curr = curr.AddChild(c);
        }
        
        curr.FormsEndOfWord = true;
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        TrieNode curr = root;
        
        foreach (char c in word) {
            curr = curr.GetChild(c);
            
            if (curr == null) {
                return false;
            }
        }
        
        // curr must form an end of a word...
        return curr.FormsEndOfWord;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        TrieNode curr = root;
        
        foreach (char c in prefix) {
            curr = curr.GetChild(c);
            
            if (curr == null) {
                return false;
            }
        }
        
        return true;
    }
}

public class TrieNode {
    
    private Dictionary<char, TrieNode> Children { get; set; }
    
    public bool FormsEndOfWord { get; set; }
    
    public TrieNode() {
        this.Children = new Dictionary<char, TrieNode>();
    }
    
    public TrieNode AddChild(char c) {
        if (!this.Children.ContainsKey(c)) {
            this.Children.Add(c, new TrieNode());
        }
        
        return this.Children[c];
    }
    
    public TrieNode GetChild(char c) {
        if (this.Children.ContainsKey(c)) {
            return this.Children[c];
        }
        
        return null;
    }
    
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
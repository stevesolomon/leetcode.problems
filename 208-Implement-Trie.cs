// https://leetcode.com/problems/implement-trie-prefix-tree/description/

public class Trie {
    TrieNode root = null;

    /** Initialize your data structure here. */
    public Trie() {
        root = new TrieNode();
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {
        root.Insert(word, 0);
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        return root.Search(word, 0, false);
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        return root.Search(prefix, 0, true);
    }
}

public class TrieNode {
    public Dictionary<char, TrieNode> children;
    
    public bool formsWord;
    
    public TrieNode() {
        this.children = new Dictionary<char, TrieNode>();
    }
    
    public void Insert(string word, int index) {
        
        // Base case, we're done and this last TrieNode forms a word.
        if (index == word.Length) {
            formsWord = true;
            return;
        }
        
        if (!children.ContainsKey(word[index])) {
            children.Add(word[index], new TrieNode());
        }
        
        children[word[index]].Insert(word, index + 1);
    }
    
    public bool Search(string word, int index, bool mustFormWord) {
        
        if (index == word.Length) {
            return formsWord || mustFormWord;
        }
        
        if (!children.ContainsKey(word[index])) {
            return false;
        }
        
        return children[word[index]].Search(word, index + 1, mustFormWord);
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
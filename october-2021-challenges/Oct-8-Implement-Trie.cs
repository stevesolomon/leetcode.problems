// https://leetcode.com/problems/implement-trie-prefix-tree/submissions/

public class Trie {
    
    private TrieNode root;

    public Trie() {
        this.root = new TrieNode();
    }
    
    public void Insert(string word) {
        TrieNode curr = this.root;
        
        for (int i = 0; i < word.Length; i++) {
            if (!curr.Children.ContainsKey(word[i])) {
                curr.Children.Add(word[i], new TrieNode());
            }
            
            curr = curr.Children[word[i]];
        }
        
        curr.EndsWord = true;
    }
    
    public bool Search(string word) {
        TrieNode result = this.GetTrieNode(word);
        
        return result != null && result.EndsWord;
    }
    
    public bool StartsWith(string prefix) {
        TrieNode result = this.GetTrieNode(prefix);
        
        return result != null;
    }
    
    private TrieNode GetTrieNode(string word) {
        TrieNode curr = this.root;
        
        for (int i = 0; i < word.Length; i++) {
            if (!curr.Children.ContainsKey(word[i])) {
                return null;
            }
            
            curr = curr.Children[word[i]];
        }
        
        return curr;
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
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
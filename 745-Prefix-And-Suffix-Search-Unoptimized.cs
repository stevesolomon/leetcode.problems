// https://leetcode.com/problems/prefix-and-suffix-search/description/
// Time Limit Exceeded on some of the longer test cases.
// Could likely improve on this by using a single prefix tree.

public class WordFilter {
    
    private PrefixTree prefixTree;
    
    private PrefixTree suffixTree;

    public WordFilter(string[] words) {
        prefixTree = new PrefixTree(10, words);
        suffixTree = new PrefixTree(10, words, true);
    }
    
    public int F(string prefix, string suffix) {
        HashSet<int> prefixWords = prefixTree.GetWordIndicesWithPrefix(prefix);
        
        char[] charArray = suffix.ToCharArray();
        Array.Reverse( charArray );
        suffix = new string(charArray);
        
        HashSet<int> suffixWords = suffixTree.GetWordIndicesWithPrefix(suffix);
        
        // Find the union of words in both and take the largest.
        int largest = -1;
        
        foreach (int s in suffixWords) {
            if (prefixWords.Contains(s)) {
                largest = Math.Max(s, largest);
            }
        }
        
        return largest;
    }
}

public class PrefixTree {
    
    private PrefixTreeNode root;
    
    private int maxDepth;
    
    public PrefixTree(int maxDepth, string[] words, bool buildSuffix = false) {
        this.maxDepth = maxDepth + 1; // +1 because root is a "useless" node
        
        root = new PrefixTreeNode(' ');
        
        ConstructPrefixTree(words, buildSuffix);
    }
    
    public HashSet<int> GetWordIndicesWithPrefix(string prefix) {
        if (prefix.Length > 0 && !root.Children.ContainsKey(prefix[0])) {
            return new HashSet<int>();
        }
        
        return root.GetWordIndicesWithPrefix(prefix, 0);
    }
    
    private void ConstructPrefixTree(string[] words, bool buildSuffix) {
        for (int i = 0; i < words.Length; i++) {
            
            string word = words[i];
            
            if (buildSuffix) {
                char[] charArray = word.ToCharArray();
                Array.Reverse( charArray );
                word = new string(charArray);
            }
            
            this.root.AddWord(word, 0, Math.Min(maxDepth, word.Length), i);
        }
    }
    
}

public class PrefixTreeNode {
    
    private HashSet<int> wordIndices;
    
    public Dictionary<char, PrefixTreeNode> Children { get; set; }
    
    public char Value { get; private set; }
    
    public PrefixTreeNode(char value) {
        this.Value = value;
        
        this.Children = new Dictionary<char, PrefixTreeNode>();
        this.wordIndices = new HashSet<int>();
    }
    
    public HashSet<int> GetWordIndicesWithPrefix(string prefix, int idx) {
        if (string.IsNullOrWhiteSpace(prefix) || idx >= prefix.Length) {
            return wordIndices;
        }
        
        if (!Children.ContainsKey(prefix[idx])) {
            return new HashSet<int>();
        }
        
        return Children[prefix[idx]].GetWordIndicesWithPrefix(prefix, idx + 1);
    }
    
    public void AddWord(string word, int startIdx, int endIdx, int wordIndex) {
        
        // Add the word index to our node's wordIndices as we have a prefix for that
        // particular word up until this point.
        this.wordIndices.Add(wordIndex);
        
        // Then exit early if we've exhausted all characters we want to use.
        if (startIdx >= endIdx) {
            return;
        }        
        
        // Send the current char to our child that supports it (or create one)
        char curr = word[startIdx];
        
        if (!Children.ContainsKey(curr)) {
            Children.Add(curr, new PrefixTreeNode(curr));
        }
        
        Children[curr].AddWord(word, startIdx + 1, endIdx, wordIndex);
    }
}
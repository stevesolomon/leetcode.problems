// https://leetcode.com/problems/concatenated-words/description/
// Note that this TLE's for very long problem sets.

public class Solution {
    public IList<string> FindAllConcatenatedWordsInADict(string[] words) {
        List<string> results = new List<string>();
        
        if (words == null || words.Length == 0 || words.Length == 1) {
            return results;
        }
        
        // First store every word into the prefix tree.
        PrefixTreeNode root = new PrefixTreeNode();
        int minStringLen = int.MaxValue;
        
        for (int i = 0; i < words.Length; i++) {
            root.AddWord(0, words[i]);
            
            // As an optimization, we'll store the minimum string length
            // that we see. This way, we know we only need to later test
            // against strings that are twice this size at minimum.
            minStringLen = Math.Min(minStringLen, words[i].Length);
        }
        
        minStringLen *= 2;
        
        // Now, what we want to do is consider a specialized PrefixTreeTraversal
        // of each string that meets out minStringLen requirements.
        foreach (string word in words) {
            if (word.Length < minStringLen) {
                continue;
            }
            
            bool found = FindCombinationFromWord(word, root);
            
            if (found) {
                results.Add(word);
            }
        }
        
        return results;
    }
    
    private bool FindCombinationFromWord(string word, PrefixTreeNode root) {
        Stack<int> searchStringIdx = new Stack<int>();
        
        searchStringIdx.Push(0);
        
        while (searchStringIdx.Count > 0) {
            int idx = searchStringIdx.Pop();
            
            // Start traversing the PrefixTree until we find a word terminator node.
            PrefixTreeNode curr = root;
            int charIdx = idx;
            
            while (curr != null && charIdx < word.Length) {
                if (curr.terminatesWord) {
                    // We've found a word, so we should try searching again for
                    // the word ignoring the first charIdx chars in front.
                    // Unless we've also reached the end of the word...
                    if (charIdx != word.Length) {
                        searchStringIdx.Push(charIdx);
                    }
                }
                
                // In either case, keep searching down until we reach a leaf node
                // (or cannot progress further).
                curr = curr.children.ContainsKey(word[charIdx]) ? curr.children[word[charIdx]] : null;
                
                // If curr isn't null we'll continue searching at the next charIdx.
                if (curr != null) {
                    charIdx++;
                }
            }
            
            // Did we reach a leaf node?
            if (charIdx == word.Length) {
                // Was this at least the second traversal for this word?
                // (This implies we've used two words to form this larger word)
                if (idx > 0) {
                    // Then we found a match!
                    return true;
                }
            }
        }
        
        return false;
    }
}

public class PrefixTreeNode {
    public Dictionary<char, PrefixTreeNode> children;
    
    // If this PrefixTreeNode terminates a word, its index in the original 
    // list is here. As there are no duplicates we don't need a list.
    public bool terminatesWord;
    
    public PrefixTreeNode() {
        children = new Dictionary<char, PrefixTreeNode>();
        terminatesWord = false;
    }
    
    public void AddWord(int charIdx, string word) {
        if (charIdx == word.Length) {
            terminatesWord = true;
            return;
        }
        
        if (!children.ContainsKey(word[charIdx])) {
            children.Add(word[charIdx], new PrefixTreeNode());
        }
        
        children[word[charIdx]].AddWord(charIdx + 1, word);
    }
    
}
// https://leetcode.com/problems/word-search-ii/

public class Solution {
    private int[][] searchSpace = new int[4][] { new int[]{ -1, 0 }, new int[]{ 1, 0 }, new int[]{ 0, -1 }, new int[]{ 0, 1 } };
    
    public IList<string> FindWords(char[][] board, string[] words) {
        if (board == null || board.Length == 0 || board[0].Length == 0 || words == null || words.Length == 0) {
            return new List<string>();
        }
        
        HashSet<string> results = new HashSet<string>();
        TrieNode root = new TrieNode();
        HashSet<string> visited = new HashSet<string>();
        
        // For every word we want to find, add it into the Trie.
        // We'll then search from every board[i][j] to see if we can form
        // a word in the Trie.
        
        // For larger problems, we'll also want to only include words in the Trie that could possibly be formed
        // from some combination in the board. So build up letter frequencies first and toss and that don't match.
        Dictionary<char, int> boardFreqs = new Dictionary<char, int>();
        for (int row = 0; row < board.Length; row++) {
            for (int col = 0; col < board[row].Length; col++) {
                char c = board[row][col];
                
                if (!boardFreqs.ContainsKey(c)) {
                    boardFreqs.Add(c, 0);
                }
                
                boardFreqs[c]++;
            }
        }
        
        foreach (var word in words) {
            Dictionary<char, int> wordFreqs = BuildWordFreqs(word);
            if (!ValidateFreqs(boardFreqs, wordFreqs)) {
                continue;
            }
            
            this.AddWordToTrie(root, word);
        }
        
        for (int row = 0; row < board.Length; row++) {
            for (int col = 0; col < board[row].Length; col++) {
                // Can we start forming a word with the current char?
                if (root.Children.ContainsKey(board[row][col])) {
                    visited.Clear();
                    visited.Add(this.CoordToKey(row, col));
                    
                    HashSet<string> foundWords = new HashSet<string>();
                    this.SearchWordsFromPosition(board, row, col, root, visited, foundWords);
                    results.UnionWith(foundWords);
                }
            }
        }
        
        return results.ToList();
    }
    
    private Dictionary<char, int> BuildWordFreqs(string word) {
        var freqs = new Dictionary<char, int>();
        
        foreach (char c in word) {
            if (!freqs.ContainsKey(c)) {
                freqs.Add(c, 0);
            }

            freqs[c]++;
        }
        
        return freqs;
    }
    
    private bool ValidateFreqs(Dictionary<char, int> boardFreqs, Dictionary<char, int> wordFreqs) {
        foreach (var kvp in wordFreqs) {
            if (!boardFreqs.ContainsKey(kvp.Key)) {
                return false;
            }
            
            if (boardFreqs[kvp.Key] < kvp.Value) {
                return false;
            }
        }
        
        return true;
    }
    
    private void SearchWordsFromPosition(char[][] board, int row, int col, TrieNode root, HashSet<string> visited, HashSet<string> foundWords) {
        if (root.CompletedWord) {
            foundWords.Add(root.Word);
        }
        
        if (row < 0 || row >= board.Length) {
            return;
        }
        
        if (col < 0 || col >= board[row].Length) {
            return;
        }
        
        if (!root.Children.ContainsKey(board[row][col])) {
            return;
        }
        
        // We know we have something here in a child node of root. So now search in all 4 directions from it.
        TrieNode next = root.Children[board[row][col]];
        
        for (int i = 0; i < this.searchSpace.Length; i++) {
            int nextRow = row + this.searchSpace[i][0];
            int nextCol = col + this.searchSpace[i][1];
            
            string key = CoordToKey(nextRow, nextCol);
            
            // Already visited this element before? Move on.
            if (visited.Contains(key)) {
                continue;
            }
            
            visited.Add(key);
            SearchWordsFromPosition(board, nextRow, nextCol, next, visited, foundWords);
            visited.Remove(key);
        }        
    }
    
    private void AddWordToTrie(TrieNode root, string word) {
        TrieNode curr = root;
        
        foreach (var c in word) {
            if (!curr.Children.ContainsKey(c)) {
                curr.Children.Add(c, new TrieNode());
            }
            
            curr = curr.Children[c];
        }
        
        curr.CompletedWord = true;
        curr.Word = word;
    }
    
    private string CoordToKey(int row, int col) {
        return $"{row}_{col}";
    }
}

public class TrieNode {
    public Dictionary<char, TrieNode> Children { get; set; }
    public bool CompletedWord { get; set; }
    public string Word { get; set; }
    
    public TrieNode() {
        this.Children = new Dictionary<char, TrieNode>();
    }
}
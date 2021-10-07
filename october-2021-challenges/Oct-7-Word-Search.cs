// https://leetcode.com/problems/word-search/

public class Solution {
    public bool Exist(char[][] board, string word) {
        if (board == null || board.Length == 0) {
            return false;
        } else if (word.Length == 0) {
            return true;
        }
        
        HashSet<string> visited = new HashSet<string>();
        
        // Scan the board to find a matching starting char, and then try to find the remaining words.
        for (int row = 0; row < board.Length; row++) {
            for (int col = 0; col < board[row].Length; col++) {
                if (board[row][col] == word[0]) {
                    string key = VisitedKey(row, col);
                    
                    visited.Add(key);
                    
                    if (ScanForWord(board, visited, row, col, word, 1)) {
                        return true;
                    }
                    
                    visited.Remove(key);
                }
            }
        }
        
        return false;
    }
    
    private bool ScanForWord(char[][] board, HashSet<string> visited, int row, int col, string word, int idx) {
        if (idx >= word.Length) {
            return true;
        }
        
        bool found = false;
        
        // Do a depth-first search along any paths that have the next matching character.
        if (row > 0 && !visited.Contains(VisitedKey(row - 1, col)) && board[row - 1][col] == word[idx]) {
            string key = VisitedKey(row - 1, col);
            
            visited.Add(key);
            found |= ScanForWord(board, visited, row - 1, col, word, idx + 1);
            visited.Remove(key);
        }
        
        if (col > 0 && !visited.Contains(VisitedKey(row, col - 1)) && board[row][col - 1] == word[idx]) {
            string key = VisitedKey(row, col - 1);
            
            visited.Add(key);
            found |= ScanForWord(board, visited, row, col - 1, word, idx + 1);
            visited.Remove(key);
        }
        
        if (row < board.Length - 1 && !visited.Contains(VisitedKey(row + 1, col)) && board[row + 1][col] == word[idx]) {
            string key = VisitedKey(row + 1, col);
            
            visited.Add(key);
            found |= ScanForWord(board, visited, row + 1, col, word, idx + 1);
            visited.Remove(key);
        }
        
        if (col < board[row].Length - 1 && !visited.Contains(VisitedKey(row, col + 1)) && board[row][col + 1] == word[idx]) {
            string key = VisitedKey(row, col + 1);
            
            visited.Add(key);
            found |= ScanForWord(board, visited, row, col + 1, word, idx + 1);
            visited.Remove(key);
        }
        
        return found;
    }
    
    private string VisitedKey(int row, int col) {
        return $"{row}_{col}";
    }
}
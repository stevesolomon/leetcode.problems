// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/546/week-3-july-15th-july-21st/3397/

public class Solution {
    public bool Exist(char[][] board, string word) {
        if (board == null || board.Length == 0) {
            return false;
        } else if (string.IsNullOrWhiteSpace(word)) {
            return true;
        }
        
        for (int row = 0; row < board.Length; row++) {
            for (int col = 0; col < board[row].Length; col++) {
                if (board[row][col] == word[0]) {
                    HashSet<string> visited = new HashSet<string>();
                    visited.Add(GenerateCoord(row, col));
                    
                    if (FindWord(board, word, 1, row, col, visited)) {
                        return true;
                    }
                }
            }
        }        
        
        return false;        
    }
    
    private bool FindWord(char[][] board, string word, int wordIdx, int row, int col, HashSet<string> visited) {
        if (wordIdx >= word.Length) {
            return true;
        }
        
        bool result = false;
        
        string coord = GenerateCoord(row - 1, col);
        
        if (row > 0 && board[row - 1][col] == word[wordIdx] && !visited.Contains(coord)) {
            visited.Add(GenerateCoord(row - 1, col));
            result |= FindWord(board, word, wordIdx + 1, row - 1, col, visited);
            visited.Remove(GenerateCoord(row - 1, col));
            
            if (result) {
                return true;
            }
        }
        
        coord = GenerateCoord(row + 1, col);
        
        if (row < board.Length - 1 && board[row + 1][col] == word[wordIdx] && !visited.Contains(coord)) {
            visited.Add(GenerateCoord(row + 1, col));
            result |= FindWord(board, word, wordIdx + 1, row + 1, col, visited);
            visited.Remove(GenerateCoord(row + 1, col));
            
            if (result) {
                return true;
            }
        }
        
        coord = GenerateCoord(row, col - 1);
        
        if (col > 0 && board[row][col - 1] == word[wordIdx] && !visited.Contains(coord)) {
            visited.Add(GenerateCoord(row, col - 1));
            result |= FindWord(board, word, wordIdx + 1, row, col - 1, visited);
            visited.Remove(GenerateCoord(row, col - 1));
            
            if (result) {
                return true;
            }
        }
        
        coord = GenerateCoord(row, col + 1);
        
        if (col < board[row].Length - 1 && board[row][col + 1] == word[wordIdx] && !visited.Contains(coord)) {
            visited.Add(GenerateCoord(row, col + 1));
            result |= FindWord(board, word, wordIdx + 1, row, col + 1, visited);
            visited.Remove(GenerateCoord(row, col + 1));
            
            if (result) {
                return true;
            }
        }
        
        return result;
    }
    
    private string GenerateCoord(int x, int y) {
        return $"{x}_{y}";
    }
}
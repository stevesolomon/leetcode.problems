// https://leetcode.com/problems/word-search/description/

public class Solution {
    public bool Exist(char[,] board, string word) {
        if (string.IsNullOrWhiteSpace(word)) {
            return true;
        }
        
        if (board == null || board.GetLength(0) == 0) {
            return false;
        }
        
        // Loop through the cells row-by-row until we find the starting character
        char toFind = word[0];
        bool[,] visited = new bool[board.GetLength(0), board.GetLength(1)];
        
        for (int x = 0; x < board.GetLength(0); x++) {
            for (int y = 0; y < board.GetLength(1); y++) {
                if (board[x,y] == toFind) {
                    if (SearchForWord(board, visited, x, y, 0, word)) {
                        return true;
                    }
                }
            }
        }
        
        return false;
    }
    
    private bool SearchForWord(char[,] board, bool[,] visited,  int x, int y, int charIdx, string word) {
        
        if (x < 0 || x >= board.GetLength(0) || y < 0 || y >= board.GetLength(1)) {
            return false;
        }
        
        if (charIdx >= word.Length || 
            board[x,y] != word[charIdx] ||
            visited[x,y]) {
            return false;
        }
        
        if (charIdx == word.Length - 1 && board[x,y] == word[charIdx]) {
            return true;
        }
        
        visited[x,y] = true;
        
        bool found = SearchForWord(board, visited, x - 1, y, charIdx + 1, word) ||
                     SearchForWord(board, visited, x + 1, y, charIdx + 1, word) ||
                     SearchForWord(board, visited, x, y - 1, charIdx + 1, word) ||
                     SearchForWord(board, visited, x, y + 1, charIdx + 1, word);
        
        if (found) {
            return true;
        }
        
        visited[x,y] = false;
        
        return false;
    }
}
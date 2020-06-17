// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/541/week-3-june-15th-june-21st/3363/

public class Solution {
    public void Solve(char[][] board) {
        if (board == null || board.Length == 0) { 
            return;
        }
        
        // We've flood-fill each set of O's as we encounter them, 
        // keeping track of which we've visited, and flip them all to X afterwards.
        // If at any time during a particular flood-fill we find an O
        // on the edge we'll ensure that we don't flip to X, but we may as well
        // continue our scanning and mark them all as visited.
        HashSet<string> visited = new HashSet<string>();
        
        for (int row = 0; row < board.Length; row++) {            
            for (int col = 0; col < board[row].Length; col++) {
                if (visited.Contains($"{row}_{col}")) {
                    continue;
                }
                
                List<Tuple<int, int>> marked = new List<Tuple<int, int>>();
                
                if (board[row][col] == 'O') {
                    bool hitEdge = FloodFill(board, row, col, visited, marked);
                    
                    if (!hitEdge) {
                        foreach (var coord in marked) {
                            board[coord.Item1][coord.Item2] = 'X';
                        }
                    }
                }
            }
        }
    }
    
    private bool FloodFill(
        char[][] board,
        int row,
        int col,
        HashSet<string> visited,
        List<Tuple<int, int>> marked) {
        
        // Have we hit the edge? Return true.
        if (row == 0 || row == board.Length - 1 || col == 0 || col == board[row].Length - 1) {
            return true;
        }
        
        // Otherwise mark this cell
        visited.Add($"{row}_{col}");
        marked.Add(new Tuple<int, int>(row, col));
        
        // And visit any other cells that aren't X and haven't already been visited.
        bool hitEdge = false;
        
        if (row > 0 && !visited.Contains($"{row - 1}_{col}") && board[row - 1][col] == 'O') {
            hitEdge |= FloodFill(board, row - 1, col, visited, marked);
        }
        
        if (row < board.Length - 1 && !visited.Contains($"{row + 1}_{col}") && board[row + 1][col] == 'O') {
            hitEdge |= FloodFill(board, row + 1, col, visited, marked);
        }
        
        if (col > 0 && !visited.Contains($"{row}_{col - 1}") && board[row][col - 1] == 'O') {
            hitEdge |= FloodFill(board, row, col - 1, visited, marked);
        }
        
        if (col < board[row].Length - 1 && !visited.Contains($"{row}_{col + 1}") && board[row][col + 1] == 'O') {
            hitEdge |= FloodFill(board, row, col + 1, visited, marked);
        }
        
        return hitEdge;                
    }
}
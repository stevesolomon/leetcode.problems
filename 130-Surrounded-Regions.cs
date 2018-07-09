// https://leetcode.com/problems/surrounded-regions/description/

public class Solution {
    public void Solve(char[,] board) {
        if (board == null || board.GetLength(0) < 3 || board.GetLength(1) < 3) {
            return;
        }
        
        bool[,] visited = new bool[board.GetLength(0), board.GetLength(1)];
        
        // Iterate through the board and test each contiguous section of 'O's found.
        // If they are enclosed by 'X's (ie: there is no 'O' in the first/last row/col)
        // then replace all the 'O's traversed with 'X's.
        for (int row = 0; row < board.GetLength(0); row++) {
            for (int col = 0; col < board.GetLength(1); col++) {
                if (visited[row,col]) {
                    continue;
                }
                
                if (board[row,col] == 'X') {
                    continue;
                }
                
                // Otherwise we have an 'O' that is part of a section we haven't seen.
                // Traverse it and perform the replacement operation if necessary.
                TraverseAndReplace(board, visited, row, col);
            }
        }
    }
    
    private void TraverseAndReplace(char[,] board, bool[,] visited, int row, int col) {
        bool hitEdge = false;
        
        // Stores cells we've touched in case we need to flip them.
        List<Tuple<int, int>> touched = new List<Tuple<int, int>>();
        
        Stack<Tuple<int, int>> traversal = new Stack<Tuple<int, int>>();
        traversal.Push(new Tuple<int, int>(row, col));
        
        visited[row, col] = true;
        
        while (traversal.Count > 0) {
            Tuple<int, int> curr = traversal.Pop();
            int currRow = curr.Item1;
            int currCol = curr.Item2;
            
            touched.Add(curr);
            
            // Are we on an edge? Mark that we've done so, but keep traversing so we 
            // can mark all these cells as visited and not worry about them later.
            if (currRow == 0 || currRow == board.GetLength(0) - 1 || currCol == 0 || currCol == board.GetLength(1) - 1) {
                hitEdge = true;
            }
            
            // Mark visited, and then try to progress in all four cardinal directions.
            if (currRow > 0 && !visited[currRow-1, currCol] && board[currRow-1, currCol] == 'O') {
                traversal.Push(new Tuple<int, int>(currRow - 1, currCol));
                visited[currRow-1, currCol] = true;
            }
            
            if (currRow < board.GetLength(0) - 1 && !visited[currRow+1, currCol] && board[currRow+1, currCol] == 'O') {
                traversal.Push(new Tuple<int, int>(currRow + 1, currCol));
                visited[currRow+1, currCol] = true;
            }
            
            if (currCol > 0 && !visited[currRow, currCol-1] && board[currRow, currCol-1] == 'O') {
                traversal.Push(new Tuple<int, int>(currRow, currCol-1));
                visited[currRow, currCol-1] = true;
            }
            
            if (currCol < board.GetLength(1) - 1 && !visited[currRow, currCol+1] && board[currRow, currCol+1] == 'O') {
                traversal.Push(new Tuple<int, int>(currRow, currCol + 1));
                visited[currRow, currCol+1] = true;
            }
        }
        
        // If we didn't hit an edge, replace all the cells we visited with 'X's
        if (!hitEdge) {
            foreach (Tuple<int, int> cell in touched) {
                board[cell.Item1, cell.Item2] = 'X';
            }
        }        
    }
}
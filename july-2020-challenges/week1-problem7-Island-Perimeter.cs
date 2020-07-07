// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/544/week-1-july-1st-july-7th/3383/

public class Solution {
    public int IslandPerimeter(int[][] grid) {
        if (grid == null || grid.Length == 0) {
            return 0;
        }
        
        // Start by finding the first land square
        int row = 0,
            col = 0;
        
        bool done = false;
        
        for (row = 0; row < grid.Length && !done; row++) {
            for (col = 0; col < grid[row].Length && !done; col++) {
                if (grid[row][col] == 1) {
                    done = true;
                }
            }
        }
        
        if (!done) {
            return 0;
        }
        
        // As we didn't 'break' from the for loops we need to decrement row and col
        // by 1 as they'll each be 1 too high (we exited the for loops by the !done check).
        row--;
        col--;
        
        // Then scan the whole island, keeping count of open edges for each cell.
        HashSet<string> visited = new HashSet<string>();
        Queue<Tuple<int, int>> toVisit = new Queue<Tuple<int, int>>();
        int edgeCount = 0;
        
        toVisit.Enqueue(new Tuple<int, int>(row, col));
        visited.Add(CoordToString(row, col));
        
        while (toVisit.Count > 0) {
            var curr = toVisit.Dequeue();
            var currRow = curr.Item1;
            var currCol = curr.Item2;
            var gridVal = grid[currRow][currCol];
            
            // Visit every other cell we can...
            // and keep track of open edges
            
            // Check above
            if (currRow == 0 || grid[currRow - 1][currCol] == 0) {
                edgeCount++;
            } else if (currRow > 0 && grid[currRow - 1][currCol] == 1 && 
                       !visited.Contains(CoordToString(currRow - 1, currCol))) {
                toVisit.Enqueue(new Tuple<int, int>(currRow - 1, currCol));
                visited.Add(CoordToString(currRow - 1, currCol));
            }
            
            // Check below
            if (currRow == grid.Length - 1 || grid[currRow + 1][currCol] == 0) {
                edgeCount++;
            } else if (currRow < grid.Length - 1 && grid[currRow + 1][currCol] == 1 && 
                       !visited.Contains(CoordToString(currRow + 1, currCol))) {
                toVisit.Enqueue(new Tuple<int, int>(currRow + 1, currCol));
                visited.Add(CoordToString(currRow + 1, currCol));
            }
            
            // Check left
            if (currCol == 0 || grid[currRow][currCol - 1] == 0) {
                edgeCount++;
            } else if (currCol > 0 && grid[currRow][currCol - 1] == 1 && 
                       !visited.Contains(CoordToString(currRow, currCol - 1))) {
                toVisit.Enqueue(new Tuple<int, int>(currRow, currCol - 1));
                visited.Add(CoordToString(currRow, currCol - 1));
            }
            
            // Check right
            if (currCol == grid[currRow].Length - 1 || grid[currRow][currCol + 1] == 0) {
                edgeCount++;
            } else if (currCol < grid[currRow].Length - 1 && grid[currRow][currCol + 1] == 1 && 
                       !visited.Contains(CoordToString(currRow, currCol + 1))) {
                toVisit.Enqueue(new Tuple<int, int>(currRow, currCol + 1));
                visited.Add(CoordToString(currRow, currCol + 1));
            }
        }
        
        return edgeCount;        
    }
    
    private string CoordToString(int row, int col) {
        return $"{row}_{col}";
    }
}
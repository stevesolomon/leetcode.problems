// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/530/week-3/3302/

public class Solution {
    public int NumIslands(char[][] grid) {
        if (grid == null || grid.Length == 0) {
            return 0;
        }
        
        bool[][] visited = new bool[grid.Length][];
        
        for (int i = 0; i < visited.Length; i++) {
            visited[i] = new bool[grid[i].Length];
        }
        
        int numIslands = 0;
        
        for (int row = 0; row < grid.Length; row++) {
            for (int col = 0; col < grid[row].Length; col++) {
                
                // Check if we've already traversed this element in our
                // scan of an island...
                if (visited[row][col]) {
                    continue;
                }
                
                // Otherwise, we can consider this as a starting point
                // of an island, and scan for the entire thing.
                if (grid[row][col] == '1') {
                    numIslands++;
                    
                    ScanIsland(grid, visited, row, col);
                }
                
            }
        }
        
        return numIslands;
    }
    
    private void ScanIsland(char[][] grid, bool[][] visited, int row, int col) {
        if (row < 0 || row >= grid.Length || 
            col < 0 || col >= grid[0].Length || 
            visited[row][col] ||
            grid[row][col] == '0') {
            return;
        }
        
        visited[row][col] = true;
        
        // Scan all four directions...
        ScanIsland(grid, visited, row + 1, col);
        ScanIsland(grid, visited, row - 1, col);
        ScanIsland(grid, visited, row, col + 1);
        ScanIsland(grid, visited, row, col - 1);        
    }
}
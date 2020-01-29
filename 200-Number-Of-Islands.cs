// https://leetcode.com/problems/number-of-islands/

public class Solution {
    public int NumIslands(char[][] grid) {
        if (grid == null || grid.Length == 0) {
            return 0;
        }
        
        bool[][] visited = new bool[grid.Length][];
        
        for (int i = 0; i < grid.Length; i++) {
            visited[i] = new bool[grid[i].Length];
        }
        
        int numIslands = 0;
        
        for (int x = 0; x < grid.Length; x++) {
            for (int y = 0; y < grid[x].Length; y++) {
                
                // If we've visited this before, or if it's a 0, ignore it.
                if (grid[x][y] == '0' || visited[x][y]) {
                    continue;
                }
                
                // Otherwise, we need to scan the island.
                numIslands++;
                ScanIsland(x, y, visited, grid);
            }
        }
        
        return numIslands;        
    }
    
    private void ScanIsland(int x, int y, bool[][] visited, char[][] grid) {
        Stack<Tuple<int, int>> traversal = new Stack<Tuple<int, int>>();
        
        traversal.Push(new Tuple<int, int>(x, y));
        
        while (traversal.Count > 0) {
            Tuple<int, int> curr = traversal.Pop();
            
            int currX = curr.Item1;
            int currY = curr.Item2;
            
            visited[currX][currY] = true;
            
            // Push the four directions around us if they're land and we haven't visited them
            if (currX - 1 >= 0 && grid[currX - 1][currY] == '1' && !visited[currX - 1][currY]) {
                traversal.Push(new Tuple<int, int>(currX - 1, currY));
            }
            
            if (currX + 1 < grid.Length && grid[currX + 1][currY] == '1' && !visited[currX + 1][currY]) {
                traversal.Push(new Tuple<int, int>(currX + 1, currY));
            }
            
            if (currY - 1 >= 0 && grid[currX][currY - 1] == '1' && !visited[currX][currY - 1]) {
                traversal.Push(new Tuple<int, int>(currX, currY - 1));
            }
            
            if (currY + 1 < grid[currX].Length && grid[currX][currY + 1] == '1' && !visited[currX][currY + 1]) {
                traversal.Push(new Tuple<int, int>(currX, currY + 1));
            }
        }
    }
}
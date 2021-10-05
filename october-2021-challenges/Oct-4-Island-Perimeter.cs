// https://leetcode.com/problems/island-perimeter/

public class Solution {
    
    private const int Land = 1;
    private const int Water = 0;
    
    public int IslandPerimeter(int[][] grid) {
        if (grid == null || grid.Length == 0) {
            return 0;
        }
        
        // Find the first instance of land and then start figuring out the perimeter.
        for (int row = 0; row < grid.Length; row++) {
            for (int col = 0; col < grid[row].Length; col++) {
                if (grid[row][col] == Land) {
                    return GetPerimeter(grid, row, col);
                }
            }
        }
        
        return 0;
    }
    
    private int GetPerimeter(int[][] grid, int row, int col) {
        
        int perimeter = 0;
        
        HashSet<string> visited = new HashSet<string>();
        Stack<(int, int)> toVisit = new Stack<(int, int)>();
        
        toVisit.Push((row, col));
        visited.Add(GetCoordLookup(row, col));
        
        // Every piece of land we can has five options for the
        // amount it adds to the perimeter:
        //   0 - Has four neighboring land cells.
        //   1 - Has three neighboring land cells.
        //   2 - Has two neighboring land cells.
        //   3 - Has one neighboring land cell.
        //   4 - Has zero neighboring land cells.
        while (toVisit.Count > 0) {
            (int currRow, int currCol) = toVisit.Pop();
            
            int totalNeighbors = 0;
            
            // Figure out how many neighbors we have, and add them to the
            // toVisit stack if we haven't already visited them.
            if (currRow > 0 && grid[currRow - 1][currCol] == Land) {
                totalNeighbors++;
                
                if (!visited.Contains(GetCoordLookup(currRow - 1, currCol))) {
                    toVisit.Push((currRow - 1, currCol));
                    visited.Add(GetCoordLookup(currRow - 1, currCol));
                }
            }
            
            if (currCol > 0 && grid[currRow][currCol - 1] == Land) {
                totalNeighbors++;
                
                if (!visited.Contains(GetCoordLookup(currRow, currCol - 1))) {
                    toVisit.Push((currRow, currCol - 1));
                    visited.Add(GetCoordLookup(currRow, currCol - 1));
                }
            }
            
            if (currRow < grid.Length - 1 && grid[currRow + 1][currCol] == Land) {
                totalNeighbors++;
                
                if (!visited.Contains(GetCoordLookup(currRow + 1, currCol))) {
                    toVisit.Push((currRow + 1, currCol));
                    visited.Add(GetCoordLookup(currRow + 1, currCol));
                }
            }
            
            if (currCol < grid[currRow].Length - 1 && grid[currRow][currCol + 1] == Land) {
                totalNeighbors++;
                
                if (!visited.Contains(GetCoordLookup(currRow, currCol + 1))) {
                    toVisit.Push((currRow, currCol + 1));
                    visited.Add(GetCoordLookup(currRow, currCol + 1));
                }
            }
            
            switch (totalNeighbors) {
                case 3:
                    perimeter += 1;
                    break;
                case 2:
                    perimeter += 2;
                    break;
                case 1:
                    perimeter += 3;
                    break;
                case 0:
                    perimeter += 4;
                    break;
                default:
                    break;
            }
        }
        
        return perimeter;
        
    }
    
    private string GetCoordLookup(int row, int col) {
        return $"{row}_{col}";
    }
}
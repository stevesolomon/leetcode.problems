// https://leetcode.com/explore/featured/card/august-leetcoding-challenge-2021/613/week-1-august-1st-august-7th/3835/

public class Solution {
    public int LargestIsland(int[][] grid) {
        if (grid == null || grid.Length  == 0 || grid[0].Length == 0) {
            return 0;
        }
        
        Dictionary<int, int> regionAreas = new Dictionary<int, int>();
        int currRegion = 2;
        int maxArea = int.MinValue;
        
        for (int x = 0; x < grid.Length; x++) {
            for (int y = 0; y < grid[x].Length; y++) {
                if (grid[x][y] == 1) {
                    // Found the start of a new island. Let's scan for the island size.
                    int area = ScanIsland(grid, x, y, currRegion);
                    maxArea = Math.Max(maxArea, area);
                    regionAreas.Add(currRegion, area);
                    currRegion++;
                }
            }
        }
        
        // Now we have our islands marked off as regions, and a set of regions and their areas.
        // Scan through every 0 in the grid now and see what the effect of flipping it would be.
        for (int x = 0; x < grid.Length; x++) {
            for (int y = 0; y < grid[x].Length; y++) {
                if (grid[x][y] == 0){
                    
                    // Get the regions to any side of us. Note that we don't want to
                    // accidentally 2x a region if we're connected to one by two sides,
                    // so store the regions we find in a hash set.
                    HashSet<int> regions = new HashSet<int>();
                    
                    if (x + 1 < grid.Length && grid[x + 1][y] != 0) {
                        regions.Add(grid[x + 1][y]);
                    }
                    
                    if (x - 1 >= 0 && grid[x - 1][y] != 0 && !regions.Contains(grid[x - 1][y])) {
                        regions.Add(grid[x - 1][y]);
                    }
                    
                    if (y + 1 < grid[x].Length && grid[x][y + 1] != 0 && !regions.Contains(grid[x][y + 1])) {
                        regions.Add(grid[x][y + 1]);
                    }
                    
                    if (y - 1 >= 0 && grid[x][y - 1] != 0 && !regions.Contains(grid[x][y - 1])) {
                        regions.Add(grid[x][y - 1]);
                    }
                    
                    // Now that we have the region's we're connected to, add all the areas
                    // up (+1 extra since we're switching ourselves to 1 as well).
                    int newArea = 1;
                    foreach (var region in regions) {
                        newArea += regionAreas[region];
                    }
                    
                    maxArea = Math.Max(maxArea, newArea);                    
                }
            }
        }
        
        return maxArea;
    }
    
    private int ScanIsland(int[][] grid, int startX, int startY, int regionNum){
        int area = 0;
        
        Stack<Tuple<int, int>> traverse = new Stack<Tuple<int, int>>();
        traverse.Push(new Tuple<int, int>(startX, startY));
        
        while (traverse.Count > 0) {
            Tuple<int, int> currCell = traverse.Pop();
            int x = currCell.Item1;
            int y = currCell.Item2;
            
            if (grid[x][y] == 1) {
                grid[x][y] = regionNum;
                area++;
                
                if (x + 1 < grid.Length && grid[x + 1][y] == 1) {
                    traverse.Push(new Tuple<int, int>(x + 1, y));
                }
                
                if (x - 1 >= 0 && grid[x - 1][y] == 1) {
                    traverse.Push(new Tuple<int, int>(x - 1, y));
                }
                
                if (y + 1 < grid[x].Length && grid[x][y + 1] == 1) {
                    traverse.Push(new Tuple<int, int>(x, y + 1));
                }
                
                if (y - 1 >= 0 && grid[x][y - 1] == 1) {
                    traverse.Push(new Tuple<int, int>(x, y - 1));
                }                
            }            
        }        
        
        return area;
    }
}
// https://leetcode.com/explore/featured/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3418/

public class Solution {
    public const int FRESH = 1;
    public const int ROTTEN = 2;
    public const int VISITED = 3;
    
    public int OrangesRotting(int[][] grid) {
        if (grid == null || grid.Length == 0) {
            return -1;
        }
        
        // First check how many fresh oranges we have total...
        // In order to have a solution we must transition all of these to rotten.
        int fresh = 0;
        
        // We also need to store the locations of all rotten oranges
        // as we will perform a breadth-first traversal from these.
        List<Tuple<int, int>> rottenLocations = new List<Tuple<int, int>>();
        
        for (int row = 0; row < grid.Length; row++) {
            for (int col = 0; col < grid[row].Length; col++) {
                if (grid[row][col] == FRESH) {
                    fresh++;
                } else if (grid[row][col] == ROTTEN) {
                    rottenLocations.Add(new Tuple<int, int>(row, col));
                }
            }
        }
        
        if (fresh == 0) {
            return 0;
        }
        
        // Now do a BFS from each rotten orange, moving only to fresh oranges
        Queue<Tuple<int, int>> toVisit = new Queue<Tuple<int, int>>(rottenLocations);
        toVisit.Enqueue(null);
        
        int minute = 0;
        
        while (toVisit.Count > 0) {
            var node = toVisit.Dequeue();
            
            if (node == null) {
                minute++;
                
                if (toVisit.Count > 0) {
                    toVisit.Enqueue(null);
                }
                
                continue;
            }
            
            
            var row = node.Item1;
            var col = node.Item2;
                        
            // Attempt to traverse all four directions if they meet the criteria.
            if (row > 0 && grid[row - 1][col] == FRESH) {
                fresh--;
                grid[row - 1][col] = VISITED;
                toVisit.Enqueue(new Tuple<int, int>(row - 1, col));                
            }
            
            if (row < grid.Length - 1 && grid[row + 1][col] == FRESH) {
                fresh--;
                grid[row + 1][col] = VISITED;
                toVisit.Enqueue(new Tuple<int, int>(row + 1, col));                
            }
            
            if (col > 0 && grid[row][col - 1] == FRESH) {
                fresh--;
                grid[row][col - 1] = VISITED;
                toVisit.Enqueue(new Tuple<int, int>(row, col - 1));                
            }
            
            if (col < grid[row].Length - 1 && grid[row][col + 1] == FRESH) {
                fresh--;
                grid[row][col + 1] = VISITED;
                toVisit.Enqueue(new Tuple<int, int>(row, col + 1));                
            }
        }
        
        if (fresh != 0) {
            return -1;
        }
        
        return minute - 1;
    }
}
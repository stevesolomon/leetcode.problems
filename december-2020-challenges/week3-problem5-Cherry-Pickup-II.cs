// https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/571/week-3-december-15th-december-21st/3571/

public class Solution {
    public int CherryPickup(int[][] grid) {
        if (grid == null || grid.Length == 0 || grid[0].Length == 0) {
            return 0;
        }
        
        int[] positions = new int[] {-1, 0, 1};        
        int[,,] lookup = new int[grid.Length, grid[0].Length, grid[0].Length];
        int highestValueFound = int.MinValue;
        
        lookup[0,0,grid[0].Length - 1] = grid[0][0] + grid[0][grid[0].Length - 1];
        
        // For each row, determine the maximum number picked by each robot for every
        // possible column combination of robots 1 and 2.
        for (int i = 1; i < grid.Length; i++) {            
            for (int onePos = 0; onePos < grid[0].Length; onePos++) {
                for (int twoPos = grid[0].Length - 1; twoPos >= 0; twoPos--) {
                    // Robot 1 is at onePos
                    // Robot 2 is at twoPos
                    // The maximum cherries we can pick up is defined by the max value of 
                    // the possible combinations of previous-row robot1 and 2 positions:
                    //  - onePos - 1, onePos, onePos + 1
                    //  - twoPos - 1, twoPos, twoPos + 1
                    // plus the value at grid[row][onePos] and grid[row][twoPos]
                    // UNLESS onePos == twoPos, then we can only add the grid value once.
                    int bestVal = int.MinValue;
                    foreach (int oldOnePosVal in positions) {
                        if (onePos + oldOnePosVal < 0 || onePos + oldOnePosVal >= grid[0].Length) {
                            continue;
                        }
                        
                        foreach (int oldTwoPosVal in positions) {
                            if (twoPos + oldTwoPosVal < 0 || twoPos + oldTwoPosVal >= grid[0].Length) {
                                continue;
                            }
                            
                            // This is a valid cell, update the best  value
                            bestVal = Math.Max(bestVal, lookup[i - 1, onePos + oldOnePosVal, twoPos + oldTwoPosVal]);
                        }
                    }
                    
                    // We have our best value, now update this new cell.
                    int oneVal = grid[i][onePos];
                    int twoVal = onePos == twoPos ? 0 : grid[i][twoPos];
                    
                    bestVal += oneVal + twoVal;                    
                    lookup[i, onePos, twoPos] = bestVal;
                    
                    highestValueFound = Math.Max(highestValueFound, bestVal);
                }
            }
        }
        
        return highestValueFound;
    }
}
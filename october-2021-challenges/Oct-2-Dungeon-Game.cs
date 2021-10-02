// https://leetcode.com/problems/dungeon-game/

public class Solution {
    public int CalculateMinimumHP(int[][] dungeon) {
        if (dungeon == null || dungeon.Length == 0) {
            return 1;
        }
        
        int n = dungeon.Length;
        int m = dungeon[0].Length;
        
        // We'll use a dynamic programming solution where we keep track
        // of the minimum (> 0) health necessary if we made it to any cell.
        // We'll start at the ending cell and work our way back to the beginning.
        // The recurrence is:
        //  T[n,m] = max(1, 1 - dungeon[n-1,m-1])
        //  T[i,j] = max(1, min(T[i + 1,j], T[j + 1, i])) - dungeon[i,j]
        int[,] lookup = new int[n, m];
        lookup[n - 1, m - 1] = Math.Max(1, 1 - dungeon[n - 1][m - 1]);
        
        for (int row = n - 1; row >= 0; row--) {
            for (int col = m - 1; col >= 0; col--) {
                
                if (row == n - 1 && col == m - 1) {
                    continue;
                }
                
                // Can't check the col, so only consider the row.
                if (col >= m - 1) {
                    lookup[row,col] = Math.Max(1, lookup[row + 1, col] - dungeon[row][col]);
                } else if (row >= n - 1) {
                    lookup[row,col] = Math.Max(1, lookup[row, col + 1] - dungeon[row][col]);
                } else {
                    int downVal = row < n - 1 ? lookup[row + 1,col] : int.MinValue;
                int rightVal = col < m - 1 ? lookup[row,col + 1] : int.MinValue;
            
                
                lookup[row,col] = Math.Max(1, Math.Min(downVal, rightVal) - dungeon[row][col]);
                }
            }
        }
        
        return lookup[0,0];;
    }
}
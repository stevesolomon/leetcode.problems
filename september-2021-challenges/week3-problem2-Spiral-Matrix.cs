// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/638/week-3-september-15th-september-21st/3977/

public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) {
            return new List<int>();
        }
        
        List<int> results = new List<int>();
        
        int minRow = 0;
        int maxRow = matrix.Length - 1;
        int minCol = 0;
        int maxCol = matrix[0].Length - 1;
        
        int total = matrix.Length * matrix[0].Length;
        bool horiz = true;
        int dir = 1;
        int x = 0;
        int y = 0;
        
        while (results.Count < total) {
            int limiter = 0;
            
            if (horiz) {
                if (dir == 1) {
                    limiter = maxCol;
                    
                    while (y <= maxCol) {
                        results.Add(matrix[x][y]);
                        y++;
                    }
                    y--;
                    x++;
                    minRow++;
                } else {
                    limiter = minCol;
                    
                    while (y >= minCol) {
                        results.Add(matrix[x][y]);
                        y--;
                    }
                    y++;
                    x--;
                    maxRow--;
                }
                
                horiz = false;
            } else  {
                if (dir == 1) {
                    limiter = maxRow;
                    
                    while (x <= maxRow) {
                        results.Add(matrix[x][y]);
                        x++;
                    }
                    x--;
                    y--;
                    maxCol--;
                } else {
                    limiter = minRow;
                    
                    while (x >= minRow) {
                        results.Add(matrix[x][y]);
                        x--;
                    }
                    x++;
                    y++;
                    minCol++;
                }
                
                horiz = true;
                
                // We only update the direction after we've processed a column.
                // We process a row then column in the same direction, then swap.
                dir = dir * -1;
            }
        }
        
        return results;
    }
}
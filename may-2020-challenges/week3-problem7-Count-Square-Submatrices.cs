// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/536/week-3-may-15th-may-21st/3336/

public class Solution {
    public int CountSquares(int[][] matrix) {
        if (matrix == null || matrix.Length == 0) {
            return 0;
        }        
        
        // First let's build up our additive table.
        // This stores the sum of 1's in every submatrix rectangle formed
        // from (0, 0) to (x, y).
        // (x, y) is computed by: (x-1, y) + (x, y-1) + (x, y) - (x-1, y-1) 
        // The final subtraction is to negative the duplicate values that are overlapped
        // in the submatrices (x-1, y) and (x, y-1).
        int[][] additive = new int[matrix.Length][];
        
        for (int row = 0; row < matrix.Length; row++) {
            additive[row] = new int[matrix[row].Length];
            
            for (int col = 0; col < matrix[row].Length; col++) {
                int val = matrix[row][col];
                
                if (row > 0 && col > 0) {
                    val -= additive[row-1][col-1];
                }
                
                if (row > 0) {
                    val += additive[row-1][col];
                }
                
                if (col > 0) {
                    val += additive[row][col-1];
                }
                
                additive[row][col] = val;
            }
        }
        
        // Now that we have our table, we'll loop through every new "root" of a submatrix.
        // From there, we'll move diagonally down/right in the additive table. Every "step"
        // beyond our root requires the additive value of x^x to form a square of 1's.
        // Note that we need to "adjust" the additive value to take into account that our
        // submatrix squares may not be rooted at (0,0), which the additive table assumed.
        // This requires we move "step" columns back and subtract that value.
        int totalSquares = 0;
        
        for (int row = 0; row < matrix.Length; row++) {
            for (int col = 0; col < matrix[row].Length; col++) {
                int size = 0;
                
                while (row + size < matrix.Length && col + size < matrix[row + size].Length) {
                    int requiredVal = (size + 1) * (size + 1);
                    int additiveVal = additive[row + size][col + size];
                    
                    // Subtract the value of the columnar submatrix to our left.
                    if (col - 1 >= 0) {
                        additiveVal -= additive[row + size][col - 1];
                    }
                    
                    // Substract the value of the row-wise submatrix above us.
                    if (row - 1 >= 0) {
                        additiveVal -= additive[row - 1][col + size];
                    }
                    
                    // If we subtract both the columnar and row-wise submatrices,
                    // there was some overlap in them, meaning we subtracted too much!
                    // Re-add the submatrix to our diagonal.
                    if (row - 1 >= 0 && col - 1 >= 0) {
                        additiveVal += additive[row - 1][col - 1];
                    }
                    
                    if (additiveVal >= requiredVal) {
                        totalSquares++;
                    }
                    
                    size++;
                }                
            }
        }
        
        return totalSquares;       
    }
}
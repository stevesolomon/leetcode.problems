// https://leetcode.com/problems/count-square-submatrices-with-all-ones/

public class Solution {
    public int CountSquares(int[][] matrix) {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) {
            return 0;
        }
        
        // First, build up a new matrix containing the number of 1s in each submatrix 
        // with origin at (0,0) and bottom-right at the current element.
        // While we do this scan we can also count the total 1s, wich gives us counts for squares of size 1.
        int total = 0;
        int[][] additive = new int[matrix.Length][];
        
        for (int row = 0; row < matrix.Length; row++) {
            additive[row] = new int[matrix[row].Length];
            
            for (int col = 0; col < matrix[row].Length; col++) {
                int modifier = matrix[row][col];
                total += modifier;
                
                // additive[row][col] = additive[row-1][col] + additive[row][col-1] - additive[row-1][col-1] + modifier
                // Unless we are on the top or left edges of the matrix, in which case:
                // additive[row][col] = additive[row-1][col] + modifier or,
                //                    = additive[row][col-1] + modifier
                if (row == 0 && col == 0) {
                    additive[row][col] = modifier;
                } else if (row == 0) {
                    additive[row][col] = additive[row][col-1] + modifier;
                } else if (col == 0) {
                    additive[row][col] = additive[row-1][col] + modifier;
                } else {
                    additive[row][col] = additive[row-1][col] + additive[row][col-1] + modifier - additive[row-1][col-1];
                }
            }
        }
                
        // Now scan for each possible type of square submatrix. When testing a submatrix of size x, the following rule holds:
        // Does x encompass the entire matrix? (x spreads to col = 0 and row = 0)
        //    additive[row][col] >= x^2
        // Does x spread to col = 0? (col - (x - 1) == 0), then we need to remove the submatrix above us
        //    additive[row][col] - additive[row - x][col] >= x^2
        // Does x spread to row = 0? Then we need to remove the submatrix to the left of us
        //    additive[row][col] - additive[row][col - x] >= x^2
        // Otherwise, we need to remove the submatrix to the left of us and above us. Note that we're doubly removing some overlap,
        // so we have to re-add the submatrix diagonally from us
        //    additive[row][col] - additive[row - x][col] - additive[row][col - x] + additive[row - x][col - x]
        for (int row = 1; row < matrix.Length; row++) {
            for (int col = 1; col < matrix[0].Length; col++) {
                
                // We can ignore cells with a zero..
                if (matrix[row][col] == 0) {
                    continue;
                }
                
                // We only need to bother testing square sizes that can fit in our current size submatrix.
                // This can be determined by min(row, col) + 1 
                // ie: row = 1, col = 1 --> max of 2x2 square.
                int maxCurrSquareSize = Math.Min(row, col) + 1;                

                for (int squareSize = 2; squareSize <= maxCurrSquareSize; squareSize++) {
                    int targetVal = (int) Math.Pow(squareSize, 2);
                    int minCol = col - (squareSize - 1);
                    int minRow = row - (squareSize - 1);

                    if (minCol == 0 && minRow == 0) {
                        total += additive[row][col] >= targetVal ? 1 : 0;
                    } else if (minCol == 0) {
                        total += additive[row][col] - additive[row - squareSize][col] >= targetVal ? 1 : 0;
                    } else if (minRow == 0) {
                        total += additive[row][col] - additive[row][col - squareSize] >= targetVal ? 1 : 0;
                    } else {
                        total += additive[row][col] - additive[row - squareSize][col] - additive[row][col - squareSize] + additive[row - squareSize][col - squareSize] >= targetVal ? 1 : 0;
                    }
                }
            }
        }
        
        return total;
    }
}
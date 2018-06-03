// https://leetcode.com/problems/maximal-square/description/

public class Solution {
    public int MaximalSquare(char[,] matrix) {
        
        if (matrix == null || matrix.GetLength(0) == 0) {
            return 0;
        }
        
        // [x,y] in our lookup table stores the side length of a square with [x,y]
        // as the bottom-right cell.
        int[,] lookup = new int[matrix.GetLength(0),matrix.GetLength(1)];
        
        // We need to dynamically set largest size based on whether or not
        // we find any 1's during our initial scan.
        int largestSize = 0;
        
        // Initialize our lookup table with the smallest squares possible
        // (1 if we have a 1 in this cell).
        for (int i = 0; i < matrix.GetLength(0); i++) {            
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (matrix[i,j] == '1') {
                    lookup[i,j] = 1;
                    largestSize = 1;
                } else {
                    lookup[i,j] = 0;
                }
            }
        }
        
        for (int i = 1; i < matrix.GetLength(0); i++) {
            for (int j = 1; j < matrix.GetLength(1); j++) {
                
                // If this cell had a 0 to begin with, we can't do anything here.
                if (lookup[i,j] == 0) {
                    continue;
                }
                
                // Otherwise, this cell has a 1, so check the previous cells to see if there's a square
                // forming there that we can be a part of.
                // We take the minimum value, as we can only help to form the smallest square possible
                // (and then we add 1 as we're increasing the length of that square).
                lookup[i,j] = Math.Min(lookup[i,j-1], Math.Min(lookup[i-1,j], lookup[i-1,j-1])) + 1;
                
                largestSize = Math.Max(largestSize, lookup[i,j]);
            }
        }
        
        return largestSize * largestSize;        
    }
}
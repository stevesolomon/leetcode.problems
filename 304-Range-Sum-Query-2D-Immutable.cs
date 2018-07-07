// https://leetcode.com/problems/range-sum-query-2d-immutable/description/

public class NumMatrix {
    
    int[,] sumLookup;

    public NumMatrix(int[,] matrix) {
        sumLookup = new int[matrix.GetLength(0), matrix.GetLength(1)];
        
        GenerateSumLookup(matrix);
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
        // The sum within a particular region is:
        // sumLookup[row2,col2] MINUS
        // sumLookup[row1-1,col2] MINUS
        // sumLookup[row2,col1-1] PLUS
        // sumLookup[row1-1,col1-1] (this removes the duplicate sum subtracted by the above two)

        int sum = sumLookup[row2, col2];

        if (row1 > 0) {
            sum -= sumLookup[row1 - 1, col2];
        }

        if (col1 > 0) {
            sum -= sumLookup[row2, col1 - 1];
        }

        if (row1 > 0 && col1 > 0) {
            sum += sumLookup[row1 - 1, col1 - 1];
        }

        return sum;
    }
    
    private void GenerateSumLookup(int[,] matrix) {
        
        for (int row = 0; row < matrix.GetLength(0); row++) {
            for (int col = 0; col < matrix.GetLength(1); col++) {
                // Sum at the current element is:
                // Our value PLUS
                // Sum at the element directly above us PLUS
                // Sum at the element directly to the left of us MINUS
                // Sum at the element up-left of us (this removes the duplicate sum
                // captured by the above two cases).
                int sum = matrix[row,col];
                
                if (row > 0) {
                    sum += sumLookup[row - 1, col];
                }
                
                if (col > 0) {
                    sum += sumLookup[row, col - 1];
                }
                
                if (row > 0 && col > 0) {
                    sum -= sumLookup[row - 1, col - 1];
                }
                
                sumLookup[row,col] = sum;
            }
        }
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */
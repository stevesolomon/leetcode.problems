// https://leetcode.com/problems/maximal-rectangle/

public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        
        if (matrix == null || matrix.Length == 0) {
            return 0;
        }
        
        // We can solve this by solving an increasingly larger series of max rectangle in a histogram problem.
        // Going row-by-row, we generate the "histogram" 
        //  - If the current column is a '1', add it to the current value for that column index in the histogram. 
        //  - If the current column is a '0', reset the current value in the histogram.
        // We are effectively determining how many consecutive '1's we have throughout these rows of the matrix,
        // as they are the only ones that can contribute to a rectangle from rows 0 .. i in the matrix.
        int[] histogram = new int[matrix[0].Length];
        int largestRect = 0;
        
        for (int row = 0; row < matrix.Length; row++) {
            
            // First generate the histogram
            for (int col = 0; col < matrix[0].Length; col++) {
                if (matrix[row][col] == '1') {
                    histogram[col]++;
                } else {
                    histogram[col] = 0;
                }
            }
            
            // Now solve for the largest rectangle in the current histogram
            largestRect = Math.Max(SolveHistogram(histogram), largestRect);
        }
        
        return largestRect;
    }
    
    private int SolveHistogram(int[] histogram) {
        
        int largestRect = 0;
        
        // We scan forwards through the histogram following the rules:
        //   - Insert the current index into the stack if the histogram value is smaller than 
        //     the current value pointed to by the top of the stack.
        //   - Else, pop indices from the stack until the top points to a histogram value smaller than (or equal to) ours.
        Stack<int> histogramIndices = new Stack<int>();
        histogramIndices.Push(0);
        
        for (int i = 1; i < histogram.Length; i++) {
            
            int currVal = histogram[i];
            
            // Continually pop from the stack until the histogram value is lower than our current one.
            while (histogramIndices.Count > 0 && histogram[histogramIndices.Peek()] >= currVal) {
                int topIndex = histogramIndices.Pop();
                int topVal = histogram[topIndex];
                
                // If we still have values in the stack, that means we can form a rectangle of this height (topVal) from our current
                // index, i, all the way to whatever the top index is currently in the stack.
                if (histogramIndices.Count > 0) {
                    largestRect = Math.Max(largestRect, topVal * (i - histogramIndices.Peek() - 1));
                } else { // If we have no other elements in the stack that means this last one was the lowest height we've seen thus far... so the rectangle is that height from 0 ... i.
                    largestRect = Math.Max(largestRect, topVal * i);
                }
            }
            
            histogramIndices.Push(i);
        }
        
        // Now just keep popping the stack until it's empty...
        while (histogramIndices.Count > 0) {
            int topIndex = histogramIndices.Pop();
            int topVal = histogram[topIndex];

            if (histogramIndices.Count > 0) {
                largestRect = Math.Max(largestRect, topVal * (histogram.Length - histogramIndices.Peek() - 1));
            } else {
                largestRect = Math.Max(largestRect, topVal * histogram.Length);
            }
        }
        
        return largestRect;
    }
}
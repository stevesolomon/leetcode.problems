// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/542/week-4-june-22nd-june-28th/3373/

public class Solution {
    public int NumSquares(int n) {
        if (n <= 1) {
            return 1;
        }
        
        List<int> squares = new List<int>();
        int num = 1;
        
        while (num * num <= n) {
            int psq = num * num;
            if (psq == n) {
                return 1;
            }
            
            squares.Add(psq);
            num++;            
        }
        
        // Lookup[x][y] stores the min number of perfect squares
        // needed to create a value of X, using perfect squares options <= Y (index).
        int[][] lookup = new int[n + 1][];
        
        // Pre-populate for our first perfect square here, as we only have a single value to consider.
        for (int i = 0; i <= n; i++) {
            lookup[i] = new int[squares.Count];
            
            // Solve for every possible value i using only the first perfect square
            int firstpsq = squares[0];
            if (i % firstpsq == 0) {
                lookup[i][0] = i / firstpsq; 
            } else {
                lookup[i][0] = int.MaxValue;
            }       
        }
        
        // For value 0, we need 0 perfect squares.
        for (int i = 0; i < squares.Count; i++) {
            lookup[0][i] = 0;
        }
        
        // Now work our way up, for every value and perfect square combination
        for (int val = 1; val <= n; val++) {
            
            for (int i = 1; i < squares.Count; i++) {
                int psq = squares[i];
                
                // For a given value and max perfect square value, we can either build it up
                // using:
                //  (1) The previous set of perfect squares for the same value
                //  (2) However many it took us to construct value - psq, plus one (taking the current psq to complete the value).
                // Alternatively, if our perfect square is above our val, we must use the same number as 
                // we used for the last perfect square value.
                if (psq <= val) {
                    lookup[val][i] = Math.Min(lookup[val][i - 1], lookup[val - psq][i] + 1);
                } else {
                    lookup[val][i] = lookup[val][i - 1];
                }
            }            
        }
        
        return lookup[n][squares.Count - 1];
    }
}
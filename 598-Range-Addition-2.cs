// https://leetcode.com/problems/range-addition-ii/description/

public class Solution {
    public int MaxCount(int m, int n, int[,] ops) {
        if (m <= 0 || n <= 0 || ops == null) {
            return 0;
        }
        
        int minX = m;
        int minY = n;
        
        // The maximum number will always be in 0,0.
        // This implies that the smallest op performed dictates the count of the maximum number.
        for (int i = 0; i < ops.GetLength(0); i++) {
            int x = ops[i,0];
            int y = ops[i,1];
            
            minX = Math.Min(x, minX);
            minY = Math.Min(y, minY);
        }
        
        return minX * minY;
    }
}
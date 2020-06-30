// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/543/week-5-june-29th-june-30th/3375/

public class Solution {
    public int UniquePaths(int m, int n) {
        if (m == 0 && n == 0) {
            return 0;
        }
        
        int[,] lookup = new int[m,n];
        
        // There is only one path across the top row, and left column
        for (int i = 0; i < m; i++) {
            lookup[i,0] = 1;
        }
        
        for (int i = 0; i < n; i++) {
            lookup[0,i] = 1;
        }
        
        // For every other cell [x,y] there are [x-1,y] + [x,y-1] paths.
        for (int x = 1; x < m; x++) {
            for (int y = 1; y < n; y++) {
                lookup[x,y] = lookup[x-1,y] + lookup[x,y-1];
            }
        }
        
        return lookup[m - 1, n - 1];
    }
}
// https://leetcode.com/problems/climbing-stairs/submissions/

public class Solution {
    public int ClimbStairs(int n) {
        if (n < 2) {
            return 1;
        } else if (n == 2) {
            return 2;
        }
        
        int[] results = new int[n];
        results[0] = 1;
        results[1] = 2;
        
        for(int i = 2; i < n; i++) {
            results[i] = results[i - 1] + results[i - 2];
        }
        
        return results[n - 1];
    }
}
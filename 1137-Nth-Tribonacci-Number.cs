// https://leetcode.com/problems/n-th-tribonacci-number/

public class Solution {
    public int Tribonacci(int n) {
        
        int[] lookup = new int[n + 1];
        
        return Tribonacci(n, lookup);        
    }
    
    private int Tribonacci(int n, int[] lookup) {
        if (n == 0) {
            return 0;
        } else if (n == 1) {
            return 1;
        } else if (n == 2) {
            return 1;
        }
        
        if (lookup[n] != 0) {
            return lookup[n];
        }
        
        lookup[n] = Tribonacci(n-1, lookup) + Tribonacci(n-2, lookup) + Tribonacci(n-3, lookup);
        
        return lookup[n];        
    }
}
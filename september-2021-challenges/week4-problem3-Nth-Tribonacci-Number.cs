// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/639/week-4-september-22nd-september-28th/3986/

public class Solution {
    public int Tribonacci(int n) {
                
        if (n == 0) {
            return 0;
        } else if (n == 1 || n == 2) {
            return 1;
        }
        
        int nStart = 0;
        int nPlus1 = 1;
        int nPlus2 = 1;
        int val = 0;
        
        for (int i = 3; i <= n; i++) {
            val = nStart + nPlus1 + nPlus2;
            
            nStart = nPlus1;
            nPlus1 = nPlus2;
            nPlus2 = val;
        }
        
        return val;
    }
}
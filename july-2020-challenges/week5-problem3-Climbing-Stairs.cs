// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/548/week-5-july-29th-july-31st/3407/

public class Solution {
    public int ClimbStairs(int n) {
        if (n <= 3) {
            return n;
        }
        
        // At step_n, we have step_n-1 + step_n-2 options.
        int lastStep = 2;
        int twoStepsBack = 1;
        int total = lastStep + twoStepsBack;
        
        for (int i = 3; i < n; i++) {
            twoStepsBack = lastStep;
            lastStep = total;
            total += twoStepsBack;
        }
        
        return total;
    }
}
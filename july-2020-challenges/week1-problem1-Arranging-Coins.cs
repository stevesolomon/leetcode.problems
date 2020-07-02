// https://leetcode.com/explore/featured/card/july-leetcoding-challenge/544/week-1-july-1st-july-7th/3377/

public class Solution {
    public int ArrangeCoins(int n) {
        int steps = 1;
        
        while (n >= 0) {
            n -= steps;
            steps++;
        }
        
        steps--;
        
        return n == 0 ? steps : steps - 1;
    }
}
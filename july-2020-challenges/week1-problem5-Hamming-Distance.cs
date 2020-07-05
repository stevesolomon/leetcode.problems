// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/544/week-1-july-1st-july-7th/3381/

public class Solution {
    public int HammingDistance(int x, int y) {
        int test = x ^ y;
        int mask = 1;
        int result = 0;
        
        while (test > 0) {
            if ((test & mask) == 1) {
                result++;
            }
            
            test >>= 1;
        }
        
        return result;        
    }
}
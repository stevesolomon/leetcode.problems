// https://leetcode.com/explore/featured/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3412/

public class Solution {
    public bool IsPowerOfFour(int num) {
        if (num == 1) {
            return true; 
        }
        else if (num < 4) {
            return false;
        }
        
        int mask = 4;
        int testCount = 0;
        
        while (testCount < 16) {
            if ((num & mask) == num) {
                return true;
            }
            
            mask <<= 2;
            testCount++;
        }
        
        return false;
    }
}
// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/540/week-2-june-8th-june-14th/3354/

public class Solution {
    public bool IsPowerOfTwo(int n) {        
        int numOnes = 0;      
        while (n > 0) {
            if ((n & 1) == 1) {
                numOnes++;
            }
            
            n >>= 1;
        }
        
        return numOnes == 1;
    }
}
// https://leetcode.com/problems/power-of-two/description/

public class Solution {
    public bool IsPowerOfTwo(int n) {
        if (n == 0) {
            return false;
        } else if (n == 1) {
            return true;
        } else if (n < 0) {
            return false;
        }
        
        // Keep dividing by two, if we ever get an odd number it's
        // not a power of 2
        while (n > 0) {
            
            if (n == 1) {
                return true;
            }
            
            if (n % 2 != 0) {
                return false;
            }
            
            n /= 2;
        }
        
        return true;
    }
}
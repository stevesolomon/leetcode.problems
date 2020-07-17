// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/546/week-3-july-15th-july-21st/3392/

public class Solution {
    public double MyPow(double x, int n) {
        if (x == 0 || x == 1 || n == 1) {
            return x;
        } else if (n == 0) {
            return 1;
        }
        
        long nl = (long) n;
        
        if (n < 0) {
            x = 1.0 / x;
            nl = -nl;
        }
        
        double temp = 1;
        double val = x;
        
        while (nl > 1) {
            if (nl % 2 == 0) {
                val *= val;
                nl /= 2;
            } else {
                temp *= val;
                val *= val;
                nl = (nl - 1) / 2;
            }
        }
        
        return val * temp;
    }
}
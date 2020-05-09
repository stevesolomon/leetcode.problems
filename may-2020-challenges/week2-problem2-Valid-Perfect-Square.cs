// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3324/

public class Solution {
    public bool IsPerfectSquare(int num) {
        if (num == 0) {
            return true;
        } else if (num == 1) {
            return true;
        }
        
        // We will perform a binary search along 1...(num / 2) + 1
        // and see if we can find a match.
        int low = 1;
        int hi = (num / 2) + 1;
        
        while (low <= hi) {
            int mid = low + ((hi - low) / 2);

            // Square can be much larger than an int... so use a long.
            long midSq = (long) mid * (long) mid;
            
            if (midSq == num) {
                return true;
            }
            
            if (midSq < num) {
                // Search higher
                low = mid + 1;
            } else {
                // Search lower
                hi = mid - 1;
            }
        }
        
        return false;
    }
}
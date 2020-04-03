// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/528/week-1/3284/

public class Solution {
    public bool IsHappy(int n) {
        
        if (n == 0) {
            return false;
        } else if (n == 1) {
            return true;
        }
        
        long num = (long) n;
        
        // Keep track of the numbers we've seen so we don't loop.
        HashSet<long> observed = new HashSet<long>();
        observed.Add(num);
        
        while (true) {
            long sum = 0;
            
            // Break out each digit from the current number and compute the sum.
            while (num > 0) {
                int digit = (int) num % 10;                
                sum += digit * digit;                
                num /= 10;
            }
            
            if (sum == 1) {
                return true;
            }
            
            if (observed.Contains(sum)) {
                return false;
            }
            
            observed.Add(sum);            
            num = sum;
        }  
    }
}
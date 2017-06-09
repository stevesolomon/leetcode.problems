// https://leetcode.com/problems/happy-number/#/description
public class Solution {
    public bool IsHappy(int n) {
        
        if (n == 0) {
            return false;
        } else if (n == 1) {
            return true;
        }
        
        HashSet<int> seen = new HashSet<int>();
        int currVal = n;
        
        seen.Add(n);
        
        while (true) {
            int nextVal = 0;
            
            while (currVal > 0) {
                int digit = currVal % 10;
                currVal /= 10;
                
                nextVal += (digit * digit);
            }
            
            if (nextVal == 1) {
                return true;
            }
            
            currVal = nextVal;
            
            // Break out if we're repeating a previously seen number.
            if (seen.Contains(currVal)) {
                return false;
            }
            
            seen.Add(currVal);
        }
        
        return false;
    }
}
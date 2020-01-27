// https://leetcode.com/problems/grumpy-bookstore-owner/

public class Solution {
    public int MaxSatisfied(int[] customers, int[] grumpy, int X) {
        if (customers == null || customers.Length == 0) {
            return 0;
        }
        
        if (grumpy == null || grumpy.Length == 0) {
            return 0;
        }
        
        // Generate the base solution with no X
        int baseSat = 0;
        
        for (int i = 0; i < customers.Length; i++) {
            baseSat += (grumpy[i] == 0 ? customers[i] : 0);
        }
        
        // Let's consider every sliding window for X.
        // We really just want to figure out how many *extra* customers we'd get with this X window
        // (this is all customers[i] where grumpy[i] == 1)
        // and we'll pick the biggest one at the end.        
        // Start with the base case as we have to calculate this one "manually".
        int startIdx = 0;
        int currExtra = 0;
        
        for (int i = startIdx; i < X; i++) {
            if (grumpy[i] == 1) {
                currExtra += customers[i];
            }
        }
        
        int maxExtra = currExtra;
        
        // Now that we have the case from 0...X - 1, to calculate 1...X we simply take the 
        // 0...X value, subtract customers[0] (if grumpy[0] == 1), and add customers[X] if grumpy[X] == 1
        for (int i = 1; i <= customers.Length - X; i++) {
            currExtra = currExtra - (grumpy[i - 1] == 1 ? customers[i - 1] : 0);
            currExtra += (grumpy[i + X - 1] == 1 ? customers[i + X - 1] : 0);
            
            maxExtra = Math.Max(currExtra, maxExtra);            
        }
        
        return baseSat + maxExtra;
    }
}
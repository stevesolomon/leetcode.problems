// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/534/week-1-may-1st-may-7th/3316/

/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        if (n == 0) {
            return -1;
        } else if (n == 1) {
            return this.IsBadVersion(n) ? n : -1;
        }
        
        // We will perform a binary search to find the first bad version.
        int start = 1;
        int end = n;
        int curr = 0;
        
        bool foundBadVersion = false;
        
        while (start <= end) {
            curr = start + ((end - start) / 2);
            
            if (this.IsBadVersion(curr)) {
                // We know versions [curr...n] are bad, so what
                // about [start...curr)?
                foundBadVersion = true;
                
                // Quick check first to see if the immediately earlier version is not bad.
                // If it is good, we're done.
                if (curr - 1 >= 1 && !this.IsBadVersion(curr - 1)) {
                    return curr;
                }
                
                end = curr - 1;
            } else  {
                // We know versions [start...curr] are not bad...
                // So what about (curr...end]?
                
                // Quick check first to see if the immediate next version is bad.
                // If it is bad, we're done.
                if (curr + 1 < n && this.IsBadVersion(curr + 1)) {
                    return curr + 1;
                }
                
                start = curr + 1;
            }
        }
        
        if (foundBadVersion) {
            return curr;
        } else {
            return -1;
        }
    }
}
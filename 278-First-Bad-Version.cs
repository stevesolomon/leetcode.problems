// https://leetcode.com/problems/first-bad-version/description/

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        
        if (n == 0) {
            return 0;
        } else if (n == 1) {
            return this.IsBadVersion(1) ? 1 : 0;
        }
        
        return Search(1, n);  
    }
    
    private int Search(int low, int high) {
        
        if (low == high) {
            return low;
        }
        
        int mid = low + ((high - low) / 2);
        
        bool isBad = this.IsBadVersion(mid);
        
        // This version isn't bad, search in the upper half of the space...
        if (!isBad) {
            return Search(mid + 1, high);
        } else {
            // This version is bad... is the version before it bad too?
            if (mid == 1) {
                return 1;
            } else if (this.IsBadVersion(mid - 1)) {
                // Search in the lower half of the space
                return Search(low, mid - 1);
            } else {
                // We've found the first bad instance.
                return mid;
            }
        }
    }
}
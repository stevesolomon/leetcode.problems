// https://leetcode.com/problems/kth-smallest-number-in-multiplication-table/description/

public class Solution {
    public int FindKthNumber(int m, int n, int k) {
        
        // We are searching across the entire space of possible numbers in the mult tables.
        // (not the total number of elements in the multiplication table)
        int low = 1, high = m * n;
        
        while (low <= high) {
            int mid = low + (high - low) / 2;
            
            int countLessThanMid = numLessThanMid(mid, m, n);
            
            // countLessThanMid == k does not necessarily give us the solution,
            // as we could have multiple instances of the same number. We need to
            // keep stepping until low immediately moves above high.
            if (countLessThanMid >= k) {
                high = mid - 1;
            } else {
                low = mid + 1;
            }
        }
        
        return low;
    }
    
    private int numLessThanMid(int mid, int m, int n) {
        int count = 0;
        
        // For every row in our multiplication table, we either have
        // n (every column) numbers that are less than our mid point,
        // or mid / i, whichever is smaller.
        // (Consider cases where mid actually isn't in the multiplication table
        //  but exists somewhere between two real elements in it. In this case,
        //  mid / i will return the number of elements [columns] in that row 
        //  prior to this mid point.)
        // Remember: mid here is an actual number, not the midpoint of the "array"
        // forming all of our values.
        for (int i = 1; i <= m; i++) {
            count += Math.Min(mid / i, n);
        }
        
        return count;
    }
}
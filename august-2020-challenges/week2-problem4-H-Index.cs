// https://leetcode.com/explore/featured/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3420/

public class Solution {
    public int HIndex(int[] citations) {
        if (citations == null || citations.Length == 0) {
            return 0;
        }
        
        Array.Sort(citations);
        
        // We'll do a binary search, where what we're searching for is
        // the greatest index i such that citations[i] >= i.
        int lo = 0;
        int hi = citations.Length - 1;
        int bestHIdx = 0;
        
        while (lo <= hi) {
            
            int mid = lo + ((hi - lo) / 2);
            
            // This is a candidate solution. 
            if (citations[mid] >= citations.Length - mid) {
                bestHIdx = Math.Max(bestHIdx, citations.Length - mid);
                hi = mid - 1;
            } else {
                lo = mid + 1;
            }
        }
        
        return bestHIdx;
    }
}
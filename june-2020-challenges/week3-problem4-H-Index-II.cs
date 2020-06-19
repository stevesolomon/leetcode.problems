// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/541/week-3-june-15th-june-21st/3364/

public class Solution {
    public int HIndex(int[] citations) {
        if (citations == null || citations.Length == 0) {
            return 0;
        }
        
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
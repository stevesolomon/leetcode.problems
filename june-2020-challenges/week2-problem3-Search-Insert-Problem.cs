// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/540/week-2-june-8th-june-14th/3356/

public class Solution {
    public int SearchInsert(int[] nums, int target) {
        if (nums == null || nums.Length == 0) {
            return 0;
        }
        
        int lo = 0;
        int hi = nums.Length - 1;        
        
        while (lo < hi) {
            int mid = lo + ((hi - lo) / 2);;
            
            if (nums[mid] == target) {
                return mid;
            }
            
            if (nums[mid] < target) {
                lo = mid + 1;
            } else {
                hi = mid - 1;
            }
        }
        
        // We didn't find an exact match.
        // This means that hi is <= lo - and it's possible that hi == -1
        // So reset it to 0, and then if the target value is:
        //   a) greater than nums[hi], the insertion index is one greater than hi
        //   b) lower than nums[hi], the insertion index is hi.
        hi = hi < 0 ? 0 : hi;
        
        if (nums[hi] < target) {
            hi++;
        }
        
        return hi;        
    }
}
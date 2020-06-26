// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/542/week-4-june-22nd-june-28th/3371/

public class Solution {
    public int FindDuplicate(int[] nums) {
        if (nums == null || nums.Length <= 1) {
            return 0;
        }
        
        // If there were no duplicates, and we had an array of size N
        // with 1...N values uniquely scattered around, we would be able to 
        // "traverse" the array by using the value at a[i] to move to a[value].
        // There would not be a cycle.
        // As there is at least one duplicate value, we will have a cycle in the array.
        // So, we can use a linked-list style cycle detection algorithm!
        int slowPtrIdx = nums[nums[0]];
        int fastPtrIdx = nums[slowPtrIdx];
        
        while (fastPtrIdx != slowPtrIdx) {
            slowPtrIdx = nums[slowPtrIdx];
            fastPtrIdx = nums[nums[fastPtrIdx]];
        }
        
        slowPtrIdx = nums[0];
        
        while (fastPtrIdx != slowPtrIdx) {
            slowPtrIdx = nums[slowPtrIdx];
            fastPtrIdx = nums[fastPtrIdx];
        }
        
        return slowPtrIdx;
    }
}
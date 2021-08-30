// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/617/week-5-august-29th-august-31st/3956/

public class Solution {
    public int MinPatches(int[] nums, int n) {
        long checkedNum = 1;
        int numPatched = 0;
        int i = 0;
        
        while (checkedNum <= n) {
            if (i < nums.Length && nums[i] <= checkedNum) {
                // If the current number is <= to the current sum
                // we're checking, we can construct it somehow.
                // Recall we're starting with checkedNum at 1.
                checkedNum += nums[i];
                i++;
            } else {
                // We have a missing number we cannot construct.
                // We'll assume we just add it directly.
                checkedNum += checkedNum;
                numPatched++;
            }
        }
        
        return numPatched;
    }
}
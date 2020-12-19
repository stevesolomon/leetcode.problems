// https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/571/week-3-december-15th-december-21st/3570/

public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        if (nums == null || nums.Length < 3) {
            return false;
        }
        
        int smallest = int.MaxValue;
        int nextSmallest = int.MaxValue;
        
        foreach (int num in nums) {
            
            // If num is the smallest number found thus far, it's our best candidate.
            if (num <= smallest) {
                smallest = num;
            // Otherwise if num is the second-smallest, then it's our best candidate to
            // match with smallest thus far.
            } else if (num <= nextSmallest) {
                nextSmallest = num;
            // Otherwise, the current number is larger than both smallest and nextSmallest,
            // and we know nextSmallest > smallest. Therefore we have a solution.
            } else {
                return true;
            }
        }
        
        return false;
    }
}
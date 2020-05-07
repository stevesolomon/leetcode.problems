// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/534/week-1-may-1st-may-7th/3321/

public class Solution {
    public int MajorityElement(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return -1;
        } else if (nums.Length == 1) {
            return nums[0];
        }
        
        // The majority element must appear for at least one more than half of the array.
        // This implies that, if we were to keep a counter where counter += 1 every time
        // we see the majority element, and counter -= 1 every time we don't, the counter
        // will equal at least 1 after iterating through all values in nums.
        // As we iterate, if at any point we see counter == 0, then we can use the current num
        // as the candidate element (if it is not, we must still have a majority of the real
        // candidate element to come, and it will replace the current one eventually).
        int candidate = 0;
        int count = 0;
        
        foreach (int num in nums) {
            if (num == candidate) {
                count++;
            } else if (count == 0) {
                // Current value is not the candidate and count is 0, reset the candidate.
                candidate = num;
                count = 1;
            } else {
                // Current value is not the candidate... subtract the count
                count --;
            }
        }
        
        return candidate;
    }
}
// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/638/week-3-september-15th-september-21st/3982/

public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return 0;
        }
        
        int numConsecutive = 0;
        int maxConsecutive = int.MinValue;
        
        foreach (int num in nums) {
            if (num == 1) {
                numConsecutive++;
            } else {
                numConsecutive = 0;
            }
            
            maxConsecutive = Math.Max(maxConsecutive, numConsecutive);
        }
        
        return maxConsecutive;
    }
}
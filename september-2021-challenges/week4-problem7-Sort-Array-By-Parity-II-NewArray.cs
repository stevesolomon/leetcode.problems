// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/639/week-4-september-22nd-september-28th/3990/

public class Solution {
    public int[] SortArrayByParityII(int[] nums) {
        if (nums == null || nums.Length < 2) {
            return nums;
        }
        
        int[] sorted = new int[nums.Length];
        int evenIdx = 0;
        int oddIdx = 1;
        
        foreach (int num in nums) {
            if (num % 2 == 0) {
                sorted[evenIdx] = num;
                evenIdx += 2;
            } else {
                sorted[oddIdx] = num;
                oddIdx += 2;
            }
        }        
        
        return sorted;
    }
}
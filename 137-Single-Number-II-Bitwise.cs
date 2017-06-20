// https://leetcode.com/problems/single-number-ii/#/solutions

public class Solution {
    public int SingleNumber(int[] nums) {
        int c1 = 0;
        int c2 = 0;
        
        foreach (int num in nums) {
            int temp = (~c1 & c2 & num) | (c1 & ~c2 & ~num);
            c2 = (~c1 & ~c2 & num) | (~c1 & c2 & ~num);
            c1 = temp;
        }
        
        return c1 | c2;
    }
}
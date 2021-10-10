// https://leetcode.com/problems/bitwise-and-of-numbers-range/submissions/

public class Solution {
    public int RangeBitwiseAnd(int left, int right) {
        if (left == right) {
            return left;
        }
        
        return (RangeBitwiseAnd(left >> 1, right >> 1)) << 1;
    }
}
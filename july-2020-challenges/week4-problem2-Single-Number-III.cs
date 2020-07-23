// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/547/week-4-july-22nd-july-28th/3399/

public class Solution {
    public int[] SingleNumber(int[] nums) {
        if (nums == null || nums.Length < 2) {
            return null;
        }
        
        if (nums.Length == 2) {
            return nums;
        }
        
        // First we'll xor every number together.
        // All the doubles cancel each other left, so the last
        // value is x xor y.
        // Every 1 bit means that either x or y must have a 1 bit
        // in that position (and the other, a 0 bit). But how can we tell which is which?
        // We know that all the doubled values will cancel each other out, so we 
        // can start with any arbitary 1 bit in our xor'd value, treat that as the 1
        // bit in one our numbers, isolate it, and then xor all the numbers in the 
        // array that have a 1 in that position. This will result in:
        // a xor a xor c xor c xor [x|y] xor d xor d...
        // Leaving us with just x or y isolated.
        int xorResult = 0;        
        foreach (var num in nums) {
            xorResult ^= num;
        }
        
        // Isolate a single 1 bit
        int bitPosition = 0;        
        while (((xorResult >> bitPosition) & 1) != 1) {
            bitPosition++;
        }
        
        // Now xor all the numbers in the array together that have a 1 bit in that position.
        int num1 = 0, num2 = 0;        
        foreach (var num in nums) {
            if (((num >> bitPosition) & 1) == 1) {
                num1 ^= num;
            } else {
                num2 ^= num;
            }
        }
        
        return new int[2] { num1, num2 };
    }
}
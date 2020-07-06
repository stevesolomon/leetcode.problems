// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/544/week-1-july-1st-july-7th/3382/

public class Solution {
    public int[] PlusOne(int[] digits) {
        if (digits == null || digits.Length == 0) {
            return digits;
        }
             
        digits[digits.Length - 1]++;
        bool carry = false;
        
        if (digits[digits.Length - 1] == 10) {
            carry = true;
            digits[digits.Length - 1] = 0;
        }
        
        int idx = digits.Length - 2;
        
        while (carry && idx >= 0) {
            digits[idx]++;
            
            if (digits[idx] < 10) {
                carry = false;
                break;
            }
            
            digits[idx] = 0;
            idx--;
        }
        
        // If we still have a carry we need to add a new leading digit
        if (carry) {
            int[] newDigits = new int[digits.Length + 1];
            
            for (int i = newDigits.Length - 1; i > 0; i--) {
                newDigits[i] = digits[i - 1];
            }
            
            newDigits[0] = 1;
            return newDigits;
        }
        
        return digits;
    }
}
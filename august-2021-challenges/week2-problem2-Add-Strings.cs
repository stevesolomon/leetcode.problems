// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/614/week-2-august-8th-august-14th/3875/

public class Solution {
    public string AddStrings(string num1, string num2) {
        if (string.IsNullOrWhiteSpace(num1)) {
            return num2;
        } else if (string.IsNullOrWhiteSpace(num2)) {
            return num1;
        }
        
        // Our numbers could be extremely big, so we need to work
        // one value at a time, and maintain the carry.
        int carry = 0;
        int longestLength = Math.Max(num1.Length, num2.Length);
        
        string reverse1 = new string(num1.Reverse().ToArray());
        string reverse2 = new string(num2.Reverse().ToArray());
        
        StringBuilder result = new StringBuilder();
        
        for (int i = 0; i <= longestLength; i++) {
            int currVal = 0;
            
            if (i < reverse1.Length) {
                currVal += reverse1[i] - '0';
            }
            
            if (i < reverse2.Length) {
                currVal += reverse2[i] - '0';
            }
            
            currVal += carry;
            carry = 0;
            
            if (currVal >= 10) {
                carry = currVal / 10;
                currVal = currVal % 10;
            }
            
            // Write out this value to our string
            result.Append(currVal);
        }
        
        if (result[result.Length - 1] == '0') {
            result.Length--;
        }
        
        // We may have an extra carry at the very end,
        if (carry > 0) {
            result.Append(carry);
        }
        
        return new string(result.ToString().Reverse().ToArray());
    }
}
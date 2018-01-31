// https://leetcode.com/problems/add-strings/description/

public class Solution {
    public string AddStrings(string num1, string num2) {
        if (String.IsNullOrWhiteSpace(num1)) {
            return num2;
        } else if (string.IsNullOrWhiteSpace(num2)) {
            return num1;
        } else if (string.IsNullOrWhiteSpace(num1) && string.IsNullOrWhiteSpace(num2)) {
            return string.Empty;
        }
        
        int carry = 0;
        StringBuilder sb = new StringBuilder();
        
        int num1Idx, num2Idx;
        
        for (num1Idx = num1.Length - 1, num2Idx = num2.Length - 1; num1Idx >= 0 || num2Idx >= 0; num1Idx--, num2Idx--) {
            int num1Val = num1Idx >= 0 ? num1[num1Idx] - 48 : 0;
            int num2Val = num2Idx >= 0 ? num2[num2Idx] - 48 : 0;
            
            int currNum = num1Val + num2Val + carry;
            carry = 0;
            
            if (currNum >= 10) {
                carry = 1;
                currNum -= 10;
            }
            
            sb.Insert(0, currNum);
        }
        
        if (carry > 0) {
            sb.Insert(0, 1);
        }
        
        return sb.ToString();
    }    
}
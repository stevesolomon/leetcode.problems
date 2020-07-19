// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/546/week-3-july-15th-july-21st/3395/

public class Solution {
    public string AddBinary(string a, string b) {
        if (string.IsNullOrWhiteSpace(a) || a == "0") {
            return b;
        } else if (string.IsNullOrWhiteSpace(b) || b == "0") {
            return a;
        }
        
        bool carry = false;
        StringBuilder sb = new StringBuilder();
        
        Stack<char> aStack = new Stack<char>();
        Stack<char> bStack = new Stack<char>();
        
        foreach (char c in a) {
            aStack.Push(c);
        }
        
        foreach (char c in b) {
            bStack.Push(c);
        }
        
        while (aStack.Count > 0 && bStack.Count > 0) {
            char currA = aStack.Pop();
            char currB = bStack.Pop();
            
            carry = AddBinaryDigits(currA, currB, carry, sb);
        }
        
        var extraStack = aStack.Count > 0 ? aStack : bStack;
        
        while (extraStack.Count > 0) {
            char curr = extraStack.Pop();
            
            carry = AddBinaryDigits(curr, carry ? '1' : '0', false, sb);
        }
        
        if (carry) {
            sb.Insert(0, '1');
        }
        
        return sb.ToString();
    }
    
    private bool AddBinaryDigits(char a, char b, bool carry, StringBuilder sb) {
        char currDigit = '0';
        bool newCarry = false;
        
        if ((a == '0' && b == '1') || (a == '1' && b == '0')) {
            currDigit = '1';
        } else if (a == '1' && b == '1') {
            currDigit = '0';
            newCarry = true;
        }
        
        if (carry) {
            currDigit = currDigit == '0' ? '1' : '0';
            
            // If we carried and it rotated us back to 0 we need to
            // ensure that we return a new carry = true result.
            if (currDigit == '0') {
                newCarry = true;
            }
        }
        
        sb.Insert(0, currDigit);
        
        return newCarry;        
    }
}
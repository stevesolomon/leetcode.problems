// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3328/

public class Solution {
    public string RemoveKdigits(string num, int k) {
        if (string.IsNullOrWhiteSpace(num) || num.Length <= k) {
            return "0";
        }
        
        // We will push each digit, starting from the most-significant to least-significant
        // on to a stack.
        // Before we do that, however, we will check if the current digit is lower than the
        // top of the stack. If it is, and if we still have digits we can remove, we will
        // keep removing as many as we can until we find something lower (or equal) to us.
        Stack<int> numStack = new Stack<int>();
        int remainingRemoves = k;
        
        for (int i = 0; i < num.Length; i++) {
            int currDigit = num[i] - '0';
            
            // Remove as many numbers as we can from the stack so long as we keep
            // finding numbers higher than our current one.
            while (remainingRemoves > 0 && numStack.Count > 0 && currDigit < numStack.Peek()) {
                // Replace the digit.
                numStack.Pop();
                remainingRemoves--;
            }
            
            numStack.Push(currDigit);
        }
        
        // If we still have removes we can perform, remove them.
        // Remember, we're working from the Least-significant digit to most here
        // so we don't want to consider "leading" zeroes at this point (we don't know if we have them)
        while (remainingRemoves > 0 && numStack.Count > 0) {
            numStack.Pop();
            remainingRemoves--;
        }
        
        return GenerateNumString(numStack);
    }
    
    private string GenerateNumString(Stack<int> numStack) {
        
        StringBuilder sb = new StringBuilder();
        
        while (numStack.Count > 0) {
            sb.Insert(0, numStack.Pop());
        }
        
        // Now remove leading zeroes...
        while (sb.Length > 0 && sb[0] == '0') {
            sb.Remove(0, 1);
        }
        
        return sb.Length == 0 ? "0" : sb.ToString();
    }
}
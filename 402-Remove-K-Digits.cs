// https://leetcode.com/problems/remove-k-digits/description/

public class Solution {
    public string RemoveKdigits(string num, int k) {
        
        if (string.IsNullOrWhiteSpace(num)) {
            return "0";
        } else if (k == num.Length) {
            return "0";  
        } else if (k == 0) {
            return num;
        }
        
        // We'll store each number on a stack, starting from the most sig digit.
        // As a result, if we later find numbers lower than the current digit on the top
        // of the stack we can pop the stack to get rid of the higher MSDs.
        Stack<int> numStack = new Stack<int>();
        int numLeftToRemove = k;
        
        for (int i = 0; i < num.Length; i++) {
            int currNum = num[i] - 48;
            
            // If we can still remove numbers, and the current one is lower than whatever
            // we have at the top of the stack, remove the stack one.
            while (numStack.Count > 0 && numLeftToRemove > 0 && currNum < numStack.Peek()) {
                numStack.Pop();
                numLeftToRemove--;
            }
            
            numStack.Push(currNum);
        }
        
        // Do we still have numbers left to remove?
        while (numLeftToRemove > 0) {
            numStack.Pop();
            numLeftToRemove--;
        }
        
        return CreateNumString(numStack);                
    }
    
    private string CreateNumString(Stack<int> numStack) {
        StringBuilder sb = new StringBuilder();
        
        while (numStack.Count > 0) {
            sb.Insert(0, numStack.Pop().ToString());
        }
        
        while (sb.Length > 0 && sb[0] == '0') {
            sb.Remove(0, 1);
        }
                      
        return sb.Length == 0 ? "0" : sb.ToString();
    }
}
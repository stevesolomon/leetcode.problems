// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/637/week-2-september-8th-september-14th/3971/

public class Solution {
    public int Calculate(string s) {
        
        if (string.IsNullOrWhiteSpace(s)) {
            return 0;
        }
        
        Stack<int> sumStack = new Stack<int>();
        Stack<int> signStack = new Stack<int>();
        
        int sign = 1;
        int sum = 0;
        int i = 0;
        
        while (i < s.Length) {
            char curr = s[i];
            int currVal = 0;
            
            if (char.IsDigit(curr)) {
                while (i < s.Length && char.IsDigit(s[i])) {
                    currVal *= 10;
                    currVal += s[i] - '0';
                    i++;
                }
                
                // We update our sign when we see a '-' anywhere, so with every
                // new complete number we find we can simply add (or subtract) it
                // to our running sum. We don't actually need to parse the statement
                // in the form a +/- b.
                sum += (currVal * sign);
                sign = 1;
                
                // From the while loop, we're now 1 index past the last digit in this
                // number, so we need to back up one.
                i--;
            } else if (curr == '-') {
                sign = -1;
            } else if (curr == '(') {
                // We're starting a new frame/context. Push our current sum and sign onto the
                // stack, and then reset both the sum and sign.
                sumStack.Push(sum);
                signStack.Push(sign);
                
                sum = 0;
                sign = 1;
            } else if (curr == ')') {
                // We've closed out our new frame/context. Pop the previous sum and sign and
                // apply them to our curremt sum (which is the sum within the nested context).
                int prevSum = sumStack.Pop();
                int prevSign = signStack.Pop();
                
                // We apply the previous sign to the sum, and not the prevSum, as recall,
                // the previous sign was used right before the '(' ie: '+ (' or '- )'
                sum *= prevSign;
                sum += prevSum;
            }
            
            i++;
        }
        
        return sum;
    }
}
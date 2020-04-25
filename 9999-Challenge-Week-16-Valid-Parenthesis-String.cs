// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/530/week-3/3301/

public class Solution {
    public bool CheckValidString(string s) {
        if (string.IsNullOrWhiteSpace(s)) {
            return true;
        }
        
        Stack<int> parenStack = new Stack<int>();
        
        foreach (char c in s) {
            switch (c) {
                case '(':
                    parenStack.Push(0);
                    break;
                case ')':
                    // No matching open paren
                    if (parenStack.Count == 0) {
                        return false;
                    }
                    
                    // Otherwise we do have parens available.
                    // Let's skip past the *'s first and see if we
                    // can use a "real" open paren...
                    List<int> stars = new List<int>();
                    while (parenStack.Count > 0 && parenStack.Peek() == 1) {
                        stars.Add(parenStack.Pop());
                    }
                    
                    // If our stack is exhausted we must use a star...
                    if (parenStack.Count == 0) {
                        stars.RemoveAt(stars.Count - 1);
                        
                        foreach (int star in stars) {
                            parenStack.Push(star);
                        }
                    } else {
                        // Otherwise, use an open paren from the stack.
                        parenStack.Pop();
                        
                        foreach (int star in stars) {
                            parenStack.Push(star);
                        }
                    }
                    break;
                case '*':
                    // Push a special paren into our stack
                    parenStack.Push(1);
                    break;
            }
        }        

        // If we still have open parens left, we can try to match
        // them to stars (the stars must have come first, hence why
        // we simply test against a running count of stars).
        int starsLeftCount = 0;
        while (parenStack.Count > 0) {
            var val = parenStack.Pop();

            if (val == 0 && starsLeftCount == 0) {
                return false;
            } else if (val == 0) {
                starsLeftCount--;
            } else if (val == 1) {
                starsLeftCount++;
            }
        }
        
        return true;
    }
}
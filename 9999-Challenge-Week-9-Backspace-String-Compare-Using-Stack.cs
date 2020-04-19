// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/529/week-2/3291/
// This solution uses O(n) memory via Stacks

public class Solution {
    public bool BackspaceCompare(string S, string T) {
        if (string.IsNullOrWhiteSpace(S) && string.IsNullOrWhiteSpace(T)) {
            return true;
        } else if (string.IsNullOrWhiteSpace(S) || string.IsNullOrWhiteSpace(T)) {
            return false;
        }
        
        Stack<char> sStack = new Stack<char>();
        Stack<char> tStack = new Stack<char>();
        
        foreach (char c in S) {
            if (c == '#') {
                if (sStack.Count > 0) {
                    sStack.Pop();
                }
            } else {
                sStack.Push(c);
            }
        }
        
        foreach (char c in T) {
            if (c == '#') {
                if (tStack.Count > 0) {
                    tStack.Pop();
                }
            } else {
                tStack.Push(c);
            }
        }
        
        // Validate that the stacks contain the same chars
        if (tStack.Count != sStack.Count) {
            return false;
        }
        
        while (sStack.Count > 0) {
            if (sStack.Pop() != tStack.Pop()) {
                return false;
            }
        }
        
        return true;
    }
}
// https://leetcode.com/problems/remove-duplicate-letters/description/

public class Solution {
    public string RemoveDuplicateLetters(string s) {
        if (string.IsNullOrWhiteSpace(s)) {
            return s;
        }
        
        Dictionary<char, int> charCounts = new Dictionary<char, int>();
        
        foreach (char c in s) {
            if (!charCounts.ContainsKey(c)) {
                charCounts.Add(c, 0);
            }
            
            charCounts[c]++;
        }
        
        Stack<char> stack = new Stack<char>();
        HashSet<char> seenChars = new HashSet<char>();
        char lowChar = char.MaxValue;
        
        foreach (char c in s) {
            charCounts[c]--;   
            
            if (seenChars.Contains(c)) {
                continue;
            }            
            
            while (stack.Count > 0 && stack.Peek() > c && charCounts[stack.Peek()] > 0) {
                char removed = stack.Pop();
                seenChars.Remove(removed);
            }
            
            stack.Push(c);
            seenChars.Add(c);
        }
        
        StringBuilder sb = new StringBuilder();
        
        // Rebuild the string, removing any chars that still have duplicates
        while (stack.Count > 0) {
            sb.Insert(0, stack.Pop());      
        }
        
        return sb.ToString();
    }
}
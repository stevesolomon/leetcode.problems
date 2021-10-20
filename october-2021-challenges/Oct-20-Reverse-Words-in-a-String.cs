// https://leetcode.com/problems/reverse-words-in-a-string/submissions/

public class Solution {
    public string ReverseWords(string s) {
        if (string.IsNullOrWhiteSpace(s)) {
            return s;
        }
        
        // Put each word into a stack.
        // Pop the stack to rebuild the reversed string.
        int idx = 0;
        Stack<string> wordStack = new Stack<string>();
        
        while (idx < s.Length) {
            while (idx < s.Length && s[idx] == ' ') {
                idx++;
            }
            
            if (idx == s.Length) {
                break;
            }
            
            int endIdx = idx;
            while (endIdx < s.Length && s[endIdx] != ' ') {
                endIdx++;
            }
            
            wordStack.Push(s.Substring(idx, endIdx - idx));
            idx = endIdx;
        }
        
        StringBuilder sb = new StringBuilder();
        
        while (wordStack.Count > 0) {
            sb.Append(wordStack.Pop());
            sb.Append(" ");
        }
        
        sb.Length--;
        
        return sb.ToString();
    }
}
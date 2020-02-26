// https://leetcode.com/problems/number-of-substrings-containing-all-three-characters/
// This solution uses a raw adjacency list but is too slow.

public class Solution {
    public int NumberOfSubstrings(string s) {
        
        if (string.IsNullOrWhiteSpace(s) || s.Length < 3) {
            return 0;
        }
        
        // First build an adjacency list storing indices for each letter as we find them.
        Node aList = new Node();
        Node bList = new Node();
        Node cList = new Node();
        
        Node aCurr = aList;
        Node bCurr = bList;
        Node cCurr = cList;
        
        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            
            switch (c) {
                case 'a':
                    aCurr.index = i;
                    aCurr.next = new Node();
                    aCurr = aCurr.next;
                    break;
                case 'b':
                    bCurr.index = i;
                    bCurr.next = new Node();
                    bCurr = bCurr.next;
                    break;
                case 'c':
                default:
                    cCurr.index = i;
                    cCurr.next = new Node();
                    cCurr = cCurr.next;
                    break;
            }
        }
        
        // Now, go through every starting index in the string. What we are looking for is the 
        // first indices for each of the latters after (or on) this starting index. This tells us the
        // smallest size of the subset we can construct starting from i, say, i...j.
        // We can then add every i...j+k for k = 0 to s.Length - i (or simply add s.Length - j to the return value).
        int totalSubstrings = 0;
        
        for (int i = 0; i < s.Length - 2; i++) {
            
            // Find initial occurrences of each character...
            int aIdx = FindEarliestIndexOfChar(aList, i);
            int bIdx = FindEarliestIndexOfChar(bList, i);
            int cIdx = FindEarliestIndexOfChar(cList, i);
            
            // If we didn't find at least one char we won't find them later either,
            // so we might as well end the search early.
            if (aIdx == -1 || bIdx == -1 || cIdx == -1) {
                break;
            }
            
            // Otherwise, take the greatest index, and that forms the minimum size substring.
            int lastIdx = Math.Max(aIdx, Math.Max(bIdx, cIdx));
            
            totalSubstrings += s.Length - lastIdx;
        }
        
        return totalSubstrings;
    }
    
    private int FindEarliestIndexOfChar(Node charList, int minIndex) {
        Node curr = charList;
        
        while (curr != null) {
            if (curr.index >= minIndex) {
                return curr.index;
            }
            
            curr = curr.next;
        }
        
        return -1;
    }
}

public class Node {
    public int index;
    public Node next;
    
    public Node() {
        index = -1;
    }
}
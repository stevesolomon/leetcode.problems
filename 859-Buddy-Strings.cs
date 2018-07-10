// https://leetcode.com/problems/buddy-strings/description/

public class Solution {
    public bool BuddyStrings(string A, string B) {
        if (A == null || B == null || A.Length != B.Length) {
            return false;
        }
        
        bool lookingForSwap = false;
        bool foundSwap = false;
        char swapChar = char.MinValue;
        
        Dictionary<char, int> aCounts = new Dictionary<char, int>();
        Dictionary<char, int> bCounts = new Dictionary<char, int>();
        
        for (int i = 0; i < A.Length; i++) {
            
            if (!aCounts.ContainsKey(A[i])) {
                aCounts.Add(A[i], 0);
            }
            
            if (!bCounts.ContainsKey(B[i])) {
                bCounts.Add(B[i], 0);
            }
            
            aCounts[A[i]]++;
            bCounts[B[i]]++;
            
            if (lookingForSwap && B[i] == swapChar) {
                foundSwap = true;
                lookingForSwap = false;
                continue;
            }
            
            if (A[i] != B[i]) {
                if (!lookingForSwap && !foundSwap) {
                    lookingForSwap = true;
                    swapChar = A[i];
                } else if (foundSwap) {
                    return false;
                } else {
                    return false;
                }
            }
        }
        
        bool hasTwo = false;
        
        // Double check that all the char frequencies match up
        foreach (char key in aCounts.Keys) {
            if (!bCounts.ContainsKey(key) || bCounts[key] != aCounts[key]) {
                return false;
            }

            // An edge case where we never found a mismatched swap but there are multiple
            // of the same char present that we could swap instead.
            if (aCounts[key] >= 2) {
                hasTwo = true;
            }
        }        
        
        if (foundSwap) {
            return true;
        } else if (hasTwo) {
            return true;
        }
        
        return false;
    }
}
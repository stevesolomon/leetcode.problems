// https://leetcode.com/problems/rotate-string/description/

public class Solution {
    public bool RotateString(string A, string B) {
        
        if (A == null && B == null || (A.Length == 0 && B.Length == 0)) {
            return true;
        } else if (A == null || B == null || A.Length != B.Length) {
            return false;
        }
        
        // Scan for A's starting character in B
        char toFind = A[0];
        List<int> indexBs = new List<int>();
        
        for (int i = 0; i < B.Length; i++) {
            if (B[i] == toFind) {
                indexBs.Add(i);
            }
        }
        
        if (indexBs.Count == 0) {
            return false;
        }
        
        // Now start stepping through both strings.
        foreach (int idx in indexBs) {
            
            int indexB = idx;
            int indexA = 0;
            
            for (indexA = 0; indexA < A.Length; indexA++) {
                if (A[indexA] != B[indexB]) {
                    break;
                }

                indexB++;

                if (indexB == B.Length) {
                    indexB = 0;
                }
            }
            
            if (indexA == A.Length) {
                return true;
            }
        }
        
        return false;
    }
}
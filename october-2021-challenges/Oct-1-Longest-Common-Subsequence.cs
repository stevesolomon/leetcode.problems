// https://leetcode.com/problems/longest-common-subsequence/

public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        if (string.IsNullOrWhiteSpace(text1) || string.IsNullOrWhiteSpace(text2)) {
            return 0;
        }
        
        // We'll use a 2D lookup array, where A[i,j] represents the longest common subsequence
        // from text1: 0...i and text2: 0...j
        int[,] lookup = new int[text1.Length, text2.Length];
        
        // Build up the combination for initial chars for each
        bool firstCharMatch = false;
        for (int i = 0; i < text2.Length; i++) {
            if (text1[0] == text2[i]) {
                firstCharMatch = true;
                lookup[0,i] = 1;
            } else {
                if (firstCharMatch) {
                    lookup[0,i] = 1;
                }
            }
        }
        
        firstCharMatch = false;
        for (int i = 0; i < text1.Length; i++) {
            if (text2[0] == text1[i]) {
                firstCharMatch = true;
                lookup[i,0] = 1;
            } else {
                if (firstCharMatch) {
                    lookup[i,0] = 1;
                }
            }
        }
        
        // Now, iterate through the rest of the elements.
        // A[i,j] = A[i - 1, j - 1] + 1 if text1[i] == text2[j]
        //    or    max(A[i - 1][j], A[i][j - 1]) otherwise
        for (int i = 1; i < text1.Length; i++) {
            for (int j = 1; j < text2.Length; j++) {
                if (text1[i] == text2[j]) {
                    lookup[i,j] = lookup[i - 1, j - 1] + 1;
                } else {
                    lookup[i,j] = Math.Max(lookup[i - 1,j], lookup[i, j - 1]);
                }
            }
        }
        
        return lookup[text1.Length - 1, text2.Length - 1];
    }
}
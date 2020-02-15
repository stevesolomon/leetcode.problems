// https://leetcode.com/problems/three-equal-parts/

public class Solution {
    public int[] ThreeEqualParts(int[] A) {
        if (A == null || A.Length < 3) {
            return new int[] { -1, -1 };
        }
        
        // Count the number of 1s in A...
        int numOnes = 0;
        foreach (int num in A) {
            if (num == 1) {
                numOnes++;
            }
        }
        
        // No ones? Just return anything.
        if (numOnes == 0) {
            return new int[] { 0, A.Length - 1 };
        }
        
        // If they aren't divisible by 3 we can't split the array
        // into 3 sections that all have the same number of 1s.
        if (numOnes % 3 != 0) {
            return new int[] { -1, -1 };
        }
        
        // Now, we need to split the array into 3 parts, where each part has the same number of 1s.
        // So, each part needs to have numOnes / 3 ones.
        // Which means that we just have to go through the first numOnes / 3 nums to get the first part,
        // and the same for the second (which then also gives us the third).
        // From there, we simply need to scan each part to ensure that, ignoring leading zeroes only, they're all the same.
        int onesPerPart = numOnes / 3;
        
        int partOneLastIdx = GetIndexForOnesCount(0, onesPerPart, A);
        int partTwoLastIdx = GetIndexForOnesCount(partOneLastIdx + 1, onesPerPart, A);
        
        // We may need to adjust the last idxs for each section.
        // Why? The third part may end in a number of zeroes. In that case, we need to 
        // ensure that there are that many trailing zeroes for the first and second sections as well.
        int trailingZeroCount = GetTrailingZeroes(A);
        
        // Adjust partOneLastIdx, and partTwoLastIdx by trailingZeroCount indices ahead.
        partOneLastIdx += trailingZeroCount;
        partTwoLastIdx += trailingZeroCount;
        
        // Now scan all three sections in lockstep (skipping ahead for leading zeroes)
        int oneIdx = 0, twoIdx = partOneLastIdx + 1, threeIdx = partTwoLastIdx + 1;
        
        while (oneIdx <= partOneLastIdx && A[oneIdx] == 0) {
            oneIdx++;
        }
        
        while (twoIdx <= partTwoLastIdx && A[twoIdx] == 0) {
            twoIdx++;
        }
        
        while (threeIdx < A.Length && A[threeIdx] == 0) {
            threeIdx++;
        }
        
        while (oneIdx <= partOneLastIdx && twoIdx <= partTwoLastIdx && threeIdx < A.Length) {
            if (A[oneIdx] != A[twoIdx] || A[oneIdx] != A[threeIdx] || A[twoIdx] != A[threeIdx]) {
                return new int[] { -1, -1 };
            }
            
            oneIdx++;
            twoIdx++;
            threeIdx++;
        }
        
        // Check if we haven't stopped with any of the current pointers. If so, we've failed.
        if (oneIdx <= partOneLastIdx || twoIdx <= partTwoLastIdx || threeIdx < A.Length) {
            return new int[] { -1, -1 };
        }
        
        return new int[] { partOneLastIdx, partTwoLastIdx + 1 };
    }
    
    private int GetIndexForOnesCount(int startIdx, int expectedOnes, int[] A) {
        int returnIdx = 0;
        int onesCount = 0;
        
        for (int i = startIdx; i < A.Length; i++) {
            if (A[i] == 1) {
                onesCount++;
            }
            
            if (onesCount == expectedOnes) {
                returnIdx = i;
                break;
            }
        }
        
        return returnIdx;
    }
    
    private int GetTrailingZeroes(int[] A) {
        int count = 0;
        
        for (int i = A.Length - 1; i >= 0; i--) {
            if (A[i] == 1) {
                break;
            }
            
            count++;
        }
        
        return count;
    }
}
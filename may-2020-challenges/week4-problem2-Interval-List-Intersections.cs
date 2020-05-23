// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/537/week-4-may-22nd-may-28th/3338/

public class Solution {
    public int[][] IntervalIntersection(int[][] A, int[][] B) {
        if (A == null || B == null || A.Length == 0 || B.Length == 0) {
            return new int[0][];
        }
        
        List<Tuple<int, int>> matches = new List<Tuple<int, int>>();
        
        // To find if we have a match we will take: startMatch = max(A.start, B.start)
        // and endMatch = min(A.end, B.end). If both numbers fit in both intervals we have a match.
        // If endMatch == A.end or B.end, we need to move on to the next interval for either or both.
        int currA = 0;
        int currB = 0;
        
        while (currA < A.Length && currB < B.Length) {
            int aStart = A[currA][0];
            int aEnd = A[currA][1];
            int bStart = B[currB][0];
            int bEnd = B[currB][1];
            
            int startMatch = Math.Max(aStart, bStart);
            int endMatch = Math.Min(aEnd, bEnd);
            
            if (startMatch <= endMatch && 
                startMatch >= aStart && startMatch >= bStart &&
                endMatch <= aEnd && endMatch <= bEnd) {
                matches.Add(new Tuple<int, int>(startMatch, endMatch));
            }
            
            // Which one did we end on? Or both?
            if (endMatch == aEnd) {
                currA++;
            }
            
            if (endMatch == bEnd) {
                currB++;
            }
        }
        
        int[][] results = new int[matches.Count][];
        int i = 0;
        
        foreach (var match in matches) {
            results[i++] = new int[2] { match.Item1, match.Item2 };
        }
        
        return results;
    }
}
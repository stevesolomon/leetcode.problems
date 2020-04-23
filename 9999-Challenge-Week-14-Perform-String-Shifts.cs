// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/529/week-2/3299/

public class Solution {
    public string StringShift(string s, int[][] shift) {
        if (string.IsNullOrWhiteSpace(s) || shift == null || shift.Length == 0) {
            return s;
        }
        
        // First let's figure out what the end-result shift is, by aggregating
        // all of the requested shifts together (subtract for left shifts).
        int aggregateShift = 0;
        
        for (int i = 0; i < shift.Length; i++) {
            int multiplier = shift[i][0] == 1 ? 1 : -1;
            aggregateShift += (shift[i][1] * multiplier);
        }
        
        // Now we know how much we need to shift overall.
        // When shifting, we consider the string in two parts:
        // [0..n)[n..len]
        // If we shift right, n = length - shift
        // If we shift left, n = shift
        // We can then just swap the positions of these two strings and return the result.
        // To account for shifts > length, we take shift % length
        bool leftShift = aggregateShift < 0 ? true : false;
        int absShift = Math.Abs(aggregateShift) % s.Length;
        
        int shiftIdx = leftShift ? absShift : s.Length - absShift;
        
        return s.Substring(shiftIdx) + s.Substring(0, shiftIdx);
    }
}
// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/638/week-3-september-15th-september-21st/3976/

public class Solution {
    
    private enum Direction {
        Unknown,
        Increase,
        Decrease,
    }
    
    public int MaxTurbulenceSize(int[] arr) {
        if (arr == null) {
            return 0;
        } else if (arr.Length < 2) {
            return arr.Length;
        }
        
        // Our current subarray is either looking for an increasing
        // value or a decreasing value.
        // If we find the opposite, then swap what we're looking for,
        // reset our counter (to 2, not 1, as we have at least one
        // current value, unless they are both equal).
        Direction dir = Direction.Unknown;
        int length = 1;
        int bestLen = int.MinValue;
        
        for (int i = 0; i < arr.Length - 1; i++) {
            if (arr[i] == arr[i + 1]) {
                length = 1;
                dir = Direction.Unknown;
            } else if (arr[i] > arr[i + 1]) {
                if (dir == Direction.Decrease || dir == Direction.Unknown) {
                    length++;                    
                } else {
                    length = 2;
                }
                
                dir = Direction.Increase;
            } else {
                if (dir == Direction.Increase || dir == Direction.Unknown) {
                    length++;
                } else {
                    length = 2;
                }
                
                dir = Direction.Decrease;
            }
            
            bestLen = Math.Max(bestLen, length);
        }
        
        return bestLen;
    }
}
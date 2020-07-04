// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/544/week-1-july-1st-july-7th/3380/

public class Solution {
    public int NthUglyNumber(int n) {
        List<int> uglyNums = new List<int>();
        uglyNums.Add(1);
        
        // Generate our n ugly numbers.
        // We can generate a new ugly number by multiplying
        // an earlier one by 2, 3, or 5.
        // We can ensure we keep generating ugly numbers in order by 
        // taking the *next* ugly number resulting from * 2, * 3, or * 5, and
        // taking the smallest of those 3. 
        // If we use, say, i * 3, where i is the ith ugly number, we will want to
        // ensure that the next time we use 3 as the factor we use it with the i+1st ugly number.
        int times2Idx = 0;
        int times3Idx = 0;
        int times5Idx = 0;
        
        for (int i = 1; i < n; i++) {
            int times2Num = uglyNums[times2Idx] * 2;
            int times3Num = uglyNums[times3Idx] * 3;
            int times5Num = uglyNums[times5Idx] * 5;
            
            int minUglyNum = Math.Min(times2Num, Math.Min(times3Num, times5Num));
            uglyNums.Add(minUglyNum);
            
            // Note there are cases where two (or all three) factors could have resulted in our
            // minimal ugly number, so we need to increment each index that contributed.
            if (minUglyNum == times2Num) {
                times2Idx++;
            }
            
            if (minUglyNum == times3Num) {
                times3Idx++;
            }
            
            if (minUglyNum == times5Num) {
                times5Idx++;
            }
        }
        
        return uglyNums[uglyNums.Count - 1];
    }
}
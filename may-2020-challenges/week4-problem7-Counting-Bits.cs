// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/537/week-4-may-22nd-may-28th/3343/

public class Solution {
    public int[] CountBits(int num) {
        int[] results = new int[num + 1];
        
        results[0] = 0;
        
        // For any non-zero number, the number of bits is equal to:
        //   Even: results[x / 2] (an even number X simply shifts all bits from X / 2 to the left)
        //   Odd: results[x - 1] + 1 (we simply flip the LSB to 1 from the previous even number)
        for (int i = 1; i <= num; i++) {
            if (i % 2 == 0) {
                results[i] = results[i / 2];
            } else {
                results[i] = results[i - 1] + 1;
            }
        }
        
        return results;        
    }
}
// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/614/week-2-august-8th-august-14th/3876/

public class Solution {
    public int MinFlipsMonoIncr(string s) {
        if (string.IsNullOrWhiteSpace(s)) {
            return 0;
        }
        
        int idx = 0;
        
        // Scan through all contiguous 0's in the string first.
        while (idx < s.Length && s[idx] == '0') {
            idx++;
        }
        
        int oneCnt = 0;
        int flipCnt = 0;
        
        // If we still have string left to cover, we've hit a 1
        // From here, count the number of flips we may have to make.
        for (int i = idx; i < s.Length; i++) {
            if (s[i] == '0') {
                // We have to make a flip
                flipCnt++;
            } else {
                oneCnt++;
            }
            
            // Now, if we end up having more current flips than 1s present
            // we can clearly minimize the number of flips by just flipping 1s
            // instead of 0s up to this point, so reset the flip count.
            flipCnt = Math.Min(flipCnt, oneCnt);
        }
        
        return flipCnt;
    }
}
// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/545/week-2-july-8th-july-14th/3388/

public class Solution {
    public uint reverseBits(uint n) {
        if (n == 0) {
            return 0;
        }
        
        uint newVal = 0;
        
        for (int i = 0; i < 32; i++) {            
            newVal <<= 1;
            
            uint test = (n & 1);
            
            if (test == 1) {
                newVal |= 1;
            }
            
            n >>= 1;
        }
        
        return newVal;
    }
}
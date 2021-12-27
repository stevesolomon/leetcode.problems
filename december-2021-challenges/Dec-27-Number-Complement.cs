// https://leetcode.com/problems/number-complement/

public class Solution {
    public int FindComplement(int num) {
        if (num == 0) {
            return 0;
        }
        
        int val = 0;
        int iter = 0;
        
        while (num > 0) {
            int bit = (num & 1) == 1 ? 0 : 1;
            
            val += (bit << iter);
                
            iter++;
            num >>= 1;
        }
        
        return val;
    }
}

// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3351/

public class Solution {
    
    private int[] prefix;
    
    private int totalWeights;
    
    private Random rand;

    public Solution(int[] w) {
        prefix = new int[w.Length];
        
        int prefixVal = 0;
        
        for (int i = 0; i < w.Length; i++) {
            prefixVal += w[i];
            prefix[i] = prefixVal;
        }
        
        totalWeights = prefix[prefix.Length - 1];
        
        rand = new Random();
    }
    
    public int PickIndex() {
        int randVal = rand.Next(totalWeights);
        
        // Perform a binary search to find the first element in prefix 
        // that is greater than randVal;
        int lo = 0;
        int hi = prefix.Length - 1;
        int mid = 0;
        
        while (lo <= hi) {
            mid = lo + ((hi - lo) / 2);
            
            if (lo == hi) {
                break;
            }
            
            if (prefix[mid] == randVal) {
                mid++;
                break;
            }
            
            if (prefix[mid] < randVal) {
                lo = mid + 1;
            } else {
                hi = mid;
            }
        }
        
        return mid;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 */
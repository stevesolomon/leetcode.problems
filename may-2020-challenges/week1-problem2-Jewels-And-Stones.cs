// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/534/week-1-may-1st-may-7th/3317/

public class Solution {
    public int NumJewelsInStones(string J, string S) {
        if (string.IsNullOrWhiteSpace(J) || string.IsNullOrWhiteSpace(S)) {
            return 0;
        }
        
        // Build up a hashset of chars from J to lookup while
        // we traverse through S.
        HashSet<char> jewels = new HashSet<char>();
        
        foreach (char jewel in J) {
            jewels.Add(jewel);
        }
        
        int jewelCount = 0;
        
        foreach (char stone in S) {
            if (jewels.Contains(stone)) {
                jewelCount++;
            }
        }
        
        return jewelCount;
    }
}
// https://leetcode.com/problems/check-if-n-and-its-double-exist/

public class Solution {
    public bool CheckIfExist(int[] arr) {
        if (arr == null || arr.Length == 0 || arr.Length == 1) {
            return false;
        }
        
        HashSet<int> numsSeen = new HashSet<int>();
        
        foreach (int val in arr) {
                        
            if (val != 0 && val % 2 == 0 && numsSeen.Contains(val / 2)) {
                return true;                
            }
            
            if (numsSeen.Contains(val * 2)) {
                return true;
            }
            
            if (!numsSeen.Contains(val)) {
                numsSeen.Add(val);
            }
        }
        
        return false;
    }
}
// https://leetcode.com/problems/next-greater-element-i/submissions/

public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        if (nums1 == null || nums2 == null || nums1.Length == 0 || nums2.Length == 0) {
            return new int[0];
        }
        
        int[] results = new int[nums1.Length];
        
        Dictionary<int, int> lookup = new Dictionary<int, int>();
        
        for (int i = 0; i < nums2.Length; i++) {
            lookup.Add(nums2[i], i);
        }
        
        for (int i = 0; i < nums1.Length; i++) {
            int num = nums1[i];
            int idx = lookup[num];
            
            while (idx < nums2.Length && nums2[idx] <= num) {
                idx++;
            }
            
            if (idx < nums2.Length) {
                results[i] = nums2[idx];
            } else {
                results[i] = -1;
            }
        }
    
        return results;    
    }
}
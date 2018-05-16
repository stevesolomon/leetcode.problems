// https://leetcode.com/problems/intersection-of-two-arrays/description/

public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        if (nums1 == null || nums2 == null
            || nums1.Length == 0 || nums2.Length  == 0) {
            return new int[0];
        }
        
        HashSet<int> observedIn1 = new HashSet<int>();
        List<int> intersection = new List<int>();
        
        foreach (int num in nums1) {
            observedIn1.Add(num);
        }
        
        foreach (int num in nums2) {
            if (observedIn1.Contains(num)) {
                observedIn1.Remove(num);
                intersection.Add(num);
            }
        }
        
        return intersection.ToArray();
    }
}
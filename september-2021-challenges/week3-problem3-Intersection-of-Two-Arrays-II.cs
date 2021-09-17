// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/638/week-3-september-15th-september-21st/3978/

public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        if (nums1 == null || nums1.Length == 0) {
            return new int[0];
        } else if (nums2 == null || nums2.Length == 0) {
            return new int[0];
        }
        
        // Build a dictionary out of one of the lists, and use that
        // to determine the intersection with the other list.
        Dictionary<int, int> freqs = new Dictionary<int, int>();
        
        foreach (int num in nums1) {
            if (!freqs.ContainsKey(num)) {
                freqs.Add(num, 0);
            }
            
            freqs[num]++;
        }
        
        List<int> results = new List<int>();
        
        // Now loop through the second list, building up the intersection.
        // We can exit early if our freqs dictionary is empty.
        foreach (int num in nums2) {
            
            if (freqs.Count <= 0) {
                break;
            }
            
            if (freqs.ContainsKey(num)) {
                results.Add(num);
                
                freqs[num]--;
                
                if (freqs[num] == 0) {
                    freqs.Remove(num);
                }
            }
        }
        
        return results.ToArray();
    }
}
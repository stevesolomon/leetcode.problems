// https://leetcode.com/problems/find-all-duplicates-in-an-array/description/

public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        List<int> results = new List<int>();
        
        for (int i = 0; i < nums.Length; i++) {
            int convertedIdx = Math.Abs(nums[i]) - 1;
            
            if (nums[convertedIdx] < 0) {
                results.Add(Math.Abs(nums[i]));
            } else {
                nums[convertedIdx] *= -1;
            }
        }
        
        return results;
    }
}
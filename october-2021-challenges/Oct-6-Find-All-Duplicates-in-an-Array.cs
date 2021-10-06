// https://leetcode.com/problems/find-all-duplicates-in-an-array/submissions/

public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        if (nums == null || nums.Length < 2) {
            return new List<int>();
        }
        
        List<int> results = new List<int>();
        
        // We know that the values within the array do not exceed the length of the array,
        // and they are all positive. So, if we observe a value i, we'll set nums[i] to negative
        // to indicate that we've seen value i already. If we spot another i, nums[i] is negative
        // which tells us all we need to know
        for (int i = 0; i < nums.Length; i++) {
            int currVal = Math.Abs(nums[i]);
            
            if (nums[currVal - 1] < 0) {
                results.Add(currVal);
                continue;
            }
            
            nums[currVal - 1] = -nums[currVal - 1];
        }
        
        return results;
    }
}
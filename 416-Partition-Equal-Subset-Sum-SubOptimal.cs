// https://leetcode.com/problems/partition-equal-subset-sum/#/description
//
// This isn't an optimal solution but represents a brute-force-ish effort.

public class Solution {
    public bool CanPartition(int[] nums) {
        
        if (nums == null || nums.Length == 0) {
            return true;
        } else if (nums.Length == 1) {
            return false;
        }
        
        Array.Sort(nums, new Comparison<int>( (x, y) => y.CompareTo(x)));
        
        int targetValue = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            targetValue += nums[i];
        }
        
        if (targetValue % 2 != 0) {
            return false;
        }
        
        targetValue /= 2;
        
        return this.GenerateTarget(targetValue, nums);
    }
    
    public bool GenerateTarget(int target, int[] nums) {
        return GenerateTarget(target, 0, 0, 0, nums);
    }
    
    private bool GenerateTarget(int target, int index, int total1, int total2, int[] nums) {
        if (total1 > target || total2 > target) {
            return false;
        }
        
        if (index >= nums.Length) {
            return total1 == total2;
        }
        
        return GenerateTarget(target, index + 1, total1 + nums[index], total2, nums) 
            || GenerateTarget(target, index + 1, total1, total2 + nums[index], nums);
    }
}
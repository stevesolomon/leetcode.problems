// https://leetcode.com/problems/3sum-closest/description/

public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        if (nums == null || nums.Length < 3) {
            return -1;
        }
        
        Array.Sort(nums);
        
        int bestDistFromTarget = int.MaxValue;
        int candidateSolution = int.MaxValue;
        
        for (int i = 0; i < nums.Length - 2; i++) {
            int low = i + 1;
            int high = nums.Length - 1;
            
            while (low < high) {
                int currValue = nums[i] + nums[low] + nums[high];
                int distFromTarget = Math.Abs(target - currValue);
                
                if (distFromTarget < bestDistFromTarget) {
                    bestDistFromTarget = distFromTarget;
                    candidateSolution = currValue;
                }
                
                if (currValue > target) {
                    high--;
                } else if (currValue < target) {
                    low++;
                } else {
                    // If we're equal, exit early as the problem statement claims that there
                    // is only one solution per input.
                    return candidateSolution;
                }
            }
        }
        
        return candidateSolution;        
    }
}
// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/545/week-2-july-8th-july-14th/3384/

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        if (nums == null || nums.Length < 3) {
            return new List<IList<int>>();
        }

        Array.Sort(nums);
        List<IList<int>> solutions = new List<IList<int>>();
        const int target = 0;
        
        for(int i = 0; i < nums.Length - 2; i++) {
            
            // Avoid duplicates and skip this iteration if our base value
            // is the same as the last base value we looked at.
            if (i != 0 && nums[i] == nums[i - 1]) {
                continue;
            }
            
            int low = i + 1;
            int high = nums.Length - 1;
            
            // Search for the two numbers we need. Our base number is the lowest number
            // we can use, so we need to find both a "next-lowest" and a high number.
            // In reality, nums[high] - nums[next-lowest] should = -nums[i]
            while (low < high) {            
                int val = nums[i] + nums[low] + nums[high];

                if (val > target) {
                    // We've' too high a value, reduce high
                    high--;
                } else if (val < target) {
                    // We've too low a value, increase low
                    low++;
                } else {
                    // We have a match!
                    List<int> solution = new List<int> { nums[i], nums[low], nums[high] };
                    solutions.Add(solution);
                    
                    // Avoid duplication solutions by advancing low and high until they
                    // are not the same as their previous values.
                    while (low < high && nums[low] == nums[low+1]) {
                        low++;
                    }
                    
                    while (low < high && nums[high] == nums[high-1]) {
                        high--;
                    }
                    
                    high--;
                    low++;
                }
            }           
        }
        
        return solutions;
    }
}
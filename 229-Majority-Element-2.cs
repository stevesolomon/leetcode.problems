// https://leetcode.com/problems/majority-element-ii/description/

public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        
        List<int> result = new List<int>();
        
        if (nums == null || nums.Length == 0) {
            return result;
        } else if (nums.Length == 1) {
            result.Add(nums[0]);
            return result;
        } else if (nums.Length == 2) {
            result.Add(nums[0]);
            
            if (nums[0] != nums[1]) {
                result.Add(nums[1]);
            }
            
            return result;
        }
        
        // There can be at most 2 elements that appear more than n/3 times.
        // So let's search for both of them.
        int count1 = 0, count2 = 0;
        int elem1 = int.MinValue, elem2 = int.MinValue;
        
        foreach (int num in nums) {
            if (elem1 == num) {
                count1++;
            } else if (elem2 == num) {
                count2++;
            } else if (count1 == 0) {
                count1 = 1;
                elem1 = num;
            } else if (count2 == 0) {
                count2 = 1;
                elem2 = num;
            } else {
                count1--;
                count2--;
            }
        }
        
        // Double check that both items found are, in fact, covered by n/3
        int minFound = (int) Math.Floor(nums.Length / 3.0);
        count1 = 0;
        count2 = 0;
        
        foreach (int num in nums) {
            if (elem1 == num) {
                count1++;
            } else if (elem2 == num) {
                count2++;
            }
        }
        
        if (count1 > minFound) {
            result.Add(elem1);
        }
        
        if (count2 > minFound) {
            result.Add(elem2);
        }
        
        return result;        
    }
}
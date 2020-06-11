// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/540/week-2-june-8th-june-14th/3357/

public class Solution {
    public void SortColors(int[] nums) {
        if (nums == null || nums.Length < 2) {
            return;
        }
        
        // One-pass through the array maintaining two pointers:
        //   zeroIdx --> Starts at 0, stores where we can place the next '0'
        //   twoIdx --> Starts at nums.Length - 1, stores where we can place the next '2'.
        // At every element of the array, if it is a:
        //   0 --> Write in at zeroIdx
        //   1 --> Record count
        //   2 --> Write in at twoIdx, and swap current value at twoIdx with nums[i]
        //         Iterate again from nums[i]        
        int zeroIdx = 0;
        int twoIdx = nums.Length - 1;
        int oneCount = 0;
        for (int i = 0; i <= twoIdx; i++) {
            int curr = nums[i];
            
            switch (curr) {
                case 0:
                    nums[zeroIdx] = 0;
                    zeroIdx++;
                    break;
                case 1:
                    oneCount++;
                    break;
                case 2:
                default:
                    int temp = nums[twoIdx];
                    nums[twoIdx] = 2;
                    nums[i] = temp;
                    twoIdx--;
                    i--;
                    break;
            }
        }
        
        // Finally write out the ones
        for (int i = 0; i < oneCount; i++) {
            nums[zeroIdx + i] = 1;
        }
    }
}
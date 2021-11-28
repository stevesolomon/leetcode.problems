// https://leetcode.com/problems/product-of-array-except-self/

public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        if (nums == null || nums.Length < 2) {
            return nums;
        }
        
        // We'll want to generate all prefix and suffix products to begin with..
        int[] prefixProd = new int[nums.Length];
        int[] suffixProd = new int[nums.Length];
        
        prefixProd[0] = nums[0];
        suffixProd[nums.Length - 1] = nums[nums.Length - 1];
        
        for (int i = 1; i < nums.Length - 1; i++) {
            prefixProd[i] = prefixProd[i - 1] * nums[i];
        }
        
        for (int i = nums.Length - 2; i >= 0; i--) {
            suffixProd[i] = suffixProd[i + 1] * nums[i];;
        }
        
        // The product of everything not including i, 
        // is the product of everything from 0...i-1 (prefix)
        // and the product of everything from i+1...n (suffix)
        // nums[0] and nums[n] are special cases.
        nums[0] = suffixProd[1];
        nums[nums.Length - 1] = prefixProd[nums.Length - 2];
        
        for (int i = 1; i < nums.Length - 1; i++) {
            nums[i] = prefixProd[i - 1] * suffixProd[i + 1];
        }
        
        return nums;
    }
}
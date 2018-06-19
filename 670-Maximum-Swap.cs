// https://leetcode.com/problems/maximum-swap/description/

public class Solution {
    public int MaximumSwap(int num) {
        
        // First extract our digits
        List<int> nums = new List<int>();
        
        while (num > 0) {
            int digit = num % 10;
            num /= 10;
            
            nums.Add(digit);
        }
        
        // So that we don't have to loop twice on every digit we'll store
        // a prefix-max in a List of Tuples where Item1 = max, Item2 = index of max.
        // We want this from LSD -> GSD as that's the order we'll use to decide a replacement.
        List<Tuple<int, int>> prefixMax = new List<Tuple<int, int>>();
        int maxSoFar = int.MinValue;
        int maxIndex = 0;
        for (int i = 0; i < nums.Count; i++) {
            int newMax = Math.Max(maxSoFar, nums[i]);
            Tuple<int, int> tuple = null;
            
            if (newMax > maxSoFar) {
                tuple = new Tuple<int, int>(newMax, i);
                maxIndex = i;
                maxSoFar = newMax;
            } else {
                tuple = new Tuple<int, int>(maxSoFar, maxIndex);
            }
            
            prefixMax.Add(tuple);
        }
        
        // Now, progressing from most significant digit to least significant digit
        // see if we have a number higher than it elsewhere. If we do, swap it and we're done.
        for (int i = nums.Count - 1; i > 0; i--) {
            
            // We can't do better than 9.
            if (nums[i] == 9) {
                continue;
            }
            
            // Otherwise, check the prefix max 
            // If we have something greater, then perform the swap and we're done.
            if (prefixMax[i - 1].Item1 > nums[i]) {
                int temp = nums[i];
                nums[i] = prefixMax[i - 1].Item1;
                nums[prefixMax[i - 1].Item2] = temp;
                break;
            }
        }
        
        // Now rebuild our number;
        int mult = 1;
        int result = 0;
        for (int i = 0; i < nums.Count; i++) {
            result += nums[i] * mult;
            mult *= 10;
        }
        
        return result;
    }
}
// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/541/week-3-june-15th-june-21st/3366/

public class Solution {
    public string GetPermutation(int n, int k) {
        
        // There are (n - 1)! sub-permutations for each new leading number.
        // So at every step let's figure out which leading number we need.
        // This will be the Ceiling(k / (n - 1)!), which is the element # in our
        // sorted list of remaining nums.
        // Then we subtract that value from k, as we have that many remaining sub-permutations
        // in the right-hand-side of the value we're constructing, and repeat.
        // If k == 1 then we know we can just take the rest of the values in order.
        List<int> availableNums = new List<int>();
        int result = 0;
        
        for (int i = 1; i <= n; i++) {
            availableNums.Add(i);
        }
        
        while (k > 1) {
            int numsRemaining = availableNums.Count;
            int totalSubPerms = this.Factorial(numsRemaining - 1);
            int idxToTake = (int) Math.Ceiling((double) k / totalSubPerms);
            
            result *= 10;
            result += availableNums[idxToTake - 1];
            
            availableNums.RemoveAt(idxToTake - 1);
            
            // The number of sub-permutations remaining for the rest of our
            // values is based on how many "totalSubPerms" deep we had to take
            // our starting number.
            // Consider: [1, 2, 3], k = 5
            // We know the first number we'll take is 3, as ceil(5 / (2!)) - 1 = 5 / 2 - 1 = 3 - 1 = 2
            // This means our first number is 4 permutations "deep", leaving only 1/the first "permutation"
            // remaining for the remaining 2 digits.
            k -= totalSubPerms * (idxToTake - 1);
        }
        
        for (int i = 0; i < availableNums.Count; i++) {
            result *= 10;
            result += availableNums[i];
        }
        
        return result.ToString();
    }
    
    private int Factorial(int num) {
        int val = 1;
        
        while (num > 0) {
            val *= num;
            num--;
        }
        
        return val;
    }
}
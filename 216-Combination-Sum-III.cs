// https://leetcode.com/problems/combination-sum-iii/description/

public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n) {
        List<IList<int>> results = new List<IList<int>>();
        
        if (k == 0 || n == 0) {
            return results;
        }
        
        GenerateCombinationSum(k, n, 1, 0, 0, new List<int>(), results);
        
        return results;
    }
    
    private void GenerateCombinationSum(
        int k,
        int n,
        int currNum,
        int highestUsed,
        int sum,
        List<int> nums,
        List<IList<int>> results) {
        
        // If we're on the last number, check if we can use the last number we need 
        // to get n
        if (currNum == k) {
            int numNeeded = n - sum;
            
            // If our highest used number thus far is less than the sum needed
            // we can use this number.
            if (highestUsed < numNeeded && numNeeded <= 9) {
                List<int> res = new List<int>(nums);
                res.Add(numNeeded);
                results.Add(res);
            }
            
            return;
        }
        
        // Otherwise, let's try using all the available numbers in order (up to 9 - (k - currNum))
        // as we know we need at least that many numbers for the next steps.
        int maxNumCanUse = Math.Max(9, 9 - (k - currNum));
        
        for (int i = highestUsed + 1; i <= maxNumCanUse; i++) {
            nums.Add(i);
            sum += i;
            GenerateCombinationSum(k, n, currNum + 1, i, sum, nums, results);
            nums.RemoveAt(nums.Count - 1);
            sum -= i;
        }
        
        return;
    }
}
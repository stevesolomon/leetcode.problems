public class Solution {
    public int MaxCoins(int[] nums) {
        
        // Set up a new nums array with 1's padded to either side (balloons that
        // don't exist but will not impact the score).
        int[] numsCopy = new int[nums.Length + 2];
        
        for (int i = 1; i <= nums.Length; i++) {
            numsCopy[i] = nums[i - 1];
        }
        
        numsCopy[0] = 1;
        numsCopy[numsCopy.Length - 1] = 1;
        
        // Set up a 2-dimensional array as our lookup table.
        // lookup[x][y] gives us the best possible score if we popped all
        // balloons between x and y (inclusive)
        int[,] lookup = new int[numsCopy.Length, numsCopy.Length];
        
        return solver(0, numsCopy.Length - 1, lookup, numsCopy);
    }
    
    public int solver(int left, int right, int[,] lookup, int[] nums) {
        if (left == right) {
            return 0;
        }
        
        if (lookup[left,right] > 0) {
            return lookup[left,right];
        }
        
        int maxScore = 0;
        
        // Search for the best score based on what balloon we pop.
        // Each iteration will try popping a different balloon, which will, in turn,
        // recurse deeper down into smaller problems.
        for (int i = left + 1; i < right; i++) {
            maxScore = Math.Max(maxScore, 
                                nums[left] * nums[i] * nums[right] + 
                                solver(left, i, lookup, nums) +
                                solver(i, right, lookup, nums));
        }
        
        lookup[left,right] = maxScore;
        
        return maxScore;
    }
}
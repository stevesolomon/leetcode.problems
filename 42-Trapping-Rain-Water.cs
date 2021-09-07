// https://leetcode.com/problems/trapping-rain-water/

public class Solution {
    public int Trap(int[] height) {
        if (height == null || height.Length < 3) {
            return 0;
        }
        
        // We'll keep track of the highest elevations to the left and right
        // of each position, allowing us to understand how much water could be trapped between.
        int[] leftHeights = new int[height.Length];
        int[] rightHeights = new int[height.Length];
        
        for (int i = 1; i < height.Length; i++) {
            // At position i, the highest elevation to our left is either the 
            // highest elevation to the left of position i - 1, or the height of position i - 1.
            leftHeights[i] = Math.Max(leftHeights[i - 1], height[i - 1]);
        }
        
        for (int i = height.Length - 2; i >= 0; i--) {
            rightHeights[i] = Math.Max(rightHeights[i + 1], height[i + 1]);
        }
        
        // Now, at each position we know the highest heights to the left and right of it.
        // Therefore, the maximum amount of water captured at this position is the minimum
        // of either of those heights.
        // Note: we also  need to subtract the height of the current position (as it takes up water space).
        int totalWater = 0;
        
        for (int i = 1; i < height.Length - 1; i++) {
            // We don't ever want to "subtract" water out, so do a Math.Max as a safety check.
            totalWater += Math.Max(0, Math.Min(leftHeights[i], rightHeights[i]) - height[i]);
        }
        
        return totalWater;
    }
}
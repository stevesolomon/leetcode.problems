// https://leetcode.com/problems/falling-squares/description/
// This solution is not efficient enough to pass all test cases.
// We can (hopefully) do better!

public class Solution {
    public IList<int> FallingSquares(int[,] positions) {
        
        List<int> maxHeights = new List<int>();
        
        if (positions == null || positions.GetLength(0) == 0) {
            return maxHeights;
        }
        
        // Key = x position
        // Value = maximum height at this x position
        Dictionary<int, int> heights = new Dictionary<int, int>();
        
        for (int i = 0; i < positions.GetLength(0); i++) {
            int left = positions[i,0];
            int right = left + positions[i,1] - 1;
            
            // Get the highest height from left to right in the dictionary.
            int currHeight = 0;
            for (int x = left; x <= right; x++) {
                if (heights.ContainsKey(x)) {
                    currHeight = Math.Max(currHeight, heights[x]);
                }
            }
            
            // Update all cells with the new current height from this block
            currHeight += positions[i,1];
            
            for (int x = left; x <= right; x++) {
                heights[x] = currHeight;
            }
            
            // Finally, update our max height list
            int lastMaxHeight = maxHeights.Count > 0 ? maxHeights[maxHeights.Count - 1] : int.MinValue;
            int newMaxHeight = Math.Max(lastMaxHeight, currHeight);
            
            maxHeights.Add(newMaxHeight);            
        }        
        
        return maxHeights;
    }
}
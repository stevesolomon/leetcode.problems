// https://leetcode.com/problems/brick-wall/#/description

public class Solution {
    public int LeastBricks(IList<IList<int>> wall) {
        
        if (wall == null || wall.Count == 0) {
            return 0;
        }
        
        Dictionary<int, int> sums = new Dictionary<int, int>();
        
        int maxFrequency = int.MinValue;
        
        // First calculate the prefix sum for each row in the wall
        // Ignore the last value for each row as that represents the edge.
        // Add each to a dictionary maintaining the count.
        // Update the most-viewed sum at every step.
        foreach (var row in wall) {
            int prefixSum = 0;
            
            for (int i = 0; i < row.Count - 1; i++) {
                prefixSum += row[i];
                
                if (!sums.ContainsKey(prefixSum)) {
                    sums.Add(prefixSum, 0);
                }
                
                sums[prefixSum]++;
                
                if (sums[prefixSum] > maxFrequency) {
                    maxFrequency = sums[prefixSum];
                }
            }
        }
        
        // Special case - we have no max frequency, we have to cross all bricks.
        if (maxFrequency == int.MinValue) {
            return wall.Count;
        }
        
        // Now simply subtract the rows count from the maxFrequency, which 
        // tells us how many rows didn't have that value as a prefixSum, which
        // means we cross a brick on that row.
        return wall.Count - maxFrequency;
    }
}
// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/636/week-1-september-1st-september-7th/3960/

public class Solution {
    public int ArrayNesting(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return 0;
        } else if (nums.Length == 1) {
            return 1;
        }
        
        // We need to test each element being the starting position.
        // When we do this, we'll keep track of a visited HashSet of indices
        // we've already visited.
        // If, during a path, we hit an index we've visited in a previous path,
        // we're clearly in the same cycle that it forms, and thus, won't
        // get a longer path (recall: all values in nums are unique).
        int longestPath = int.MinValue;
        HashSet<int> visited = new HashSet<int>();
        
        for (int i = 0; i < nums.Length; i++) {
            // For every starting index... walk the path.
            visited.Add(i);
            
            int elemPtr = nums[i];
            int pathLength = 1;
            
            while (!visited.Contains(elemPtr)) {
                visited.Add(elemPtr);                
                elemPtr = nums[elemPtr];
                pathLength++;
            }
            
            longestPath = Math.Max(pathLength, longestPath);
        }
        
        return longestPath;
    }
}
// https://leetcode.com/problems/path-sum-iii/description/
// This particular solution creates a lot of garbage due to the use of Lists/Copying.

public class Solution {
    public int PathSum(TreeNode root, int sum) {
        if (root == null) {
            return 0;
        }
        
        return PathSumHelper(root, sum, new List<int>());
    }
    
    private int PathSumHelper(TreeNode root, int sum, List<int> currVals) {
        
        if (root == null) {
            return 0;
        }
        
        int numPaths = 0;
        
        if (root.val == sum) {
            numPaths++;
        }
        
        // At every step, loop through our currVals, add the current root's value
        // to each of them, and check if they're equal to the sum (in which case we have a path
        // that happens to end at this node).
        for (int i = 0; i < currVals.Count; i++) {
            int newVal = currVals[i] + root.val;
            
            if (newVal == sum) {
                numPaths++;
            }
            
            currVals[i] = newVal;
        }
        
        // Also add our current node's value to currVals.
        currVals.Add(root.val);
        
        // Now progress to our two leaf nodes (we need to clone the List)
        numPaths += PathSumHelper(root.left, sum, new List<int>(currVals));
        numPaths += PathSumHelper(root.right, sum, new List<int>(currVals));
        
        return numPaths;
    }
}
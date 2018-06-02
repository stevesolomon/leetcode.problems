// https://leetcode.com/problems/path-sum-iii/description/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public int PathSum(TreeNode root, int sum) {
        if (root == null) {
            return 0;
        }
        
        // We maintain a set of prefix sums as we go through the tree 
        // (key = prefix sum, value = the number of routes possible to get this sum).
        // At every node, we keep track of the running sum from the path from the root, 
        // and then subtract from that the target sum. If we have an entry for this in the 
        // prefix sum Dictionary that means we can get rid of the earliest nodes we traversed and take this sub-route.
        Dictionary<int, int> pathVals = new Dictionary<int, int>();
        
        // Preload our pathVals with currSum - sum == 0, ie: the target sum.
        // This will catch cases where the path is a full route through the tree.
        pathVals.Add(0, 1);
        
        return PathSumHelper(root, sum, 0, pathVals);
    }
    
    private int PathSumHelper(TreeNode root, int sum, int currSum, Dictionary<int, int> pathVals) {
        
        if (root == null) {
            return 0;
        }
        
        currSum += root.val;
        
        int numPaths = pathVals.ContainsKey(currSum - sum) ? pathVals[currSum - sum] : 0;
        
        // Add this new value to our pathVals
        if (!pathVals.ContainsKey(currSum)) {
            pathVals.Add(currSum, 0);
        }
        
        pathVals[currSum]++;
        
        numPaths += PathSumHelper(root.left, sum, currSum, pathVals) + PathSumHelper(root.right, sum, currSum, pathVals);
        
        // Finally, clean up the new value we just added as we're done with this subtree.
        pathVals[currSum]--;      
        
        return numPaths;
    }
}
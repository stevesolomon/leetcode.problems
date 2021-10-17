// https://leetcode.com/problems/path-sum-iii/submissions/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int PathSum(TreeNode root, int targetSum) {
        if (root == null) {
            return 0;
        }
        
        // We'll use a Dictionary to keep track of each valid sum that we've found thus far along the 
        // path we've been traversing. Each key represents a sum, and the value the number of subpaths
        // along this path that added up to that value (to keep track of total combinations for that singular value).
        Dictionary<int, int> values = new Dictionary<int, int>();
        
        return PathSum(root, targetSum, values);
    }
    
    private int PathSum(TreeNode root, int targetSum, Dictionary<int, int> values) {
        int totalPaths = 0;
        
        // If we have a key matching the target sum minus this root's value, then we can reach
        // the target sum by including this root in any paths we've seen thus far.
        if (values.ContainsKey(targetSum - root.val)) {
            totalPaths += values[targetSum - root.val];
        }
        
        // If this node alone has the targetSum value it forms its own path
        if (root.val == targetSum) {
            totalPaths++;
        }
        
        // Now try creating paths down our children
        if (root.left != null) {
            // Start a new Dictionary to keep track of paths accounting for this node's value
            Dictionary<int, int> newValues = new Dictionary<int, int>();
            
            foreach (var kvp in values) {
                newValues.Add(kvp.Key + root.val, kvp.Value);
            }
            
            // Add this standalone node as its own path too.
            if (!newValues.ContainsKey(root.val)) {
                newValues.Add(root.val, 0);
            }
            newValues[root.val]++;
            
            totalPaths += PathSum(root.left, targetSum, newValues);
        }
        
        if (root.right != null) {
            Dictionary<int, int> newValues = new Dictionary<int, int>();
            
            foreach (var kvp in values) {
                newValues.Add(kvp.Key + root.val, kvp.Value);
            }
            
            if (!newValues.ContainsKey(root.val)) {
                newValues.Add(root.val, 0);
            }
            newValues[root.val]++;
            
            totalPaths += PathSum(root.right, targetSum, newValues);
        }
        
        return totalPaths;
    }
}
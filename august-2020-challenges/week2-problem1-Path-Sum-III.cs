// https://leetcode.com/explore/featured/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3417/

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
    public int PathSum(TreeNode root, int sum) {
        if (root == null) {
            return 0;
        } else if (root.left == null && root.right == null) {
            return root.val == sum ? 1 : 0;
        }
        
        // Use a Dictionary updated at every node we traverse with the potential
        // values we have thus far, and the number of possibilities for constructing the value.
        return PathSum(root, sum, new Dictionary<int, int>());
    }
    
    private int PathSum(TreeNode root, int sum, Dictionary<int, int> values) {
        
        int totalPaths = 0;
        
        // Check if we have any values in the Dictionary that would let us take
        // this node's val and get to the sum...
        if (values.ContainsKey(sum - root.val)) {
            totalPaths += values[sum - root.val];
        }
        
        // If we are equal to the sum alone we count
        if (root.val == sum) {
            totalPaths++;
        }
        
        // Now move on to our children...
        if (root.left != null) {
            Dictionary<int, int> newVals = new Dictionary<int, int>();
            
            // Build a new Dictionary of values taking into account
            // path sums formed through this node.
            foreach (var kvp in values) {
                newVals.Add(kvp.Key + root.val, kvp.Value);
            }
            
            // Don't forget to add this node itself as a value too!
            if (!newVals.ContainsKey(root.val)) {
                newVals.Add(root.val, 0);
            }
            newVals[root.val]++;
            
            totalPaths += PathSum(root.left, sum, newVals);
        }
        
        if (root.right != null) {
            Dictionary<int, int> newVals = new Dictionary<int, int>();
            
            foreach (var kvp in values) {
                newVals.Add(kvp.Key + root.val, kvp.Value);
            }
            
            if (!newVals.ContainsKey(root.val)) {
                newVals.Add(root.val, 0);
            }
            newVals[root.val]++;
            
            totalPaths += PathSum(root.right, sum, newVals);
        }
        
        return totalPaths;        
    }
}
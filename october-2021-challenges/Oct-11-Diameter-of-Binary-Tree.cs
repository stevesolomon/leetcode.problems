// https://leetcode.com/problems/diameter-of-binary-tree/submissions/

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
    int maxResult;
    
    public int DiameterOfBinaryTree(TreeNode root) {        
        maxResult = 0;
        this.DepthFirstTraversal(root);
        return maxResult;
    }
    
    private int DepthFirstTraversal(TreeNode root) {
        if (root == null) {
            return 0;
        }
        
        // Get the distances for our left and right subtrees
        int left = DepthFirstTraversal(root.left);
        int right = DepthFirstTraversal(root.right);
        
        // See if the greatest distance across our left and right subtrees
        // are greater than any value we've found thus far.
        // We don't add 1 here as this is covered by the return statement below. Subtrees
        // are already returning + 1 to account for their root nodes.
        maxResult = Math.Max(maxResult, left + right);        
        
        // Return the greatest distance across either the left or right subtrees for this root.
        // + 1 as we need to consider this root along the path as well.
        return 1 + Math.Max(left, right);
    }
}
// https://leetcode.com/problems/invert-binary-tree/

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
    public TreeNode InvertTree(TreeNode root) {
        if (root == null) {
            return null;
        }
        
        // Invert our left and right subtrees
        InvertTree(root.left);
        InvertTree(root.right);
        
        // And then swap our left and right children
        var temp = root.left;
        root.left = root.right;
        root.right = temp;
        
        return root;
    }
}
// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3347/

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
            return root;
        }
        
        this.Invert(root);        
        return root;
    }
    
    private void Invert(TreeNode root) {
        TreeNode temp = root.right;
        
        root.right = root.left;
        root.left = temp;
        
        if (root.left != null) {
            Invert(root.left);
        }
        
        if (root.right != null) {
            Invert(root.right);
        }
    }
}
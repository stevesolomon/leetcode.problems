// https://leetcode.com/problems/validate-binary-search-tree/

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
    public bool IsValidBST(TreeNode root) {
        return this.IsValidBST(root, long.MaxValue, long.MinValue);
    }
    
    private bool IsValidBST(TreeNode root, long maxVal, long minVal) {
        if (root == null) {
            return true;
        }
        
        if (root.val >= maxVal || root.val <= minVal) {
            return false;
        }
        
        return
            IsValidBST(root.left, root.val, minVal) &&
            IsValidBST(root.right, maxVal, root.val);
    }
}
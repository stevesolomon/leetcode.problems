// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/542/week-4-june-22nd-june-28th/3372/

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
    private int sum = 0;
    
    public int SumNumbers(TreeNode root) {
        if (root == null) {
            return 0;
        }
        
        SumNumbers(root, 0);
        
        return sum;
    }
    
    private void SumNumbers(TreeNode root, int currVal) {
        currVal *= 10;
        currVal += root.val;
        
        // Hit a leaf node? We're done here.
        if (root.left == null && root.right == null) {
            sum += currVal;
            return;
        }
        
        // Otherwise keep going deeper...
        if (root.left != null) {
            SumNumbers(root.left, currVal);
        }
        
        if (root.right != null) {
            SumNumbers(root.right, currVal);
        }
    }
}
// https://leetcode.com/problems/binary-tree-maximum-path-sum/description/

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
    private int bestSolSoFar = int.MinValue;
    
    public int MaxPathSum(TreeNode root) {
        if (root == null) {
            return 0;
        }
        
        MaxPathSum(root, 0);
        
        return bestSolSoFar;
    }
    
    private int MaxPathSum(TreeNode root, int currVal) {
        if (root == null) {
            return 0;
        }
        
        // Otherwise, we want to take the greater of:
        //   maxPathSum(left)
        //   maxPathSum(right)
        //   maxPathSum(left + root.val)
        //   maxPathSum(right + root.val)
        //   maxPathSum(left + right + root.val)
        int maxPathLeft = Math.Max(0, MaxPathSum(root.left, currVal));
        int maxPathRight = Math.Max(0, MaxPathSum(root.right, currVal));
        
        int maxPathLeftRoot = maxPathLeft + root.val;
        int maxPathRightRoot = maxPathRight + root.val;
        int maxPathLeftRightRoot = maxPathLeft + maxPathRight + root.val;
        
        int maxPathValWithRoot = Math.Max(maxPathLeftRoot, Math.Max(maxPathRightRoot, maxPathLeftRightRoot));
        
        bestSolSoFar = Math.Max(maxPathValWithRoot, bestSolSoFar);
        
        return Math.Max(maxPathLeft, maxPathRight) + root.val;      
    }
}
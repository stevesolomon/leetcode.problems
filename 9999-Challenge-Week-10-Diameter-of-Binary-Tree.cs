// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/529/week-2/3293/

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
    int maxResult;
    
    public int DiameterOfBinaryTree(TreeNode root) {
        if (root == null) {
            return 0;
        }
        
        maxResult = 0;
        
        GetTreeHeightAndSetDiameter(root);
        
        return maxResult;
    }
    
    private int GetTreeHeightAndSetDiameter(TreeNode root) {
        
        if (root == null) {
            return 0;
        }
        
        // Get the heights of the left and right subtrees.
        int left = GetTreeHeightAndSetDiameter(root.left);
        int right = GetTreeHeightAndSetDiameter(root.right);
        
        // The longest path we can find is either the longest we've
        // found thus far, or the combined heights of the subtrees.
        maxResult = Math.Max(maxResult, left + right);
        
        // The height of this subtree is the longest of either
        // branch (+1 to count us as well).
        return 1 + Math.Max(left, right);
    }
}
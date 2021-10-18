// https://leetcode.com/problems/cousins-in-binary-tree/submissions/

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
    
    int[] depthFound = new int[2];
    int[] parentValue = new int[2];
    
    public bool IsCousins(TreeNode root, int x, int y) {
        if (root == null) {
            return false;
        }
        
        TraverseTree(root, x, y, -1, 0);
        
        return depthFound[0] == depthFound[1] && parentValue[0] != parentValue[1];
    }
    
    private void TraverseTree(TreeNode root, int x, int y, int parentVal, int depth) {
        if (root == null) {
            return;
        }
        
        if (root.val == x) {
            depthFound[0] = depth;
            parentValue[0] = parentVal;
        } else if (root.val == y) {
            depthFound[1] = depth;
            parentValue[1] = parentVal;
        }
        
        TraverseTree(root.left, x, y, root.val, depth + 1);
        TraverseTree(root.right, x, y, root.val, depth + 1);
    }
}
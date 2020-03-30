// https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/

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
    int total = 0;
    
    public int SumRootToLeaf(TreeNode root) {
        if (root == null) {
            return 0;
        }
        
        SumRootToLeaf(root, 0);
        
        return total;
    }
    
    private void SumRootToLeaf(TreeNode root, int currVal) {
        
        if (root.val == 1) {
            currVal++;
        }
        
        // If we have no children we're at the end of this path.
        if (root.left == null && root.right  == null) {
            total += currVal;
        }
        
        // Otherwise, we have at least one child.
        // Double our current value and pass it down.
        currVal *= 2;
        
        if (root.left != null) {
            SumRootToLeaf(root.left, currVal);
        }
        
        if (root.right != null) {
            SumRootToLeaf(root.right, currVal);
        }
    }
}
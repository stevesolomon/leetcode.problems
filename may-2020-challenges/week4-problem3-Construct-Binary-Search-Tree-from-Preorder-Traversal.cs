// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/537/week-4-may-22nd-may-28th/3339/

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
    public TreeNode BstFromPreorder(int[] preorder) {
        if (preorder == null || preorder.Length == 0) {
            return null;
        }
        
        TreeNode root = new TreeNode(preorder[0]);
        BuildBst(root, preorder, 1, preorder.Length);
        
        return root;        
    }
    
    private void BuildBst(TreeNode root, int[] preorder, int idx, int maxIdx) {
        
        if (idx >= maxIdx) {
            return;
        }
        
        // Figure out where our left-subtree ends and the right one begins.
        int rightStartIdx = idx;
        
        while ( rightStartIdx < maxIdx && preorder[rightStartIdx] < root.val) {
            rightStartIdx++;
        }
        
        // Now build our left-subtree first
        // We know we must use elements through to rightStartIdx.
        if (idx != rightStartIdx) {
            root.left = new TreeNode(preorder[idx]);
            BuildBst(root.left, preorder, idx + 1, rightStartIdx);
        }
        
        // Now build our right-subtree if we had any elements for it.
        if (rightStartIdx < maxIdx) {
            root.right = new TreeNode(preorder[rightStartIdx]);
            BuildBst(root.right, preorder, rightStartIdx + 1, maxIdx);
        }        
    }
}
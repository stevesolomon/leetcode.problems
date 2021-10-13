// https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal/submissions/

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
        
        this.BuildBst(preorder, root, 1, preorder.Length);
        
        return root;
    }
    
    public void BuildBst(int[] preorder, TreeNode root, int index, int maxIndex) {
        if (index >= maxIndex) {
            return;
        }
        
        // from index...maxIndex we have elements of our current subtree.
        // These are ordered by elements in the left subtree first, followed by the right.
        // How do we determine where that split is? Once the value is > root.val, it must clearly go in the right subtree.
        int rightSubtreeIdx = index;
        
        while (rightSubtreeIdx < maxIndex && preorder[rightSubtreeIdx] < root.val) {
            rightSubtreeIdx++;
        }
        
        // Now build our left, and then our right, subtrees.
        if (index != rightSubtreeIdx) {
            TreeNode newNode = new TreeNode(preorder[index]);
            root.left = newNode;
            this.BuildBst(preorder, newNode, index + 1, rightSubtreeIdx);
        }
        
        if (rightSubtreeIdx < maxIndex) {
            TreeNode newNode = new TreeNode(preorder[rightSubtreeIdx]);
            root.right = newNode;
            this.BuildBst(preorder, newNode, rightSubtreeIdx + 1, maxIndex);
        }
    }
}
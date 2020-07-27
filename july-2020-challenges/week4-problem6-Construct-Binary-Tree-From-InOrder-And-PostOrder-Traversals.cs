// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/547/week-4-july-22nd-july-28th/3403/

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
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        if (inorder == null || postorder == null || inorder.Length != postorder.Length) {
            return null;
        } else if (inorder.Length == 0) {
            return null;
        }
        
        return BuildTree(inorder, postorder, 0, inorder.Length, 0, postorder.Length);        
    }
    
    private TreeNode BuildTree(
        int[] inOrder, 
        int[] postOrder, 
        int inOrderStartIdx, 
        int inOrderEndIdx,
        int postOrderStartIdx,
        int postOrderEndIdx) {
        // Find root (last element in postorder)
        int rootVal = postOrder[postOrderEndIdx - 1];
        
        TreeNode root = new TreeNode(rootVal);
        
        // Left subtree is all elements left of rootval in inorder
        // and the first X elements (where X = len of inorder left subtree) in 
        // our postorder submatrix is the left subtree.
        int inOrderLeftSubtreeEndIdx = 0;
        
        // Find the rootval in our inorder subarray
        for (inOrderLeftSubtreeEndIdx = inOrderStartIdx; inOrderLeftSubtreeEndIdx < inOrderEndIdx && inOrder[inOrderLeftSubtreeEndIdx] != rootVal; inOrderLeftSubtreeEndIdx++) { }
        
        // Figure out the size of our postOrder subarray for the left tree...
        int newPostOrderEndIdx = postOrderStartIdx + (inOrderLeftSubtreeEndIdx - inOrderStartIdx);
        
        // Build up the left subtree...
        if (inOrderLeftSubtreeEndIdx > inOrderStartIdx && newPostOrderEndIdx < postOrder.Length) {
            root.left = BuildTree(inOrder,
                                  postOrder,
                                  inOrderStartIdx,
                                  inOrderLeftSubtreeEndIdx,
                                  postOrderStartIdx,
                                  newPostOrderEndIdx);
        }
        
        // Right subtree is all elements right of rootval in inorder
        int inOrderRightSubtreeStartIdx = inOrderLeftSubtreeEndIdx + 1;

        // Postorder's right subtree starts at the end of the left subtree
        int postOrderRightSubtreeStartIdx = newPostOrderEndIdx;

        //...and ends with the inorder subtrees length worth of elements
        int postOrderRightSubtreeEndIdx = postOrderRightSubtreeStartIdx + (inOrderEndIdx - inOrderRightSubtreeStartIdx);

        if (inOrderRightSubtreeStartIdx < inOrderEndIdx) {
            root.right = BuildTree(inOrder,
                                   postOrder,
                                   inOrderRightSubtreeStartIdx,
                                   inOrderEndIdx,
                                   postOrderRightSubtreeStartIdx,
                                   postOrderRightSubtreeEndIdx);
        }
        
        return root;
    }
}
// https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/description/

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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return BuildTree(0, 0, inorder.Length, preorder, inorder);
    }
    
    private TreeNode BuildTree(int preIdx, int inStartIdx, int inEndIdx, int[] preorder, int[] inorder) {
        if (preIdx > preorder.Length - 1 || inStartIdx > inEndIdx) {
            return null;
        }
        
        TreeNode node = new TreeNode(preorder[preIdx]);
        
        // Search for the root node of this subtree (preorder[preIdx])
        // in the inorder array. This gives us the left and right subtrees
        // between inStartIdx and inEndIdx.
        int inorderRootIdx = inStartIdx;
        int totalSteps = 0;
        
        for(int i = inStartIdx; i <= inEndIdx; i++) {
            totalSteps++;
            
            if (inorder[i] == preorder[preIdx]) {
                inorderRootIdx = i;                
                break;
            }
        }
        
        // Left subtree is simple. Preorder subtree is simply the next element.
        // Inorder subtree is everything from our start, up until the root node index we located.
        node.left = BuildTree(preIdx + 1, inStartIdx, inorderRootIdx - 1, preorder, inorder);
        
        // We are trying to figure out how many nodes there are on the left side of this subtree in preorder
        // The inorder array tells us how many nodes we had to step over in the array
        // from the start of the subtree, which will give us the starting point for the right 
        // subtree's location in the preorder array.
        node.right = BuildTree(preIdx + totalSteps, inorderRootIdx + 1, inEndIdx, preorder, inorder);
        
        return node;
    }
}
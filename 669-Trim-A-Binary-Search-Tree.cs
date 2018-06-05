// https://leetcode.com/problems/trim-a-binary-search-tree/description/

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
    public TreeNode TrimBST(TreeNode root, int L, int R) {
        if (root == null) {
            return root;
        }
        
        // Item1 = currNode, Item2 = parent
        Stack<Tuple<TreeNode, TreeNode>> traversal = new Stack<Tuple<TreeNode, TreeNode>>();
        
        traversal.Push(new Tuple<TreeNode, TreeNode>(root, null));
        
        while (traversal.Count > 0) {
            
            Tuple<TreeNode, TreeNode> currTuple = traversal.Pop();
            TreeNode curr = currTuple.Item1;
            TreeNode parent = currTuple.Item2;
            
            // If the curr node's value is within L and R keep it
            // and just add the children to be considered.
            if (curr.val >= L && curr.val <= R) {
                
                if (curr.left != null) {
                    traversal.Push(new Tuple<TreeNode, TreeNode>(curr.left, curr));
                }
                
                if (curr.right != null) {
                    traversal.Push(new Tuple<TreeNode, TreeNode>(curr.right, curr));
                }
            } else {
                
                // If we are less than L, we need to remove this node and the entire left subtree.
                // Otherwise (> R) we need to remove this node and the entire right subtree.
                bool removeLeft = curr.val < L;
                TreeNode subTreeRootToRemove = removeLeft ? curr.left : curr.right;
                TreeNode subTreeRootToKeep = removeLeft ? curr.right : curr.left;
                
                if (parent == null) {
                    // We're removing the root node.
                    root = subTreeRootToKeep;
                } else if (parent.left == curr) {
                    // We're removing the parent's left child
                    parent.left = subTreeRootToKeep;
                } else {
                    // We're removing the parent's right child.
                    parent.right = subTreeRootToKeep;
                }
                
                if (subTreeRootToKeep != null) {
                    traversal.Push(new Tuple<TreeNode, TreeNode>(subTreeRootToKeep, parent));
                }
            }
        }
        
        return root;
    }
}
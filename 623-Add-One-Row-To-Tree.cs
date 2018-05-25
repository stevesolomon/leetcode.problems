// https://leetcode.com/problems/add-one-row-to-tree/description/

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
    public TreeNode AddOneRow(TreeNode root, int v, int d) {
        
        if (root == null || d <= 0) {
            return root;
        }
        
        // Special case for replacing the root itself.
        if (d == 1) {
            TreeNode newRoot = new TreeNode(v);
            newRoot.left = root;
            return newRoot;
        }
        
        // Otherwise, perform a BFS traversal of the tree until we reach the right layer.
        Queue<TreeNode> traversal = new Queue<TreeNode>();
        traversal.Enqueue(root);
        traversal.Enqueue(null);
        
        int currLayer = 2;
        
        while (traversal.Count > 0 && currLayer < d) {
            TreeNode node = traversal.Dequeue();
            
            if (node == null) {
                currLayer++;
                
                if (traversal.Count > 0) {
                    traversal.Enqueue(null);
                }
                
                continue;
            }
            
            if (node.left != null) {
                traversal.Enqueue(node.left);
            }
            
            if (node.right != null) {
                traversal.Enqueue(node.right);
            }
        }
        
        // Our Queue now contains only those nodes in the targeted layer.
        // (plus a null at the end which we'll need to take care of)
        while (traversal.Count > 0) {
            TreeNode node = traversal.Dequeue();
            
            if (node == null) {
                continue;
            }

            TreeNode newLeftNode = new TreeNode(v);
            newLeftNode.right = node.right;
            node.right = newLeftNode;

            TreeNode newRightNode = new TreeNode(v);
            newRightNode.left = node.left;
            node.left = newRightNode;
        }
        
        return root;
    }
}
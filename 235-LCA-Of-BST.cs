//https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/description/ 

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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        
        // Base case, we haven't found anything on this path.
        if (root == null) {
            return null;
        }
        
        bool pLeft = p.val <= root.val;
        bool qLeft = q.val <= root.val;
        
        // If each node is on either side of the current root, the current root
        // must be the LCA.
        if (pLeft && !qLeft || !pLeft && qLeft) {
            return root;
        } else {
            // Both nodes are on the same subtree.
            
            // If p has the root val, then p is the LCA
            // Same with q.
            if (p.val == root.val) {
                return p;
            } else if (q.val == root.val) {
                return q;
            } else if (pLeft && qLeft) {
                // Search on the left subtree for our solution
                return LowestCommonAncestor(root.left, p, q);
            } else {
                // Search on the right subtree for our solution
                return LowestCommonAncestor(root.right, p, q);
            }
        }       
    }
}
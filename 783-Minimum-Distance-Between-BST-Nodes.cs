// https://leetcode.com/problems/minimum-distance-between-bst-nodes/description/
// Note that this solution is not really optimal.

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
    public int MinDiffInBST(TreeNode root) {
        if (root == null || (root.left == null && root.right == null)) {
            return 0;
        }
        
        int minDiff = int.MaxValue;
        
        // Perform a traversal of the tree, and store each node's value.
        List<int> vals = new List<int>();
        HashSet<int> observedVal = new HashSet<int>();
        Stack<TreeNode> traversal = new Stack<TreeNode>();
        
        traversal.Push(root);
        
        while (traversal.Count > 0) {
            TreeNode curr = traversal.Pop();
            
            if (!observedVal.Contains(curr.val)) {
                observedVal.Add(curr.val);
                vals.Add(curr.val);
            }
            
            if (curr.left != null) {
                traversal.Push(curr.left);
            }
            
            if (curr.right != null) {
                traversal.Push(curr.right);
            }            
        }
        
        vals.Sort();
        
        for (int i = 1; i < vals.Count; i++) {
            minDiff = Math.Min(Math.Abs(vals[i] - vals[i-1]), minDiff);
        }
        
        return minDiff;        
    }
}
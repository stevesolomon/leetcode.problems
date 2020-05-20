// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/536/week-3-may-15th-may-21st/3335/

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
    public int KthSmallest(TreeNode root, int k) {
        
        if (root == null) {
            throw new ArgumentException("root");
        }
        
        // Traverse the tree in-order and stop once we're at the kth node.
        Stack<TreeNode> traversal = new Stack<TreeNode>();
        TreeNode curr = root;        
        int visitedCount = 0;
        
        while (curr != null || traversal.Count > 0) {
            
            // Go as far left as we can, pushing each node
            while (curr != null) {
                traversal.Push(curr);
                curr = curr.left;
            }
            
            // Pop the left-most visited node (top of stack)
            TreeNode visited = traversal.Pop();
            visitedCount++;
            
            if (visitedCount == k) {
                return visited.val;
            }
            
            // Now get the right node (next highest after the "root" we popped)
            curr = visited.right;
        }
        
        return -1;
    }
}
// https://leetcode.com/problems/kth-smallest-element-in-a-bst/

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
        
        // Traverse the tree in-order and push each visited TreeNode
        // to a Queue. This gives us all numbers in order.
        Queue<int> orderedNums = new Queue<int>();        
        InOrderTraversal(root, orderedNums);
        
        // Now simply Dequeue the first k numbers.
        if (orderedNums.Count < k) {
            throw new Exception("Tree did not have at least k elements");
        }
        
        int result = 0;
        for (int i = 0; i < k; i++) {
            result = orderedNums.Dequeue();
        }
        
        return result;
    }
    
    private void InOrderTraversal(TreeNode root, Queue<int> orderedNums) {
        
        if (root == null) {
            return;
        }
        
        // Visit left subtree
        InOrderTraversal(root.left, orderedNums);
        
        // Visit root
        orderedNums.Enqueue(root.val);
        
        // Visit right subtree
        InOrderTraversal(root.right, orderedNums);
    }
}
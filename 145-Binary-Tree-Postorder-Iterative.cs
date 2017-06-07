/** https://leetcode.com/problems/binary-tree-postorder-traversal/#/description
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<int> PostorderTraversal(TreeNode root) {
        
        List<int> traversal = new List<int>();
        
        if (root == null) {
            return traversal;
        }
        
        HashSet<TreeNode> visitedNodes = new HashSet<TreeNode>();
        Stack<TreeNode> traversalStack = new Stack<TreeNode>();
        
        traversalStack.Push(root);
        
        while (traversalStack.Any()) {
            // Pop the next TreeNode from the stack
            TreeNode curr = traversalStack.Pop();
            
            // If we've previously visited this node, or if it has no children,
            // then add it to the traversal list.
            if (visitedNodes.Contains(curr) || (curr.right == null && curr.left == null)) {
                traversal.Add(curr.val);
                continue;
            }
            
            // Repush our current node on to the stack and mark it as visited
            visitedNodes.Add(curr);
            traversalStack.Push(curr);
            
            // Push the right child on to the stack
            if (curr.right != null) {
                traversalStack.Push(curr.right);
            }
            
            // Push the left child on to the stack
            if (curr.left != null) {
                traversalStack.Push(curr.left);
            }
        }
        
        return traversal;
    }
}
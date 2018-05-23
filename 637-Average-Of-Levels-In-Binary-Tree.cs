// https://leetcode.com/problems/average-of-levels-in-binary-tree/description/

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
    public IList<double> AverageOfLevels(TreeNode root) {
        List<double> results = new List<double>();
        
        if (root == null) {
            return results;
        }        
        
        Queue<TreeNode> visit = new Queue<TreeNode>();
        
        visit.Enqueue(root);
        visit.Enqueue(null);
        
        long totalVal = 0;
        int numNodes = 0;
        
        while (visit.Count > 0) {
            TreeNode node = visit.Dequeue();
            
            if (node == null) {
                results.Add((double) totalVal / (double) numNodes);
                
                totalVal = 0;
                numNodes = 0;
                
                if (visit.Count > 0) {
                    visit.Enqueue(null);
                }
                
                continue;
            }
            
            totalVal += node.val;
            numNodes++;
            
            if (node.left != null) {
                visit.Enqueue(node.left);
            }
            
            if (node.right != null) {
                visit.Enqueue(node.right);
            }
        }
        
        return results;
    }
}
// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/547/week-4-july-22nd-july-28th/3398/

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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        if (root == null) {
            return new List<IList<int>>();
        }
        
        List<IList<int>> results = new List<IList<int>>();
        Queue<TreeNode> bfs = new Queue<TreeNode>();
        bfs.Enqueue(root);
        bfs.Enqueue(null);
        
        List<int> currLayer = new List<int>();
        bool oddLayer = true;
        
        while (bfs.Count > 0) {
            var curr = bfs.Dequeue();
            
            // Layer terminator
            if (curr == null) {                
                // Still more layers to traverse
                if (bfs.Count > 0) {
                    bfs.Enqueue(null);
                }
                
                // Add current layer results...
                if (oddLayer) {
                    currLayer.Reverse();
                }                
                oddLayer = !oddLayer;
                
                results.Add(new List<int>(currLayer));
                currLayer.Clear();
                continue;
            }
            
            // Otherwise queue up the right then left children
            // and write our current value to the results list.
            if (curr.right != null) {
                bfs.Enqueue(curr.right);
            }
            
            if (curr.left != null) {
                bfs.Enqueue(curr.left);
            }
            
            currLayer.Add(curr.val);
        }
        
        return results;        
    }
}
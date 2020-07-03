// https://leetcode.com/explore/featured/card/july-leetcoding-challenge/544/week-1-july-1st-july-7th/3378/

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
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {       
        if (root == null) {
            return new List<IList<int>>();
        }
        
        Queue<TreeNode> bfs = new Queue<TreeNode>();
        Stack<IList<int>> results = new Stack<IList<int>>();
        bfs.Enqueue(root);
        bfs.Enqueue(null); // Layer terminators
        
        List<int> currLayer = new List<int>();
        
        while (bfs.Count > 0) {
            TreeNode curr = bfs.Dequeue();
            
            if (curr == null) {
                // We've started a new later, dump our current list into the stack.
                results.Push(new List<int>(currLayer));
                currLayer.Clear();
                
                if (bfs.Count > 0) {
                    bfs.Enqueue(null);
                }
                
                continue;
            }
            
            // Otherwise continue traversing...
            currLayer.Add(curr.val);
            
            if (curr.left != null) {
                bfs.Enqueue(curr.left);
            }
            
            if (curr.right != null) {
                bfs.Enqueue(curr.right);
            }
        }
        
        List<IList<int>> finalResults = new List<IList<int>>();
        
        while (results.Count > 0) {
            finalResults.Add(results.Pop());
        }
        
        return finalResults;
    }
}
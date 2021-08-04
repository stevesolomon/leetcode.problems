// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/613/week-1-august-1st-august-7th/3838/

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
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        IList<IList<int>> results = new List<IList<int>>();
        
        if (root == null) {
            return results;
        }
        
        // Perform a DFS traversal of the tree to find all root-to-leaf paths
        // that equal the target sum.
        PathSumDFS(root, targetSum, 0, new List<int> { root.val }, results);
        
        return results;
    }
    
    private void PathSumDFS(TreeNode root, int targetSum, int currSum, List<int> currPath, IList<IList<int>> results) {
        
        currSum += root.val;
        
        // Are we at a leaf node? We're done then.
        if (root.left == null && root.right == null) {
            if (currSum == targetSum) {
                results.Add(new List<int>(currPath));
            }
            
            return;
        }
        
        // Otherwise, try traversing the left and right subtrees.
        if (root.left != null) {
            currPath.Add(root.left.val);
            PathSumDFS(root.left, targetSum, currSum, currPath, results);
            currPath.RemoveAt(currPath.Count - 1);
        }
        
        if (root.right != null) {
            currPath.Add(root.right.val);
            PathSumDFS(root.right, targetSum, currSum, currPath, results);
            currPath.RemoveAt(currPath.Count - 1);
        }
    }
}
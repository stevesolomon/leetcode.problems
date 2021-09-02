// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/636/week-1-september-1st-september-7th/3961/

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
    public IList<TreeNode> GenerateTrees(int n) {
        return GenerateTrees(1, n);
    }
    
    private IList<TreeNode> GenerateTrees(int start, int end) {
        IList<TreeNode> results = new List<TreeNode>();
        
        // Base case: no more values to select from.
        if (start > end) {
            results.Add(null);
            return results;
        }
        
        // Base case: only one value to select from.
        if (start == end) {
            results.Add(new TreeNode(start));
            return results;
        }
        
        // Otherwise, start a tree rooted at each possible value
        for (int i = start; i <= end; i++) {
            
            // Build up all possible left and right subtrees with i 
            // as their root.
            IList<TreeNode> leftSubtrees = GenerateTrees(start, i - 1);
            IList<TreeNode> rightSubtrees = GenerateTrees(i + 1, end);
            
            // Now build up a tree rooted at i using every combination
            // from our left and right subtrees.
            foreach (var leftTree in leftSubtrees) {
                foreach (var rightTree in rightSubtrees) {
                    results.Add(new TreeNode(i, leftTree, rightTree));
                }
            }
        }
        
        return results;
    }
}
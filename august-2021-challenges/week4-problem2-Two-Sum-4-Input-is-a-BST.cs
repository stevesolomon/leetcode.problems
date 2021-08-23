// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/616/week-4-august-22nd-august-28th/3908/

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
    public bool FindTarget(TreeNode root, int k) {
        if (root == null) {
            return false;
        }
        
        return FindTarget(root, k, new HashSet<int>());
    }
    
    private bool FindTarget(TreeNode root, int k, HashSet<int> targets) {
        if (root == null) {
            return false;
        }
        
        int target = k - root.val;
        
        if (targets.Contains(target)) {
            return true;
        }
        
        targets.Add(root.val);        
        return FindTarget(root.left, k, targets) || FindTarget(root.right, k, targets);
    }
}
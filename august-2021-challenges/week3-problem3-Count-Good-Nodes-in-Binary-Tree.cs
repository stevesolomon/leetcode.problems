// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/615/week-3-august-15th-august-21st/3899/

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
    public int GoodNodes(TreeNode root) {        
        // We'll do a simple traversal of the tree keeping track
        // of the highest value found thus far in this particular branch.        
        return GoodNodes(root, int.MinValue);        
    }
    
    public int GoodNodes(TreeNode root, int highVal) {
        if (root == null) {
            return 0;
        }
        
        highVal = Math.Max(highVal, root.val);
        int count = 0;
        
        if (root.val >= highVal) {
            count++;
        }
        
        return count + GoodNodes(root.left, highVal) + GoodNodes(root.right, highVal);
    }
}
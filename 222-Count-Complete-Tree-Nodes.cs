// https://leetcode.com/problems/count-complete-tree-nodes/description/

public class Solution {
    public int CountNodes(TreeNode root) {
        if (root == null) {
            return 0;
        }
        
        int rightHeight = GetDirectedHeight(root, false);
        int leftHeight = GetDirectedHeight(root, true);
        
        if (rightHeight == leftHeight) {
            return (int) Math.Pow(2, rightHeight) - 1;
        } else {
            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }        
    }
    
    private int GetDirectedHeight(TreeNode root, bool goLeft) {
        TreeNode currNode = root;
        int height = 0;
        
        while (currNode != null) {
            currNode = goLeft ? currNode.left : currNode.right;
            height++;
        }
        
        return height;
    }
}
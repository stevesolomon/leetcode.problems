// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/545/week-2-july-8th-july-14th/3385/

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
    public int WidthOfBinaryTree(TreeNode root) {
        if (root == null) {
            return 0;
        }
        
        // Transform our binary tree into array format...
        // And then traverse the array level by level to determine
        // the best width at each level.
        // We don't need to actually store the tree, just go layer-by-layer,
        // keeping track of where the node would be positioned in the array if we had one.
        // (for parent i, idx = i * 2 for the left child, i * 2 + 1 for the right)
        Queue<Tuple<TreeNode, int>> traversal = new Queue<Tuple<TreeNode, int>>();
        traversal.Enqueue(new Tuple<TreeNode, int>(root, 0));       
        
        int bestWidth = int.MinValue;
                
        while (traversal.Count > 0) {
            
            // When we begin traversing a layer, we have only those
            // nodes in the queue that belong to this layer.
            // We can determine the width based on the array indices we've written...
            bestWidth = Math.Max(bestWidth, traversal.Last().Item2 - traversal.First().Item2 + 1);
            
            // Traverse the entire layer all at once...
            int layerCount = traversal.Count;
            
            for (int i = 0; i < layerCount; i++) {
                var tuple = traversal.Dequeue();
                var currNode = tuple.Item1;
                var currNodeIdx = tuple.Item2;
                
                // Push children as long as they're not null, keeping track of their indices.
                if (currNode.left != null) {
                    traversal.Enqueue(new Tuple<TreeNode, int>(currNode.left, currNodeIdx * 2));
                }
                
                if (currNode.right != null) {
                    traversal.Enqueue(new Tuple<TreeNode, int>(currNode.right, currNodeIdx * 2 + 1));
                }
            }
        }
        
        return bestWidth;
    }
}
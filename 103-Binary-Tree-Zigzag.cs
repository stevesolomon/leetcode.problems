// https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/

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
    
    private enum Direction {
        LeftToRight,
        RightToLeft
    }
    
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        
        List<IList<int>> result = new List<IList<int>>();
        
        if (root == null) {
            return result;
        }
                
        Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
        nodeQueue.Enqueue(root);
        nodeQueue.Enqueue(null);
        
        List<int> currLayer = new List<int>();
        
        // We did "LeftToRight" when we added the root above.
        Direction direction = Direction.RightToLeft;
        
        while (nodeQueue.Count > 0) {
            TreeNode currNode = nodeQueue.Dequeue();
            
            // Layer hint. At this point we want to wrap up our current list
            // and start another.
            if (currNode == null) {
                result.Add(currLayer);
                currLayer = new List<int>();
                
                direction = direction == Direction.LeftToRight ? Direction.RightToLeft : Direction.LeftToRight;
                
                // Add another null to the end of the Queue to mark the next layer
                // iff we have elements remaining (otherwise we're done)                
                if (nodeQueue.Count > 0) {
                    nodeQueue.Enqueue(null);
                }
                
                continue;
            }
            
            // Depending on the direction that we're going, we want to either add the 
            // current node's value to the start of the layer list (RightToLeft), or the end (LeftToRight).
            // This is due to the fact that we are performing a BFS traversal of the tree so we are always
            // visiting nodes in Left-to-Right order, regardless of the current direction.
            switch (direction) {
                case Direction.RightToLeft:
                    currLayer.Add(currNode.val);
                    break;
                case Direction.LeftToRight:
                    currLayer.Insert(0, currNode.val);
                    break;
            }
            
            if (currNode.left != null) {
                nodeQueue.Enqueue(currNode.left);
            }
            
            if (currNode.right != null) {
                nodeQueue.Enqueue(currNode.right);
            }
        }
        
        return result;        
    }
}
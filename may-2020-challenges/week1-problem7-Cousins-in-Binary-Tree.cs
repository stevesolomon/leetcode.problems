// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/534/week-1-may-1st-may-7th/3322/

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
    public bool IsCousins(TreeNode root, int x, int y) {
        if (root == null) {
            return false;
        }
        
        // If the root is X or Y we can stop early...
        if (root.val == x || root.val == y) {
            return false;
        }
        
        // We will perform a breadth-first search of the tree, keeping
        // track of the level that we're one, and the parent of each node we traverse.
        // When we find either x or y, we must find the other within the same level.
        int level = 0;
        bool foundX = false;
        bool foundY = false;
        int parentX = -1;
        int parentY = -1;
        
        // The Tuple stores <currNode, parent>
        Queue<Tuple<TreeNode, TreeNode>> bfs = new Queue<Tuple<TreeNode, TreeNode>>();
        bfs.Enqueue(new Tuple<TreeNode, TreeNode>(root, null));
        bfs.Enqueue(null); // nulls are level terminators.
        
        while (bfs.Count > 0) {
            Tuple<TreeNode, TreeNode> curr = bfs.Dequeue();
            
            // End of the level. Increment level and add a new level
            // terminator IFF we still have elements in the queue.
            if (curr == null) {
                
                if (bfs.Count > 0) {
                    level++;
                    bfs.Enqueue(null);

                    // Have we foundX or Y already? If we're moving to another
                    // level and still have one to find we've failed.
                    if (foundX || foundY) {
                        return false;
                    }
                }
                
                continue;
            }
            
            // Otherwise, visit the curr node...
            TreeNode currNode = curr.Item1;
            TreeNode parentNode = curr.Item2;
            
            // Have we found X or Y?
            if (currNode.val == x) {
                foundX = true;
                parentX = parentNode.val;
            } else if (currNode.val == y) {
                foundY = true;
                parentY = parentNode.val; 
            }
            
            // Did we end up finding both X and Y? Return true/false depending
            // on their parents.
            if (foundX && foundY) {
                return parentX != parentY;
            }
            
            //Otherwise keep searching and line up the child nodes...
            if (currNode.left != null) {
                bfs.Enqueue(new Tuple<TreeNode, TreeNode>(currNode.left, currNode));
            }
            
            if (currNode.right != null) {
                bfs.Enqueue(new Tuple<TreeNode, TreeNode>(currNode.right, currNode));
            }
        }
        
        return foundX && foundY;        
    }
}
// https://leetcode.com/problems/count-complete-tree-nodes/

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
    public int CountNodes(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        else if (root.left == null && root.right == null)
        {
            return 1;
        }

        // First, figure out the number of layers in the tree.
        // We can do this by just traversing the left subtrees as far as possible.
        int height = 0;
        int totalNodes = 0;
        TreeNode curr = root;

        while (curr != null)
        {
            curr = curr.left;
            height++;
        }

        totalNodes = (int)Math.Pow(2, height) - 1;

        // Now, we want to find the left-most root-to-leaf path that has one level
        // less than the tree's height.
        // First we can do a quick check to see if the entire tree is full...
        curr = root;
        int currLevel = 0;

        while (curr != null)
        {
            curr = curr.right;
            currLevel++;
        }

        if (height == currLevel)
        {
            return totalNodes;
        }

        // Otherwise, let's do a binary search to find the left-most path that's shorter.
        int low = 0;
        int high = (int)Math.Pow(2, height - 1) - 1;
        int mid = 0;

        while (low < high)
        {
            mid = low + (high - low) / 2;

            // Our mid represents the Nth leaf node. How do we traverse to it?
            // Using the binary representation of mid, from MSB to LSB, 0 ==> left, 1 ==> right.
            // If we find we can't take a path, our first path is between low...mid (mid could still be it, we just can't confirm yet)
            // If we can take a path, we need to look at mid+1...high (we can drop mid as it's not a short branch.
            bool fullPath = this.PathIsOfHeight(root, mid, height);

            if (!fullPath)
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        totalNodes = (int)Math.Pow(2, height - 1) - 1;
        totalNodes += low;

        return totalNodes;
    }

    public bool PathIsOfHeight(TreeNode root, int path, int height)
    {
        int mask = 1 << (height - 2);
        TreeNode curr = root;

        while (mask > 0)
        {
            if (curr == null)
            {
                return false;
            }

            bool goRight = (path & mask) != 0;

            if (goRight)
            {
                curr = curr.right;
            }
            else
            {
                curr = curr.left;
            }

            mask >>= 1;
        }

        return curr == null ? false : true;
    }
}
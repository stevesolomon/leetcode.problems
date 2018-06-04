// https://leetcode.com/problems/delete-node-in-a-bst/description/

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
    public TreeNode DeleteNode(TreeNode root, int key) {
        if (root == null) {
            return null;
        } else if (root.val == key && root.left == null && root.right == null) {
            return null;
        } else if (root.val == key && root.left == null) {
            return root.right;
        } else if (root.val == key && root.right == null) {
            return root.left;
        }

        // Key = Node we're searching for; Value = its parent
        KeyValuePair<TreeNode, TreeNode> nodeAndParent = FindNodeAndParent(root, key);

        if (nodeAndParent.Key == null) {
            // We didn't find the key, we're done.
            return root;
        }

        TreeNode nodeToDelete = nodeAndParent.Key;
        TreeNode parent = nodeAndParent.Value;

        // Otherwise, we found the key.
        // There are a few scenarios here:
        //   (1) The node is a leaf node. Just remove it.
        //   (2) The node only has a single child. Just swap it with its child.
        //   (3) The node has two children. Swap it with the next greatest value
        //       (the left-most child on the right subtree) and then delete that node.
        if (nodeToDelete.left == null && nodeToDelete.right == null) {
            if (nodeToDelete.val > parent.val) {
                parent.right = null;
            } else {
                parent.left = null;
            }
        } else if (nodeToDelete.left == null) {
            if (nodeToDelete.val > parent.val) {
                parent.right = nodeToDelete.right;
            } else {
                parent.left = nodeToDelete.right;
            }
        } else if (nodeToDelete.right == null) {
            if (nodeToDelete.val > parent.val) {
                parent.right = nodeToDelete.left;
            } else {
                parent.left = nodeToDelete.left;
            }
        } else {
            // Here is our special case. We first need to find the left-most child
            // on the right subtree (the node with the next greatest value).
            KeyValuePair<TreeNode, TreeNode> nodeToSwapAndParent = FindNextGreatestValue(nodeToDelete);

            // Now swap the value of this node with the node to delete.
            int val = nodeToSwapAndParent.Key.val;

            TreeNode localParent = nodeToSwapAndParent.Value;

            // And then delete the node we just swapped with.
            // We start with the node we swapped with's parent, as that gets us
            // right there immediately.
            localParent = DeleteNode(nodeToSwapAndParent.Value, nodeToSwapAndParent.Key.val);

            nodeToDelete.val = val;
        }

        return root;
    }

    private KeyValuePair<TreeNode, TreeNode> FindNodeAndParent(TreeNode root, int key) {
        KeyValuePair<TreeNode, TreeNode> result;

        TreeNode parent = null;
        TreeNode curr = root;

        while (curr != null && curr.val != key) {
            parent = curr;

            if (key < curr.val) {
                // Go left
                curr = curr.left;
            } else {
                // Go right
                curr = curr.right;
            }
        }

        result = new KeyValuePair<TreeNode, TreeNode>(curr, parent);

        return result;
    }

    private KeyValuePair<TreeNode, TreeNode> FindNextGreatestValue(TreeNode root) {
        KeyValuePair<TreeNode, TreeNode> result ;

        TreeNode parent = root;
        TreeNode curr = root.right;

        // Now traverse left as far as we can
        while (curr.left != null) {
            curr = curr.left;
        }

        result = new KeyValuePair<TreeNode, TreeNode>(curr, parent);

        return result;
    }
}
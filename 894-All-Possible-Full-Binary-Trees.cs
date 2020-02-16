// https://leetcode.com/problems/all-possible-full-binary-trees/

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
    
    public IList<TreeNode> AllPossibleFBT(int N) {
        if (N == 0 || N % 2 == 0) {
            return new List<TreeNode>();
        } else if (N == 1) {
            return new List<TreeNode> { new TreeNode(0) };
        }
        
        // Each possible tree we create will have X nodes on the right side, and N - 1 - X (-1 to account for root) nodes on the left side.
        // So we just need to consider all possible trees with these node combinations.
        List<TreeNode> trees = new List<TreeNode>();
        
        int nodesLeft = N - 1;
        
        // Consider all possible X values (nodes on the right side). Noting that we must keep at least 1 node
        // on the left side.
        for (int rightNodes = 1; rightNodes < nodesLeft; rightNodes += 2) {
            int leftNodes = nodesLeft - rightNodes;
            
            IList<TreeNode> allRightSubtrees = AllPossibleFBT(rightNodes);
            IList<TreeNode> allLeftSubtrees = AllPossibleFBT(leftNodes);
            
            // We now have two lists of all possible right/left subtrees.
            // Let's iterate through all combinations and create a single rooted tree from them.
            foreach (var rightSubtree in allRightSubtrees) {
                foreach (var leftSubtree in allLeftSubtrees) {
                    TreeNode root = new TreeNode(0);
                    root.right = rightSubtree;
                    root.left = leftSubtree;
                    trees.Add(root);
                }
            }
        }
        
        return trees;
    }
}
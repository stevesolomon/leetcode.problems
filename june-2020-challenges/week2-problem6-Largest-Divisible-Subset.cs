// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/540/week-2-june-8th-june-14th/3359/

public class Solution {
    
    public class TreeNode {
        public int val;
        public int height;
        public List<TreeNode> children;
        public TreeNode parent;
        
        public TreeNode(int val, int height, TreeNode parent) {
            this.val = val;
            this.height = height;
            this.parent = parent;
            this.children = new List<TreeNode>();
        }
    }
    
    public IList<int> LargestDivisibleSubset(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return new List<int>();
        } else if (nums.Length == 1) {
            return new List<int> { nums[0] };
        }

        // We'll build a tree where every child is divisible by its parent
        // (and, thus, by all nodes above it).
        Array.Sort(nums);

        // Start with a dummy TreeNode of 1 as everything is divisible by 1.
        // We'll have to ignore this one when we build our solution.
        TreeNode root = new TreeNode(1, 0, null);
        TreeNode bestLeaf = root;

        foreach (int num in nums) {
            List<TreeNode> nodeResults = new List<TreeNode>();
            InsertToTree(root, num, nodeResults);

            foreach (var node in nodeResults) {
                if (node.height > bestLeaf.height) {
                    bestLeaf = node;
                }
            }
        }

        // Finally, traverse backwards from our bestLeaf to get the
        // full parent chain.
        List<int> results = new List<int>();

        while (bestLeaf != null && bestLeaf.parent != null)
        {
            results.Add(bestLeaf.val);
            bestLeaf = bestLeaf.parent;
        }

        return results;
    }

    private void InsertToTree(TreeNode root, int num, List<TreeNode> results)
    {
        // Find child nodes to insert into. If there isn't any, insert here.
        // We have to find all possible children to insert into, as a number can 
        // have multiple divisors, and only one of those may eventually lead
        // to the longest path through the tree.
        List<TreeNode> candidateChildren = new List<TreeNode>();
        
        foreach (var child in root.children) {
            if (num % child.val == 0) {
                candidateChildren.Add(child);
            }
        }

        if (candidateChildren.Count == 0) {
            // Add here
            TreeNode newNode = new TreeNode(num, root.height + 1, root);
            root.children.Add(newNode);
            results.Add(newNode);
            return;
        }

        // Otherwise insert into each of our candidate children...
        foreach (var child in candidateChildren) {
            InsertToTree(child, num, results);
        }
    }
}
// https://leetcode.com/problems/most-frequent-subtree-sum/description/

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
    public int[] FindFrequentTreeSum(TreeNode root) {
        
        if (root == null) {
            return new int[0];
        } else if (root.left == null && root.right == null) {
            return new int[] { root.val };
        }        
        
        Dictionary<int, int> sumCounts = new Dictionary<int, int>();
        
        // Perform a postorder traversal of the tree:
        //    Visit right subtree (get total for this subtree)
        //    Visit left subtree (get total for this subtree)
        //    Visit root (add right + left + root, and also store root value)
        PostOrderTraversal(root, sumCounts);
        
        // Now determine the highest subtree count(s)
        return GetBestCounts(sumCounts);
    }
    
    private int PostOrderTraversal(TreeNode root, Dictionary<int, int> sumCounts) {
                
        int leftVal = 0, rightVal = 0;
        
        if (root.left != null) {
            leftVal = PostOrderTraversal(root.left, sumCounts);
        }
        
        if (root.right != null) {
            rightVal = PostOrderTraversal(root.right, sumCounts);
        }
        
        int subTreeVal = leftVal + rightVal + root.val;
        
        AddCount(sumCounts, subTreeVal); 
        
        return subTreeVal;        
    }
    
    private void AddCount(Dictionary<int, int> sumCounts, int val) {

        if (!sumCounts.ContainsKey(val)) {
            sumCounts.Add(val, 0);
        }
        
        sumCounts[val]++;
    }
    
    private int[] GetBestCounts(Dictionary<int, int> sumCounts) {
        
        // We only want to scan through the Dictionary once, so maintain
        // a List containing all the values with the current highest count.
        int bestCount = int.MinValue;
        List<int> highestCounts = new List<int>();
        
        foreach (var key in sumCounts.Keys) {
            if (sumCounts[key] > bestCount) {
                bestCount = sumCounts[key];
                highestCounts.Clear();
                
                highestCounts.Add(key);
            } else if (sumCounts[key] == bestCount) {
                highestCounts.Add(key);
            }
        }
        
        return highestCounts.ToArray();
    }
}
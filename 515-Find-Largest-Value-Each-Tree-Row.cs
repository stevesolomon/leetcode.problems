// https://leetcode.com/problems/find-largest-value-in-each-tree-row/description/

public class Solution {
    public IList<int> LargestValues(TreeNode root) {
        
        List<int> results = new List<int>();
        
        if (root == null) {
            return results;
        }        
        
        Queue<TreeNode> traversal = new Queue<TreeNode>();
        
        traversal.Enqueue(root);
        traversal.Enqueue(null);
        
        int highestThisLevel = int.MinValue;
        
        while (traversal.Count > 0) {
            
            TreeNode currNode = traversal.Dequeue();
            
            if (currNode == null) {
                results.Add(highestThisLevel);
                highestThisLevel = int.MinValue;
                
                if (traversal.Count > 0) {
                    traversal.Enqueue(null);
                }
                
                continue;
            }
            
            highestThisLevel = Math.Max(highestThisLevel, currNode.val);
            
            if (currNode.left != null) {
                traversal.Enqueue(currNode.left);
            }
            
            if (currNode.right != null) {
                traversal.Enqueue(currNode.right);
            }
        }
        
        return results;
    }
}
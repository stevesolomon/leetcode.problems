// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/613/week-1-august-1st-august-7th/3871/

/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<IList<int>> LevelOrder(Node root) {
        IList<IList<int>> results = new List<IList<int>>();
        
        if (root == null) {
            return results;
        }
        
        // When we reach the end of a level we need to start a new list.
        // We'll use a null node in our queue to identify new levels.
        Queue<Node> traversal = new Queue<Node>();
        traversal.Enqueue(root);
        traversal.Enqueue(null);
        
        List<int> currResult = new List<int>();
        
        while (traversal.Count > 0) {
            
            var currNode = traversal.Dequeue();
            
            if (currNode == null) {
                // Copy our current results list and start a new one
                results.Add(new List<int>(currResult));
                currResult.Clear();
                
                // If we still have more in the queue, add a new level terminator
                if (traversal.Count > 0) {
                    traversal.Enqueue(null);
                }
                
                continue;
            }
            
            // Otherwise, store the current node's value in our current list
            // and enqueue the children.
            currResult.Add(currNode.val);
            
            if (currNode.children != null) {
                foreach (var child in currNode.children) {
                    traversal.Enqueue(child);
                }
            }         
        }
        
        return results;        
    }
}
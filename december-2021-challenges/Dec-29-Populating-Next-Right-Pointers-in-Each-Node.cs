// https://leetcode.com/problems/populating-next-right-pointers-in-each-node/

/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        if (root == null) {
            return root;
        } else if (root.left == null && root.right == null) {
            return root;
        }
        
        Queue<Node> traversal = new Queue<Node>();
        traversal.Enqueue(root);
        traversal.Enqueue(null);
        
        while (traversal.Count > 0) {
            Node curr = traversal.Dequeue();
            
            if (curr == null) {
                if (traversal.Count > 0) {
                    traversal.Enqueue(null);
                }
                
                continue;
            }
            
            Node next = traversal.Peek();
            curr.next = next;
            
            if (curr.left != null) {
                traversal.Enqueue(curr.left);
            }
            
            if (curr.right != null) {
                traversal.Enqueue(curr.right);
            }
        }
        
        return root;
    }
}

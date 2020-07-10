// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/545/week-2-july-8th-july-14th/3386/

/*
// Definition for a Node.
public class Node {
    public int val;
    public Node prev;
    public Node next;
    public Node child;
}
*/

public class Solution {
    public Node Flatten(Node head) {
        if (head == null) {
            return head;
        }
        
        // We'll use a stack to store nodes to visit, pushing next first
        // followed by child, ensuring that we follow child chains before
        // next chains to flatten the list with child chains taking precedence.
        // We also need to keep track of nodes we've visited in the event of cycles.
        HashSet<Node> visited = new HashSet<Node>();
        Stack<Node> toVisit = new Stack<Node>();
        
        visited.Add(head);        
        
        if (head.next != null && !visited.Contains(head.next)) {
            visited.Add(head.next);
            toVisit.Push(head.next);
        }
        
        if (head.child != null && !visited.Contains(head.child)) {
            visited.Add(head.child);
            toVisit.Push(head.child);
        }
        
        Node prev = head;
        head.child = null;
        
        while (toVisit.Count > 0) {
            Node curr = toVisit.Pop();
            
            // Link curr to prev            
            prev.next = curr;
            curr.prev = prev;            
            
            // Visit children first and then next.
            Node child = curr.child;
            Node next = curr.next;
            
            if (next != null && !visited.Contains(next)) {
                visited.Add(next);
                toVisit.Push(next);
            }
            
            if (child != null && !visited.Contains(child)) {
                visited.Add(child);
                toVisit.Push(child);
            }
            
            // Don't forget to clear the child pointer.
            curr.child = null;            
            prev = curr;
        }
        
        return head;        
    }
}
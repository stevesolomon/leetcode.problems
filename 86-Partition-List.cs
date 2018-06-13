// https://leetcode.com/problems/partition-list/description/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode Partition(ListNode head, int x) {
        if (head == null || head.next == null) {
            return head;
        }
        
        ListNode lesserHead = null, greaterHead = null;
        ListNode lesserCurr = null, greaterCurr = null;
        
        ListNode curr = head;
        
        while (curr != null) {
            
            // Disconnect curr from the list.
            ListNode next = curr.next;
            curr.next = null;
            
            if (curr.val < x) {
                
                // If we haven't already set the head of our lesser list
                // do so and then move on to the next.
                if (lesserHead == null) {
                    lesserHead = curr;
                    lesserCurr = curr;
                } else {                
                    // Otherwise, append this node to the curr lesser list.                
                    lesserCurr.next = curr;
                    lesserCurr = curr;
                }
            } else {
                
                if (greaterHead == null) {
                    greaterHead = curr;
                    greaterCurr = curr;
                } else {                
                    greaterCurr.next = curr;
                    greaterCurr = curr;
                }
            }
            
            curr = next;
        }
        
        // If we didn't get any lesser values just return the greater head.
        if (lesserHead == null) {
            return greaterHead;
        }
        
        lesserCurr.next = greaterHead;
        
        return lesserHead;
    }
}
// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/546/week-3-july-15th-july-21st/3396/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode RemoveElements(ListNode head, int val) {
        if (head == null) {
            return head;
        }
        
        ListNode curr = head;
        ListNode prev = null;
        
        while (curr != null) {
            if (curr.val == val) {                
                // Head of list
                if (prev == null) {
                    head = curr.next;
                } else {
                    prev.next = curr.next;
                }
                
                curr = curr.next;
            } else {
                prev = curr;
                curr = curr.next;
            }
        }
        
        return head;        
    }
}
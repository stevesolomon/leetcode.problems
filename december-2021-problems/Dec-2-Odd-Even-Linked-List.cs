// https://leetcode.com/problems/odd-even-linked-list/

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
    public ListNode OddEvenList(ListNode head) {
        if (head == null || head.next == null) {
            return head;
        }
        
        ListNode oddListCurr = head;
        ListNode evenListCurr = head.next;
        ListNode evenListHead = head.next;
        
        while (oddListCurr.next != null && evenListCurr.next != null) {
            oddListCurr.next = evenListCurr.next;
            evenListCurr.next = oddListCurr.next.next;
            
            oddListCurr = oddListCurr.next;
            evenListCurr = evenListCurr.next;
        }
        
        oddListCurr.next = evenListHead;
        
        return head;        
    }
}
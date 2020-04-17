// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/529/week-2/3290/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode MiddleNode(ListNode head) {
        if (head == null || head.next == null) {
            return head;
        }
        
        // Move two pointers at a time. One that moves at twice the
        // speed of the other. When the one moving at twice the speed
        // has reached the end, the other pointer points to the middle node.
        ListNode slow = head;
        ListNode fast = head;
        
        while (fast != null && fast.next != null) {
            slow = slow.next;            
            fast = fast.next.next;
        }
        
        return slow;
    }
}
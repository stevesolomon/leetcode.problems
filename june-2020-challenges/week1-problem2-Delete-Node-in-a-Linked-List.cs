// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3348/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public void DeleteNode(ListNode node) {
        if (node == null) {
            return;
        }
        
        // Guaranteed not to be the tail so no worries here
        node.val = node.next.val;
        node.next = node.next.next;        
    }
}

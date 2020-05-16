// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/536/week-3-may-15th-may-21st/3331/

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
        
        // We'll go through both odd and even nodes in lockstep.
        // At each iteration, update odd's pointer first (as it's .next
        // relies on the next even's pointer) and then update even.
        ListNode currOdd = head;
        ListNode currEven = head.next;
        
        // We also need to keep track of the first even Node so we can attach
        // it to the tail of the odd list when we're all done.
        ListNode firstEven = head.next;
        
        while (currOdd.next != null && currEven != null && currEven.next != null) {
            currOdd.next = currOdd.next.next;
            
            // We can't let currOdd end up null as we need a valid reference
            // later on to connect the tail of odd with the head of even.
            if (currOdd.next != null) {
                currOdd = currOdd.next;
            }
            
            currEven.next = currEven.next.next;
            currEven = currEven.next;
        }
        
        // Any odds left to traverse?
        while (currOdd.next != null) {
            currOdd.next = currOdd.next.next;
            
            if (currOdd.next != null) {
                currOdd = currOdd.next;
            }
        }
        
        // Any evens left to traverse?
        while (currEven != null && currEven.next != null) {
            currEven.next = currEven.next.next;
            currEven = currEven.next;
        }
        
        // Attach the lists...
        currOdd.next = firstEven;
        
        return head;
    }
}
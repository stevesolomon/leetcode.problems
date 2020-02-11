// https://leetcode.com/problems/palindrome-linked-list/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public bool IsPalindrome(ListNode head) {
        if (head == null || head.next == null) {
            return true;
        }
        
        // To do this in O(n) time and O(1) space we will first determine the length
        // of the linked list.
        // Then, we'll reverse the list from n/2...n, and keep a pointer to the tail.
        // Finally we'll follow the pointers from head->tail and tail-> head until we've traversed n/2 elements in each direction.
        // (In the case of odd-size lists we want to traverse ceil(n/2) elements).
        int length = 0;
        ListNode curr = head;
        
        while (curr != null) {
            length++;
            curr = curr.next;
        }
        
        int halfLength = (int) Math.Ceiling((double) length / 2);
        
        // First iterate through the initial half of the list...
        curr = head;
        ListNode prev = null;
        for (int i = 0; i < halfLength; i++) {
            prev = curr;
            curr = curr.next;
        }
        
        // And from here reverse the list until we're done...
        while (curr != null) {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;            
        }
        
        // Prev points to the tail of the list
        ListNode tail = prev;
        curr = head;
        
        // Now iterate through halfLength elements from either side, ensuring the number is the same every time.
        for (int i = 0; i < halfLength; i++) {
            if (tail.val != curr.val) {
                return false;
            }
            
            tail = tail.next;
            curr = curr.next;
        }
        
        
        return true;
    }
}
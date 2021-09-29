// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/640/week-5-september-29th-september-30th/3992/

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
    public ListNode[] SplitListToParts(ListNode head, int k) {
        if (head == null) {
            return new ListNode[k];
        }
        
        // Base number in each list = k / head.Length
        // The first k % head.Length lists need to have an extra node.
        int listLength = GetListLength(head);
        int basePerList = listLength / k;
        int listsWithExtra = listLength % k;
        
        ListNode curr = head;
        ListNode next = curr.next;
        ListNode[] results = new ListNode[k];
        
        for (int listNum = 0; listNum < k; listNum++) {
            // No more items to add to the lists.
            if (curr == null) {
                break;
            }
            
            int totalForCurrList = basePerList;
            totalForCurrList += listNum < listsWithExtra ? 1 : 0;
            
            results[listNum] = curr;
            
            for (int i = 1; i < totalForCurrList; i++) {
                if (curr == null) {
                    break;
                }
                
                curr = next;
                next = next.next;
            }
            
            curr.next = null;
            curr = next;
            
            if (next != null) {
                next = next.next;
            }
        }
        
        return results;
    }
    
    private int GetListLength(ListNode head) {
        int length = 1;
        ListNode curr = head;
        
        while (curr.next != null) {
            curr = curr.next;
            length++;
        }
        
        return length;        
    }
}
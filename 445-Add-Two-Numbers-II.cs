// https://leetcode.com/problems/add-two-numbers-ii/description/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        
        if (l1 == null && l2 == null) {
            return null;
        } else if (l1 == null && l2 != null) {
            return l2;
        } else if (l1 != null && l2 == null) {
            return l1;
        }
        
        ListNode retHead;
        
        // First, get the lengths of both lists
        int l1Len = GetListLen(l1), 
            l2Len = GetListLen(l2);
        
        // Create a temp array the length of our longest list + 1 (to account for carry)
        int[] vals = new int[l1Len > l2Len ? l1Len + 1 : l2Len + 1];
        
        for (int i = 0; i < vals.Length; i++) {
            vals[i] = 0;
        }
        
        // Starting from index 1 in the array, as index 0 is our extra slot for additional carry
        // if we require it.
        int currIndex = 1;
        
        // Start with our longest list first and insert the values into the array
        int lenDiff = l1Len > l2Len ? l1Len - l2Len : l2Len - l1Len;
        ListNode l1Curr = l1, l2Curr = l2, tempCurr;
        
        if (l1Len > l2Len) {
            tempCurr = l1;
            
            for (int i = 0; i < lenDiff; i++) {
                l1Curr = l1Curr.next;
            }
        } else {
            tempCurr = l2;
            
            for (int i = 0; i < lenDiff; i++) {
                l2Curr = l2Curr.next;
            }
        }
        
        // Insert values from our longest list into the array.
        while (lenDiff > 0) {
            vals[currIndex] = tempCurr.val;
            tempCurr = tempCurr.next;
            currIndex++;
            lenDiff--;
        }
        
        // Now go through each list and add the values
        while (l1Curr != null && l2Curr != null) {
            int valueToAdd = l1Curr.val + l2Curr.val;
            
            AddToArrayWithCarry(vals, currIndex, valueToAdd);
            
            currIndex++;
            l1Curr = l1Curr.next;
            l2Curr = l2Curr.next;
        }        
        
        // Finally, build up our return list        
        return BuildListFromArray(vals);
    }
    
    private ListNode BuildListFromArray(int[] array) {
        
        // We start at index 0 in all situations except if array[0] is 0, as this
        // was our extra carry slot. If it's 0, we didn't use it.
        int startingIndex = array[0] == 0 ? 1 : 0;
        
        ListNode head = new ListNode(array[startingIndex]);                
        ListNode curr = head;
        
        for (int i = startingIndex + 1; i < array.Length; i++) {
            ListNode newNode = new ListNode(array[i]);
            curr.next = newNode;
            curr = newNode;
        }
        
        return head;
    }
    
    private void AddToArrayWithCarry(int[] array, int index, int valueToAdd) {
        
        while (index >= 0) {
            int newVal = array[index] += valueToAdd;
            
            // Simple case, no overflow, we're done.
            if (newVal < 10 || index == 0) {
                array[index] = newVal;
                break;
            }
            
            // Otherwise we have to carry at least once.
            newVal -= 10;
            array[index] = newVal;
            
            index--;
            valueToAdd = 1;
        }
    }
    
    private int GetListLen(ListNode list) {
        int length = 0;
        
        ListNode curr = list;
        
        while (curr != null) {
            curr = curr.next;
            length++;
        }
        
        return length;
    }
}
// https://leetcode.com/problems/merge-k-sorted-lists/

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
    public ListNode MergeKLists(ListNode[] lists) {
        
        // Add all elements across all linked lists to a MinHeap.
        MinHeap minHeap = new MinHeap();
        
        foreach (ListNode list in lists) {
            ListNode currNode = list;
            while (currNode != null) {
                minHeap.Add(currNode.val);
                currNode = currNode.next;
            }
        }
        
        // Now pop all elements out and create a new list to be returned.
        if (!minHeap.HasElements()) {
            return null;
        }
        
        ListNode head = new ListNode(minHeap.TakeMin());
        ListNode curr = head;
        
        while (minHeap.HasElements()) {
            curr.next = new ListNode(minHeap.TakeMin());
            curr = curr.next;
        }
        
        return head;
    }
}

public class MinHeap {
    private List<int> elements;
    
    public MinHeap() {
        elements = new List<int>();
    }
    
    public bool HasElements() {
        return elements.Count > 0;
    }
    
    public void Add(int val) {
        elements.Add(val);
        SiftUp();
    }
    
    public int TakeMin() {
        int min = elements[0];
        elements[0] = elements[elements.Count - 1];
        elements.RemoveAt(elements.Count - 1);
        
        SiftDown();
        
        return min;
    }
    
    private void SiftUp() {
        // Sift the last element up
        var currIdx = elements.Count - 1;
        
        while (currIdx > 0) {            
            // Are we smaller than our parent? Swap
            int parentIdx = (currIdx - 1) / 2;
            
            if (elements[currIdx] < elements[parentIdx]) {
                int temp = elements[currIdx];
                elements[currIdx] = elements[parentIdx];
                elements[parentIdx] = temp;
                currIdx = parentIdx;
            } else {
                break;
            }
        }
    }
    
    private void SiftDown() {
        // Sift the first element down.
        var currIdx = 0;
        var leftChildIdx = (currIdx * 2) + 1;
        var rightChildIdx = (currIdx * 2) + 2;
        
        while (leftChildIdx < elements.Count) {
            int smallerIdx = leftChildIdx;
            if (rightChildIdx < elements.Count && elements[rightChildIdx] < elements[leftChildIdx]) {
                smallerIdx = rightChildIdx;                
            }
            
            if (elements[smallerIdx] < elements[currIdx]) {
                // Swap
                int temp = elements[currIdx];
                elements[currIdx] = elements[smallerIdx];
                elements[smallerIdx] = temp;
                currIdx = smallerIdx;
            } else {
                break;
            }
            
            leftChildIdx = (currIdx * 2) + 1;
            rightChildIdx = (currIdx * 2) + 2;
        }
    }
    
}
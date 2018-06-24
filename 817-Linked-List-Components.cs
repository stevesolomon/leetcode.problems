// https://leetcode.com/problems/linked-list-components/description/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public int NumComponents(ListNode head, int[] G) {
        
        if (head == null || G == null || G.Length == 0) {
            return 0;
        }        
        
        HashSet<int> gVals = new HashSet<int>();
        
        foreach (int g in G) {
            gVals.Add(g);
        }
        
        ListNode curr = head;
        int numComponents = 0;
        bool buildingComponent = false;
        
        while (curr != null) {
            bool inG = gVals.Contains(curr.val);
            
            if (inG) {
                if (!buildingComponent) {
                    buildingComponent = true;
                }
            } else {
                if (buildingComponent) {
                    buildingComponent = false;
                    numComponents++;
                }
            }
            
            curr = curr.next;
        }
        
        return buildingComponent ? numComponents + 1 : numComponents;
    }
}
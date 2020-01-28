// https://leetcode.com/problems/verify-preorder-serialization-of-a-binary-tree/

public class Solution {
    
    private static int currElem;
    
    public bool IsValidSerialization(string preorder) {
        if (preorder == null || preorder.Length == 0) {
            return true;
        }
        
        string[] preorderSplit = preorder.Split(',');
        
        // A recursive solution involving:
        //   - A pointer to the element we are consuming
        //   - Each recursive step "consumes" the left child, then the right child.
        //   - If the current element is '#' we stop.
        //   - If we haven't stopped, but have run out of elements, the tree is invalid.
        //   - Because our base case of '#' stops us from checking further, we must also ensure
        //     that we consumed the entire string during our traversal.
        currElem = 0;        
        return IsValidRecursive(preorderSplit) && currElem == preorderSplit.Length - 1;
    }
    
    private bool IsValidRecursive(string[] preorder) {
        
        // Base cases: 
        if (currElem >= preorder.Length) {
            return false;
        }
        
        if (preorder[currElem] == "#") {
            return true;
        }
        
        // Otherwise consume left and right children
        currElem++;
        bool left = IsValidRecursive(preorder);
        currElem++;
        bool right = IsValidRecursive(preorder);
        
        return left && right;
    }
}
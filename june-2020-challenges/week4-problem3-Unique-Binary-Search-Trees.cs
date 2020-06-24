// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/542/week-4-june-22nd-june-28th/3370/

public class Solution {
    Dictionary<string, int> lookup = new Dictionary<string, int>();
    
    public int NumTrees(int n) {        
        return CountSubtrees(0, n);
    }
    
    private int CountSubtrees(int start, int end) {
        if (start >= end) {
            return 1;
        }
        
        string lookupKey = $"{start}_{end}";
        
        if (lookup.ContainsKey(lookupKey)) {
            return lookup[lookupKey];
        }
        
        int totalTrees = 0;
        
        // Count every possible subtree rooted with one of the values...
        for (int root = start; root < end; root++) {
            
            // Check how many different subtrees we have on the left and right side
            // of our choice of root.
            int leftTotal = CountSubtrees(start, root);
            int rightTotal = CountSubtrees(root + 1, end);
            
            totalTrees += leftTotal * rightTotal;
        }
        
        lookup.Add(lookupKey, totalTrees);
        
        return totalTrees;
    }
}
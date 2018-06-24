// https://leetcode.com/problems/binary-trees-with-factors/description/

public class Solution {
    
    private static int Modulo = (int) Math.Pow(10, 9) + 7;
    
    public int NumFactoredBinaryTrees(int[] A) {
        
        if (A == null || A.Length == 0) {
            return 0;
        } else if (A.Length == 1) {
            return 1;
        }
    
        // Sort the list so we can get counts of the trees
        // composed of the smallest numbers first.
        List<int> nums = A.ToList();
        nums.Sort();
        
        // Now, let's use a Dictionary that stores the number of
        // trees we are able to create. The key is the value of the root
        // and the value is the number of different trees we could create with
        // this root value.
        // Since we're starting with the smallest numbers first in our list, we're
        // guaranteed to start with trees that can only be built 1 way (single root)
        Dictionary<int, long> treeCounts = new Dictionary<int, long>();
        
        foreach (int num in nums) {
            long count = 1; // We can build at least one tree with this number.
            
            // In order to go beyond the root we need to be able to start both a
            // left and right subtree. To do that, the value of the left and right subtree
            // roots must be divisors of num. 
            // Let's start to scan the trees in our Dictionary looking for roots that form
            // a divisor.
            foreach (int key in treeCounts.Keys) {
                // If key is a divisor of num we also need to have num / key
                // as key * (num / key) == num, satisfying the rules.
                if (num % key == 0 && treeCounts.ContainsKey(num / key)) {
                    count += treeCounts[key] * treeCounts[num / key];
                }
            }
            
            if (!treeCounts.ContainsKey(num)) {
                treeCounts.Add(num, 0);
            }
            
            treeCounts[num] += count;
        }
        
        long totalCount = 0;
        
        foreach (int key in treeCounts.Keys) {
            totalCount += treeCounts[key];
        }
        
        return (int) (totalCount % Modulo);
    }
}
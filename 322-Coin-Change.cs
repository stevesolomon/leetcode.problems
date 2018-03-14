// https://leetcode.com/problems/coin-change/description/

public class Solution {
    
    // Hint value for terminating layers in our BFS.
    private const int LAYER_TERMINATOR = -1;
    
    public int CoinChange(int[] coins, int amount) {
        
        if (amount == 0) {
            return 0;
        }
        
        int layer = 1;
        
        // Stores the current nodes we've traversed in the problem space.
        // A node in the tree contains the current value of the coins along
        // the shortest path (ie: the fewest number of coins) needed to reach that value.
        Queue<int> bfs = new Queue<int>();
        
        // Stores the current nodes we've already visited in the problem space.
        // As a BFS of the problem space ensures the first time we visit a node that is the shortest
        // path, there is no need to revisit already visited nodes.
        HashSet<int> visited = new HashSet<int>();        
        
        bfs.Enqueue(0);
        bfs.Enqueue(LAYER_TERMINATOR);
        visited.Add(0);
        
        // We can stop immediately once we find the value.
        bool found = false;
        
        while (bfs.Count > 0 && !found) {
            
            int currVal = bfs.Dequeue();            
            
            // If this is our layer terminator, increment the layer and move to the next.
            if (currVal == LAYER_TERMINATOR) {
                layer++;
                
                // If we have additional elements, enqueue another LAYER_TERMINATOR
                if (bfs.Count > 0) {
                    bfs.Enqueue(LAYER_TERMINATOR);
                }
                
                continue;
            }            
            
            // Try adding each coin to this value if it keeps us under the amount.
            for (int i = 0; i < coins.Length; i++) {
                int newVal = currVal + coins[i];
                
                if (newVal < amount && !visited.Contains(newVal)) {
                    bfs.Enqueue(newVal);
                    visited.Add(newVal);
                } else if (newVal == amount) {
                    found = true;
                    break;
                }
            }            
        }
        
        return found ? layer : -1;
    }
}
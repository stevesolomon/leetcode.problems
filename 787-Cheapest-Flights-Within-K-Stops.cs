// https://leetcode.com/problems/cheapest-flights-within-k-stops/description/

public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K) {
        if (n <= 0 || flights == null || flights.Length == 0) {
            return -1;
        }
        
        // First build up our graph in a Dictionary structure.
        // Key = cityId, Value = a list of Tuples containing (destId, cost).
        Dictionary<int, List<Tuple<int, int>>> connections = new Dictionary<int, List<Tuple<int, int>>>();
        
        for (int i = 0; i < flights.Length; i++) {
            if (!connections.ContainsKey(flights[i][0])) {
                connections.Add(flights[i][0], new List<Tuple<int, int>>());
            }
            
            connections[flights[i][0]].Add(new Tuple<int, int>(flights[i][1], flights[i][2]));            
        }
        
        // Now perform a Breadth-First Traversal of the graph until we reach
        // the maximum number of layers (= stops) allowed.
        // Every time we hit the destination city record the current cost.
        // Our traversal queue stored a Tuple containing (currCityId, totalCost).
        int stops = 0;
        int bestCost = int.MaxValue;
        Queue<Tuple<int, int>> traversal = new Queue<Tuple<int, int>>();
        
        traversal.Enqueue(new Tuple<int, int>(src, 0));
        traversal.Enqueue(null); // Layer terminator.
        
        while (traversal.Count > 0 && stops <= K) {
            
            Tuple<int, int> currNode = traversal.Dequeue();
            
            if (currNode == null) {
                if (traversal.Count > 0) {
                    traversal.Enqueue(null);
                }
                
                stops++;
                continue;
            }
            
            // Add every city from this node to this queue. There are no-self cycles
            // so we don't have to worry about that.
            if (connections.ContainsKey(currNode.Item1)) {
                foreach (var connection in connections[currNode.Item1]) {
                    int cost = currNode.Item2 + connection.Item2;
                    
                    // If the connection leads us to our destination city
                    // we're done (no negative prices) with this particular
                    // branch of the traversal.
                    if (connection.Item1 == dst) {
                        bestCost = Math.Min(bestCost, cost);
                    } else {
                        // Add this new city to the traversal iff we're not above the best cost seen thus far.
                        if (cost < bestCost) {
                            traversal.Enqueue(new Tuple<int, int>(connection.Item1, currNode.Item2 + connection.Item2));
                        }
                    }
                }
            }
        }
        
        return bestCost == int.MaxValue ? -1 : bestCost;
    }
}
// https://leetcode.com/problems/bus-routes/submissions/
// Improved on my previous code to ensure that this fits within the time constraints.

public class Solution {
    public int NumBusesToDestination(int[][] routes, int S, int T) {
        if (routes == null || routes.Length == 0) {
            return -1;
        } else if (S == T) {
            return 0;
        }
        
        // First, build up a Dictionary of all the buses available at each stop.
        Dictionary<int, List<int>> stopListing = new Dictionary<int, List<int>>();
        
        for (int busId = 0; busId < routes.Length; busId++) {
            for (int j = 0; j < routes[busId].Length; j++) {
                int stop = routes[busId][j];
                
                if (!stopListing.ContainsKey(stop)) {
                    stopListing.Add(stop, new List<int>());
                }
                
                stopListing[stop].Add(busId);
            }
        }
        
        // Keep track of buses we've already been on so we don't ride them again.
        bool[] visitedBuses = new bool[routes.Length];
        HashSet<int> visitedStops = new HashSet<int>();
        
        // We start at stop S...
        // From there, we will try getting on any bus available at that stop, and, thus, getting
        // OFF at any stop that that bus stops at.
        int totalRides = 0;
        Queue<int> stopTraversal = new Queue<int>();
        stopTraversal.Enqueue(S);
        stopTraversal.Enqueue(-1); // -1 is our BFS layer terminator
        
        visitedStops.Add(S);
        
        while (stopTraversal.Count > 0) {
            int currStop = stopTraversal.Dequeue();
            
            if (currStop == T) {
                return totalRides;
            }
            
            if (currStop == -1) {
                totalRides++;
                
                if (stopTraversal.Count > 0) {
                    stopTraversal.Enqueue(-1);
                }
                continue;
            }
            
            foreach (var busId in stopListing[currStop]) {
                // For every bus possible at this stop that we haven't already been on...
                // Consider any of its stops as a possible move...
                if (visitedBuses[busId]) {
                    continue;
                }
                
                visitedBuses[busId] = true;
                
                foreach (var stopId in routes[busId]) {
                    if (!visitedStops.Contains(stopId)) {
                        stopTraversal.Enqueue(stopId);
                        visitedStops.Add(stopId);
                    }                    
                }
            }
        }
        
        return -1;
    }
}
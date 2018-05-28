// https://leetcode.com/problems/bus-routes/description/

public class Solution {
    public int NumBusesToDestination(int[][] routes, int S, int T) {
        
        if (routes == null || routes.Length == 0) {
            return -1;
        }
        
        if (S == T) {
            return 0;
        }
        
        // First let's get our routes into a data structure that lets 
        // us perform faster lookups on stops. 
        // We need to know a few things:
        //  (1) What stop numbers does a bus stop at?
        //  (2) Is a bus route connected to another by a stop?
        // To answer (1) we have the routes array.
        // To answer (2) we will store a dictionary of stop numbers with a HashSet of bus numbers.
        Dictionary<int, HashSet<int>> stopsToBus = BuildStopsToBus(routes);
        
        // Now, perform a BFS on the graph, starting at the stop S, until we hit the stop T.
        Queue<TraversalNode> traversal = new Queue<TraversalNode>();
        HashSet<int> visitedStops = new HashSet<int>(); // We can prune paths that have cycles.
        
        // We are starting at Stop S, and we can start at any bus that has a stop there.
        foreach (int busId in stopsToBus[S]) {
            traversal.Enqueue(new TraversalNode(S, busId, 1));
        }
        
        TraversalNode currStop = null;
        
        // Now, start our BFS search in the graph...
        // Each time we take a node, we should investigate a few things:
        //   (1) Is the stop what we want? If so we're done!
        //   (2) Where can we go from this stop?
        //       - For this we have to look at a few things...
        //         (a) stopsToBus will tell us every bus that stops at this stop.
        //         (b) From there, we can search each subarray in routes to find the next stop
        //         (c) And then Enqueue all these stops/buses up!
        //              !! Making sure to increase the NumBusesSoFar on the node if we switch a bus!
        while (traversal.Count > 0) {    
            
            currStop = traversal.Dequeue();
            
            // Check if this bus has the stop on its route. If so, we're done!
            int stopIdx = Array.BinarySearch(routes[currStop.BusId], T);

            if (stopIdx >= 0) {
                currStop.StopId = T;
                break;
            }
            
            visitedStops.Add(currStop.StopId);
            
            // Get every bus that stops at this stop
            HashSet<int> busesThatStopHere = stopsToBus[currStop.StopId];
            bool found = false;            
            
            // Add all of the stops that this bus can make to the Queue
            // except for this particular stop (and any we've already visited).  
            foreach (int busId in busesThatStopHere) {
                
                for (int i = 0; i < routes[busId].Length; i++) {
                    if (visitedStops.Contains(routes[busId][i])) {
                        continue;
                    }
                    
                    // Add this potential edge to the Queue.
                    TraversalNode newRide = new TraversalNode(
                        routes[busId][i],
                        busId,
                        busId == currStop.BusId ? currStop.NumBusesSoFar : currStop.NumBusesSoFar + 1);

                    traversal.Enqueue(newRide);
                }
            }
        }
        
        return (currStop != null && currStop.StopId == T) ? currStop.NumBusesSoFar : -1;
    }
    
    private Dictionary<int, HashSet<int>> BuildStopsToBus(int[][] routes) {
        Dictionary<int, HashSet<int>> stopsToBus = new Dictionary<int, HashSet<int>>();
     
        for (int i = 0; i < routes.Length; i++) {            
            for (int j = 0; j < routes[i].Length; j++) {
                
                // Add this bus to all of its stops
                if (!stopsToBus.ContainsKey(routes[i][j])) {
                    stopsToBus.Add(routes[i][j], new HashSet<int>());
                }
                
                stopsToBus[routes[i][j]].Add(i);
            }
        }
        
        return stopsToBus;
    }
}

public class TraversalNode {
    public int StopId { get; set; }
    
    public int BusId { get; private set; }
    
    public int NumBusesSoFar { get; private set;}
    
    public TraversalNode(int stopId, int busId, int numBusesSoFar) {
        this.StopId = stopId;
        this.BusId = busId;
        this.NumBusesSoFar = numBusesSoFar;
    }
}
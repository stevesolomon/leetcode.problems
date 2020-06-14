// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/540/week-2-june-8th-june-14th/3360/

public class Solution {
    
    public class FlightPath {
        public int TotalStops { get; set; }
        public int City { get; set; }
        public int TotalCost { get; set; }
        
        public FlightPath(int totalStops, int city, int totalCost) {
            this.TotalStops = totalStops;
            this.City = city;
            this.TotalCost = totalCost;
        }
    }
    
    public class FlightInfo {
        public int Cost { get; set; }
        public int Dest { get; set; }
        
        public FlightInfo(int cost, int dest) {
            this.Cost = cost;
            this.Dest = dest;
        }
    }
    
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K) {
        if (flights == null || flights.Length == 0) {
            return 0;
        }
        
        // We'll perform a breadth-first traversal of the graph starting at src.
        // Any time we reach dst we'll update the lowest price found thus far.
        // At each vertex we traverse we need to keep track of the total stops thus far.
        // We can prune any paths once the total stop count > K and we're not at dst.
        Queue<FlightPath> flightQueue = new Queue<FlightPath>();
        
        // Build up a Dictionary of flight paths for easier lookup
        Dictionary<int, List<FlightInfo>> flightPaths = new Dictionary<int, List<FlightInfo>>();
        Dictionary<int, int> visitedCities = new Dictionary<int, int>();
        
        foreach (int[] flight in flights) {
            int srcCity = flight[0];
            int destCity = flight[1];
            int cost = flight[2];
            
            if (!flightPaths.ContainsKey(srcCity)) {
                flightPaths.Add(srcCity, new List<FlightInfo>());
            }
            
            flightPaths[srcCity].Add(new FlightInfo(cost, destCity));
        }
        
        int bestPrice = int.MaxValue;
        flightQueue.Enqueue(new FlightPath(0, src, 0));
        visitedCities.Add(src, 0);
        
        while (flightQueue.Count > 0) {
            var currFlight = flightQueue.Dequeue();
            
            // Too many stops? We're done.
            if (currFlight.TotalStops > K) {
                continue;
            }
            
            // Search along all possible flights out of the current city.
            if (flightPaths.ContainsKey(currFlight.City)) {
                foreach (var flightPath in flightPaths[currFlight.City]) {
                    
                    int newCost = currFlight.TotalCost + flightPath.Cost;
                    
                    // Is this a flight to our destination? We have a potential solution.
                    if (flightPath.Dest == dst) {
                        bestPrice = Math.Min(bestPrice, newCost);
                        continue;
                    }
                    
                    // Otherwise queue up the new flight destination as long as we can have another stop.
                    if (currFlight.TotalStops < K) {
                        
                        // If we've visited this city previously with a lower price there's no
                        // reason to try visiting it again...
                        if (visitedCities.ContainsKey(flightPath.Dest) &&
                            visitedCities[flightPath.Dest] < currFlight.TotalCost + flightPath.Cost) {
                            continue;
                        }
                        
                        flightQueue.Enqueue(new FlightPath(
                            currFlight.TotalStops + 1,
                            flightPath.Dest,
                            currFlight.TotalCost + flightPath.Cost));
                        
                        if (!visitedCities.ContainsKey(flightPath.Dest)) {
                            visitedCities.Add(flightPath.Dest, 0);
                        }
                        
                        visitedCities[flightPath.Dest] = newCost;
                    }
                }
            }
        }
        
        return bestPrice == int.MaxValue ? -1 : bestPrice;
    }
}
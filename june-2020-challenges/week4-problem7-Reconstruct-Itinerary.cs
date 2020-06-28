// https://leetcode.com/explore/featured/card/june-leetcoding-challenge/542/week-4-june-22nd-june-28th/3374/

public class Solution {
    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        if (tickets == null || tickets.Count == 0) {
            return new List<string>();
        }
        
        // First convert our tickets into a Dictionary of source -> dests
        Dictionary<string, List<string>> ticketLookup = new Dictionary<string, List<string>>();
        
        foreach (var ticket in tickets) {
            if (!ticketLookup.ContainsKey(ticket[0])) {
                ticketLookup.Add(ticket[0], new List<string>());
            }
            
            ticketLookup[ticket[0]].Add(ticket[1]);
        }
        
        // And then sort our lists
        // We'll do this in reverse-order for more optimal removal later on.
        foreach (var kvp in ticketLookup) {
            ticketLookup[kvp.Key].Sort();
            ticketLookup[kvp.Key].Reverse();
        }
        
        // We have our destinations for each source in sorted order.
        // Let's do a DFS (always taking the optimal choice) and use
        // Hierholzer's algorithm to find the path.
        Stack<string> airport = new Stack<string>();
        airport.Push("JFK");
        
        List<string> optimalPath = new List<string>();
        
        while (airport.Count > 0) {
            string currAirport = airport.Peek();
            
            if (!ticketLookup.ContainsKey(currAirport) || ticketLookup[currAirport].Count == 0) {
                // We've exhausted all tours from this vertex. Add this airport to our solution.
                optimalPath.Add(currAirport);
                
                // And pop it from the stack now that we're done search from here.
                airport.Pop();
            } else {
                // We have more edges from this vertex, so we'll want to revisit it later.
                // For now, load up the last airport (reverse-sorted) and remove it from the tickets
                string dest = ticketLookup[currAirport].Last();
                ticketLookup[currAirport].RemoveAt(ticketLookup[currAirport].Count - 1);
                
                airport.Push(dest);
            }            
        }
        
        optimalPath.Reverse();
        return optimalPath;
    }
}
// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/537/week-4-may-22nd-may-28th/3342/
// Note this solution doesn't quite work in all cases

public class Solution {
    public bool PossibleBipartition(int N, int[][] dislikes) {
        if (N == 0) {
            return true;
        } else if (dislikes == null || dislikes.Length == 0) {
            return true;
        }
        
        // First we'll build up our graph data from the data in dislikes.
        // Each element in dislikes gives us an edge between two people.
        // From there, we need only perform a BFS from an arbitrary vertex/person
        // and see if we can color the graph such that we never attempt to recolor
        // a vertex with a different color.
        // Furthermore, since we're not guaranteed the graph is connected, we need
        // an additional modification: regardless of our coloring, if we have any disconnected
        // vertices it's likely we can still create a bipartite graph.
        Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();
        Dictionary<int, bool> colored = new Dictionary<int, bool>();
        
        foreach (int[] edge in dislikes) {
            int source = edge[0];
            int dest = edge[1];
            
            if (!edges.ContainsKey(source)) {
                edges.Add(source, new List<int>());
            }
            
            edges[source].Add(dest);
        }
        
        for (int i = 1; i <= N; i++) {
            
            // Seen this source vertex already? Continue on...
            if (colored.ContainsKey(i)) {
                continue;
            }
            
            // Otherwise color it and start visiting its edges.
            bool color = true;
            colored.Add(i, color);
            
            Queue<int> bfs = new Queue<int>();
            bfs.Enqueue(i);
            
            while (bfs.Count > 0) {
                int source = bfs.Dequeue();
                
                // No edges? Move on.
                if (!edges.ContainsKey(source)) {
                    continue;
                }
                
                foreach (var dest in edges[source]) {
                    
                    // Check if we have a coloring violation.
                    if (colored.ContainsKey(dest)) {
                        if (colored[dest] == colored[source]) {
                            return false;
                        }
                        
                        colored[dest] = !colored[source];
                        continue;
                    }
                    
                    colored.Add(dest, !colored[source]);
                    bfs.Enqueue(dest);
                }
            }
        }
        
        return true;
    }
}
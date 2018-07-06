// https://leetcode.com/problems/is-graph-bipartite/description/

public class Solution {
    private const int LayerTerminator = -1;
    
    private enum Colour {
        Uncoloured = 0,
        One,
        Two
    }
    
    public bool IsBipartite(int[][] graph) {
        if (graph == null || graph.Length == 0) {
            return true;
        }
        
        // This problem is essentially a vertex colouring problem
        // using two colours. Each edge must connect between vertices of
        // a different colour.
        Colour[] colours = new Colour[graph.Length];
        
        // How do we colour the vertices? Using a BFS, and if, during our traversal,
        // we try to traverse to a vertex we've already visited and it's the same
        // colour as our current vertex, we don't have a bipartite graph as this
        // has an odd cycle.        
        // Because we could have graphs with multiple strongly connected components
        // we really need to search from each vertex, but maintain our visited and colours
        // listing.
        for (int i = 0; i < graph.Length; i++) {
            if (colours[i] != Colour.Uncoloured) {
                continue;
            }
            
            if (!RunBFS(graph, colours, i)) {
                return false;
            }
        }
        
        return true;
    }
    
    private bool RunBFS(int[][] graph, Colour[] colours, int vertex) {
        Queue<int> traversal = new Queue<int>();
        traversal.Enqueue(vertex);
        traversal.Enqueue(LayerTerminator);
        
        Colour colour = Colour.One;
        
        while (traversal.Count > 0) {
            
            int currVertex = traversal.Dequeue();
            
            if (currVertex == LayerTerminator) {
                if (traversal.Count > 0) {
                    traversal.Enqueue(LayerTerminator);
                }
                
                colour = colour == Colour.One ? Colour.Two : Colour.One;
                continue;
            }
            
            colours[currVertex] = colour;
            
            foreach (int destVertex in graph[currVertex]) {
                
                if (colours[currVertex] == colours[destVertex]) {
                    // Then our graph has an odd cycle and cannot be bipartite.
                    return false;
                }
                
                if (colours[destVertex] == Colour.Uncoloured) {                
                    traversal.Enqueue(destVertex);
                }
            }            
        }
        
        return true;
    }
}
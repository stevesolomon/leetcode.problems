// https://leetcode.com/problems/minimum-height-trees/description/

public class Solution {
    
    public IList<int> FindMinHeightTrees(int n, int[,] edges) {
        
        List<int> result = new List<int>();
        
        if (edges == null) {
            return result;
        } else if (n == 1 && edges.GetLength(0) == 0) {
            result.Add(0);
            return result;
        }
        
        // First, let's build up a lookup table of adjacent vertices
        Dictionary<int, List<int>> adjacentVertices = BuildAdjacentVertices(edges);
        
        // Now, in our tree-life graph, we can really only have 1 or 2 vertices that form
        // a minimum height tree. 
        // Why?
        //    In the case where we have only 1 vertex, this vertex sits in the "middle"
        //    of the graph. It's possible we could have 2 vertices that sit in the "middle"
        //    if one "direction" of the tree's length is odd, and the other even.
        //    We cannot have 3, as at least one of the other 2 vertices must be visited
        //    during the traversal and, thus, at least one of the other 2 must form a shorter path.
        //    Put another way, if we had 3 vertices as potential candidates for the MHT, at least one
        //    of them MUST be a non-leaf node, while the other two ARE leaf nodes, violating the ability
        //    for that third one to form a MHT.
        // Obviously leaves cannot form a MHT so we will cull them from the list of vertices. 
        // The list of leaves grows as we cull vertices.
        // We stop when we only have 1 or 2 vertices left.
        while (adjacentVertices.Count > 2) {
            List<int> currLeaves = GetLeaves(adjacentVertices);
            
            // Remove these leaves from the list.
            foreach (int leaf in currLeaves) {
                // Remove the incoming edge from the "parent" first.
                adjacentVertices[adjacentVertices[leaf][0]].Remove(leaf);
                
                // And then this vertex wholesale.
                adjacentVertices.Remove(leaf);
            }
        }
        
        foreach (var key in adjacentVertices.Keys) {
            result.Add(key);
        }
        
        return result;        
    }
    
    private List<int> GetLeaves(Dictionary<int, List<int>> adjacentVertices) {
        List<int> leaves = new List<int>();
        
        foreach (var key in adjacentVertices.Keys) {
            if (adjacentVertices[key].Count == 1) {
                leaves.Add(key);
            }
        }
        
        return leaves;
    }
    
    private Dictionary<int, List<int>> BuildAdjacentVertices(int[,] edges) {
        Dictionary<int, List<int>> adjacentVertices = new Dictionary<int, List<int>>();
        
        for (int i = 0; i < edges.GetLength(0); i++) {
            int v1 = edges[i,0];
            int v2 = edges[i,1];
            
            if (!adjacentVertices.ContainsKey(v1)) {
                adjacentVertices.Add(v1, new List<int>());
            }
            
            if (!adjacentVertices.ContainsKey(v2)) {
                adjacentVertices.Add(v2, new List<int>());
            }
            
            adjacentVertices[v1].Add(v2);
            adjacentVertices[v2].Add(v1);
        }
        
        return adjacentVertices;
    }
}
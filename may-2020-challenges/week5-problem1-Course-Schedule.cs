// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/538/week-5-may-29th-may-31st/3344/

public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        if (numCourses < 2) {
            return true;
        } else if (prerequisites == null || prerequisites.Length == 0) {
            return true;
        }
        
        // We could have a number of disconnected graphs (as many courses may not
        // have any common pre-requisites).
        // What we want to do is detect cycles in the graph. If we find a cycle,
        // we know we cannot finish the courses, as there's a circular
        // dependency in pre-reqs.
        
        // First let's just generate our graph in a dictionary
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        
        foreach (int[] prereq in prerequisites) {
            if (!graph.ContainsKey(prereq[0])) {
                graph.Add(prereq[0], new List<int>());
            }
            
            graph[prereq[0]].Add(prereq[1]);
        }
        
        // Keep track of vertices we've visited period. This will be used to short-circuit
        // our search as we "root" at each vertex (no need to search from that root
        // if we've already traversed it from a previous root).
        HashSet<int> visited = new HashSet<int>();
        
        // Note that we need to visit every vertex once, so we loop through all possible vertices
        // as our "root". Because courses can share pre-reqs, we can't maintain this list of visited
        // vertices at a global level, but only once we've started exploring a root.
        for (int i = 0; i < numCourses; i++) {
            
            if (visited.Contains(i)) {
                continue;
            }
            
            // Do a DFS from this vertex and keep track of vertices we've seen through 
            // this current layer of recursion.
            // We have a cycle if we see the same vertex again deeper in our recursive calls.
            HashSet<int> rec = new HashSet<int>();
            
            if (!DFS(i, graph, visited, rec)) {
                return false;
            }            
        }
        
        return true;        
    }
    
    private bool DFS(int root, Dictionary<int, List<int>> graph, HashSet<int> visited, HashSet<int> rec) {
        visited.Add(root);
        rec.Add(root);
        
        bool retVal = true;
        
        if (graph.ContainsKey(root)) {
            foreach (var dest in graph[root]) {
                
                // Have we already seen this vertex in an earlier layer of recursion?
                // If so, then we have a cycle!
                if (rec.Contains(dest)) {
                    return false;
                }
                
                // No? Have we visited it before at least? (we can exit early if we have)
                if (visited.Contains(dest)) {
                    continue;
                }
                
                // Otherwise keep searching...
                retVal &= DFS(dest, graph, visited, rec);
            }
        }
        
        rec.Remove(root);
        
        return retVal;
    }
}
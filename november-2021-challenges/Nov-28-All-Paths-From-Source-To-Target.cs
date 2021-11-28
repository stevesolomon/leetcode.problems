// https://leetcode.com/problems/all-paths-from-source-to-target/

public class Solution {
    public  class TraversalNode {
        public int Source { get; set; }
        public List<int> Path { get; set; }
    }
    
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        if (graph == null) {
            return null;
        }
        
        List<IList<int>> results = new List<IList<int>>();
        
        // We'll perform a Breadth-First Traversal of the graph.
        // We do not need to keep track of vertices we've already visited as:
        //   (1) The graph is a DAG.
        //   (2) We want to discover all paths, not just the shortest path.
        // We will need to keep track of the current path taken for every traversal.
        
        Queue<TraversalNode> traversalQueue = new Queue<TraversalNode>();
        traversalQueue.Enqueue(new TraversalNode { Source = 0, Path = new List<int>() });
        
        while (traversalQueue.Count > 0) {
            var curr = traversalQueue.Dequeue();
            
            // Is our curr vertex the target? Add this list to the results.
            if (curr.Source == graph.Length - 1) {
                curr.Path.Add(curr.Source);
                results.Add(curr.Path);
                continue;
            }
            
            // Otherwise, from this vertex, enqueue every other vertex we can travel to.
            foreach (int dest in graph[curr.Source]) {
                List<int> traversalList = new List<int>(curr.Path);
                traversalList.Add(curr.Source);
                
                traversalQueue.Enqueue(new TraversalNode { Source = dest, Path = traversalList });
            }
        }
        
        return results;        
    }
}
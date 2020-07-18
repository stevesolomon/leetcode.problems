// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge/546/week-3-july-15th-july-21st/3394/

public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        if (numCourses == 0 || prerequisites == null) {
            return new int[0];
        }
        
        if (prerequisites.Length == 0) {
            int[] res = new int[numCourses]; 
            
            for (int i = 0; i < numCourses; i++) {
                res[i] = i;
            }
            
            return res;
        }
        
        // Build up a mapping of prereqs
        // We'll use this as we traverse the graph.
        Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();
        Dictionary<int, List<int>> reverseEdges = new Dictionary<int, List<int>>();
        
        // We also need to keep track of all vertices with no incoming edges.
        // In this case, incoming edges would be course pre-reqs for this vertex/course.
        List<int> outgoingVertices = new List<int>();
        List<int> results = new List<int>();
        
        for (int i = 0; i < numCourses; i++) {
            outgoingVertices.Add(i);
        }
        
        foreach (var prereq in prerequisites) {
            if (!edges.ContainsKey(prereq[1])) {
                edges.Add(prereq[1], new List<int>());
            }
            
            if (!reverseEdges.ContainsKey(prereq[0])) {
                reverseEdges.Add(prereq[0], new List<int>());
                
                // prereq[0] now requires at least one course (prereq[1])
                // So it has at least one incoming edge. Remove it from the list
                outgoingVertices.Remove(prereq[0]);
            }
            
            edges[prereq[1]].Add(prereq[0]);
            reverseEdges[prereq[0]].Add(prereq[1]);
        }
        
        // Perform a topological sort.
        while (outgoingVertices.Count > 0) {
            int course = outgoingVertices[outgoingVertices.Count - 1];
            outgoingVertices.RemoveAt(outgoingVertices.Count - 1);
            
            // Add this course as it does not require any further courses.
            results.Add(course);
            
            // Traverse all courses that require this course
            if (edges.ContainsKey(course)) {
                foreach (var nextCourse in edges[course]) {
                    // Remove edge from reverse lookup
                    reverseEdges[nextCourse].Remove(course);
                    
                    // Any incoming edges remaining in the next course?
                    if (reverseEdges[nextCourse].Count == 0) {
                        // No? Then add this as a new outgoing-only vertex
                        outgoingVertices.Add(nextCourse);
                        reverseEdges.Remove(nextCourse);
                    }                    
                }
            }
        }
        
        if (results.Count < numCourses) {
            return new int[0];
        }
        
        return results.ToArray();
    }
}
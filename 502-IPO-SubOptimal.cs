// https://leetcode.com/problems/ipo/description/
// Suboptimal solution making use of LINQ for sorting Lists.
// Can be improved with heaps or, perhaps, the SortedList class.

public class Solution {
    public int FindMaximizedCapital(int k, int W, int[] Profits, int[] Capital) {
        if (k == 0 
            || Profits == null || Capital == null 
            || Profits.Length == 0 || Capital.Length == 0
            || Profits.Length != Capital.Length) {
            return 0;
        }
        
        // For our tuples, Item1 = Capital, Item2 = Profits
        List<Tuple<int, int>> projects = new List<Tuple<int, int>>(Profits.Length);
        
        // First, push our Profits and Capital into a list sorted by Capital (asc)
        for (int i = 0; i < Profits.Length; i++) {
            Tuple<int, int> project = new Tuple<int, int>(Capital[i], Profits[i]);
            projects.Add(project);
        }
        
        // Order the projects by Capital.
        // Yes, we should probably use a minheap here.
        projects = projects.OrderBy(item => item.Item1).ToList();
        
        // Now start choosing projects.
        for (int projectNum = 0; projectNum < k; projectNum++) {
            // Extract every project that we can take from the projects list
            // and add it to a new list of candidate projects.
            List<Tuple<int, int>> candProjects = new List<Tuple<int, int>>();
            
            for (int i = 0; i < projects.Count; i++) {
                // Projects are sorted by Capital (asc order).
                if (projects[i].Item1 > W) {
                    break;
                }
                
                candProjects.Add(projects[i]);
            }
            
            // If we didn't get any candidate projects we're done.
            if (candProjects.Count == 0) {
                break;
            }
            
            // Sort our candidate projects by Profits (desc order)
            // Again, we should probably use a maxheap here.
            candProjects = candProjects.OrderByDescending(item => item.Item2).ToList();
            
            // And then just take the first one!
            Tuple<int, int> bestProject = candProjects[0];
            
            projects.Remove(bestProject);
            
            W += bestProject.Item2;           
        }
        
        return W;
    }
}
// https://leetcode.com/problems/sum-of-distances-in-tree/description/

public class Solution {
    public int[] SumOfDistancesInTree(int N, int[][] edges) {
        
        if (edges == null) {
            return new int[0];
        }
        
        if (N == 1 || edges.GetLength(0) == 0) {
            return new int[] { 0 };
        }
        
        int[] totalDistances = new int[N];
        int[] subtreeNodeCounts = new int[N];
        bool[] visitedNodes = new bool[N];
        
        // Build up our tree in a Dictionary
        Dictionary<int, List<int>> tree = GenerateTreeLookup(edges);
        
        GetRootSubtreeDistanceAndNodeCounts(0, tree, totalDistances, subtreeNodeCounts, visitedNodes);
        
        visitedNodes = new bool[N];
        
        GetAllNodeDistances(0, tree, totalDistances, subtreeNodeCounts, visitedNodes);
        
        return totalDistances;
    }
    
    private void GetRootSubtreeDistanceAndNodeCounts(
        int root,
        Dictionary<int, List<int>> tree, 
        int[] totalDistances,
        int[] subtreeNodeCounts,
        bool[] visitedNodes) {
        
        visitedNodes[root] = true;
        
        for (int i = 0; i < tree[root].Count; i++) {
            int nodeIdx = tree[root][i];
            
            if (visitedNodes[nodeIdx]) {
                continue;
            }
            
            // Working our way from the bottom-up, we'll compute the
            // counts of each subtree, and the total distances for each subtree.
            // (inevitably this will give us the correct total distance for the 
            //  original root we started at, as it forms a subtree for the entire tree)
            GetRootSubtreeDistanceAndNodeCounts(nodeIdx, tree, totalDistances, subtreeNodeCounts, visitedNodes);
            
            // Now update the values for the root based on each of its children's subtrees
            // The total distances of this root must have the child subtree's node counts,
            // plus its total distances to all of its children. We add the subtree's node counts
            // in particular because we are one greater step away from every node in that child's subtree.
            totalDistances[root] += totalDistances[nodeIdx] + subtreeNodeCounts[nodeIdx];
            subtreeNodeCounts[root] += subtreeNodeCounts[nodeIdx];
        }
        
        // We have at least one node in this subtree rooted by this root - ourselves!
        subtreeNodeCounts[root]++;
    }
    
    private void GetAllNodeDistances(
        int root,
        Dictionary<int, List<int>> tree,
        int[] totalDistances,
        int[] subtreeNodeCounts,
        bool[] visitedNodes) {
        
        visitedNodes[root] = true;
        
        int N = totalDistances.Length;
        
        for (int i = 0; i < tree[root].Count; i++) {
            int nodeIdx = tree[root][i];
            
            if (visitedNodes[nodeIdx]) {
                continue;
            }
            
            // Now, at every child, our totalDistance is expressed in the form:
            //  dist[child] = dist[root] - count[child] + (N - count[child])
            // Why?
            //   We start with the total distances from this child's parent (root).
            //   Clearly, We are one step closer to each of the nodes in this child's subtree, therefore
            //   we subtract the number of nodes in this child node's subtree.
            //   Then, we are clearly one step FURTHER from each of the nodes NOT in this subtree
            //   as we would otherwise have to go through the root to get to them. So we add
            //   those in (the total count of which is N - count[child]).
            // We work our way down to the leaves in this fashion, as we start with the real root of
            // the tree having the correct number based on our original traversal.
            totalDistances[nodeIdx] = totalDistances[root] - subtreeNodeCounts[nodeIdx] + (N - subtreeNodeCounts[nodeIdx]);
            GetAllNodeDistances(nodeIdx, tree, totalDistances, subtreeNodeCounts, visitedNodes);
        }
    }
        
    private Dictionary<int, List<int>> GenerateTreeLookup(int[][] edges) {
        
        Dictionary<int, List<int>> tree = new Dictionary<int, List<int>>();
        
        for (int i = 0; i < edges.GetLength(0); i++) {
            int node1 = edges[i][0];
            int node2 = edges[i][1];
            
            if (!tree.ContainsKey(node1)) {
                tree.Add(node1, new List<int>());
            }
            
            if (!tree.ContainsKey(node2)) {
                tree.Add(node2, new List<int>());
            }
            
            tree[node1].Add(node2);
            tree[node2].Add(node1);
        }
        
        return tree;
    }
}
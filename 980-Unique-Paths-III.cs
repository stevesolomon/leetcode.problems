// https://leetcode.com/problems/unique-paths-iii/

public class Solution {
    public int UniquePathsIII(int[][] grid) {
        if (grid == null || grid.Length == 0) {
            return 0;
        }
        
        if (grid.Length == 1 && grid[0].Length == 1) {
            return 0;
        }
        
        // Figure out how many 0 squares we actually have, as a valid path will need to visit all of them
        // before visiting the '2' node.
        // Also figure out the index of the starting square.
        int totalSquares = 1; // We 'visit' the '1' square first
        Tuple<int, int> startIdx = null;
        
        for (int x = 0; x < grid.Length; x++) {
            for (int y = 0; y < grid[x].Length; y++) {
                if (grid[x][y] == 0) {
                    totalSquares++;
                } else if (grid[x][y] == 1) {
                    startIdx = new Tuple<int, int>(x, y);
                }                
            }
        }        
        
        Stack<Node> traversal = new Stack<Node>();
        traversal.Push(new Node(startIdx, new HashSet<int>()));
        
        int numRoutes = 0;
        
        // As long as we have new nodes to traverse, keep searching for routes.
        while (traversal.Count > 0) {
            Node currNode = traversal.Pop();
            int x = currNode.index.Item1;
            int y = currNode.index.Item2;
            
            // When we visit a node we need to a few things:
            //   (1) Is this node a '2' square? If so:
            //      (a) If we've visited all the squares we need to visit, we've got a route.
            //      (b) Otherwise this is an invalid route and we can ignore it entirely.
            if (grid[x][y] == 2) {
                if (currNode.visited.Count == totalSquares) {
                    numRoutes++;
                }
                continue;
            }
            
            //   (2) Consider all other routes from this square.
            //      (a) Ignore adjacent indices that we've already visited, or are '-1' squares.
            //      (b) Push new nodes onto the stack for each new item we can visit. Update the visited Hash accordingly as well.
            if (x + 1 < grid.Length && grid[x + 1][y] != -1 && !currNode.visited.Contains(this.GenerateVisitedKey(x + 1, y))) {
                this.PushNode(traversal, x, y, x + 1, y, currNode);
            }
            
            if (x - 1 >= 0 && grid[x - 1][y] != -1 && !currNode.visited.Contains(this.GenerateVisitedKey(x - 1, y))) {
                this.PushNode(traversal, x, y, x - 1, y, currNode);
            }
            
            if (y + 1 < grid[x].Length && grid[x][y + 1] != -1 && !currNode.visited.Contains(this.GenerateVisitedKey(x, y + 1))) {
                this.PushNode(traversal, x, y, x, y + 1, currNode);
            }
            
            if (y - 1 >= 0 && grid[x][y - 1] != -1 && !currNode.visited.Contains(this.GenerateVisitedKey(x, y - 1))) {
                this.PushNode(traversal, x, y, x, y - 1, currNode);
            }
        }
        
        
        return numRoutes;
    }
    
    private int GenerateVisitedKey(int x, int y) {
        return x * 10 + y;
    }
    
    private void PushNode(Stack<Node> traversal, int x, int y, int newX, int newY, Node currNode)
    {
        HashSet<int> newVisited = new HashSet<int>(currNode.visited);
        newVisited.Add(this.GenerateVisitedKey(x, y));
        traversal.Push(new Node(new Tuple<int, int>(newX, newY), newVisited));
    }
}

public class Node {
    public Tuple<int, int> index;
    
    public HashSet<int> visited;
    
    public Node(Tuple<int, int> index, HashSet<int> visited) {
        this.index = index;
        this.visited = visited;
    }
}
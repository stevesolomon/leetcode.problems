// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3326/

public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
        if (image == null || image.Length == 0 || image.Length < sr || image[sr].Length < sc) {
            return image;
        }
        
        // We'll use a stack plus a HashSet encoding [row,col] elements we've already
        // visited to perform the flood fill.
        // The hashset stores a constructed string to guarantee uniqueness.
        Stack<Tuple<int, int>> fillStack = new Stack<Tuple<int, int>>();
        HashSet<string> visited = new HashSet<string>();
        
        int sourceColour = image[sr][sc];
        fillStack.Push(new Tuple<int, int>(sr, sc));
        visited.Add(ComputeCoordHash(sr, sc));
        
        while (fillStack.Count > 0) {
            var coord = fillStack.Pop();
            
            var row = coord.Item1;
            var col = coord.Item2;
            
            image[row][col] = newColor;
            
            // Add the four directions around us if they match the criteria...
            // We store into visited now, rather than when we actually visit
            // as a mini-optimization (otherwise we could technically load
            // up the same cell multiple times before we ever visit it once).
            if (row + 1 < image.Length && 
                image[row + 1][col] == sourceColour &&
                !visited.Contains(ComputeCoordHash(row + 1, col))) {
                fillStack.Push(new Tuple<int, int>(row + 1, col));
                visited.Add(ComputeCoordHash(row + 1, col));
            }
            
            if (row - 1 >= 0 && 
                image[row - 1][col] == sourceColour &&
                !visited.Contains(ComputeCoordHash(row - 1, col))) {
                fillStack.Push(new Tuple<int, int>(row - 1, col));
                visited.Add(ComputeCoordHash(row - 1, col));
            }
            
            if (col + 1 < image[row].Length &&
                image[row][col + 1] == sourceColour &&
                !visited.Contains(ComputeCoordHash(row, col + 1))) {
                fillStack.Push(new Tuple<int, int>(row, col + 1));
                visited.Add(ComputeCoordHash(row, col + 1));
            }
            
            if (col - 1 >= 0 &&
                image[row][col - 1] == sourceColour &&
                !visited.Contains(ComputeCoordHash(row, col - 1))) {
                fillStack.Push(new Tuple<int, int>(row, col - 1));
                visited.Add(ComputeCoordHash(row, col - 1));
            }
        }
        
        return image;            
    }
    
    private string ComputeCoordHash(int row, int col) {
        return $"{row}_{col}";
    }
}
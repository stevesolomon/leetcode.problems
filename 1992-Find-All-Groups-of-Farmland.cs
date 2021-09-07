// https://leetcode.com/problems/find-all-groups-of-farmland/

public class Solution {
    
    private const int FARMLAND = 1;
    private const int EMPTY = 0;
    
    public int[][] FindFarmland(int[][] land) {
        if (land == null || land.Length == 0) {
            return new int[0][];
        }
        
        List<int[]> results = new List<int[]>();
        
        // Scan for our farmland
        for (int row = 0; row < land.Length; row++) {
            for (int col = 0; col < land[row].Length; col++) {
                if (land[row][col] == FARMLAND) {
                    ScanFarmland(land, row, col, results);
                }
            }
        }
        
        return results.ToArray();
    }
    
    private void ScanFarmland(int[][] land, int startRow, int startCol, List<int[]> results) {
        int endRow = startRow;
        int endCol = startCol;
        
        // Traverse all connected FARMLAND tiles, updating them to zeroes as we go.
        // As we're working with rectangular land, we can keep updating endRow and endCol
        // with the greatest values observed thus far.
        Stack<Tuple<int, int>> traversal = new Stack<Tuple<int, int>>();
        traversal.Push(new Tuple<int, int>(startRow, startCol));
        
        while (traversal.Count > 0) {
            Tuple<int, int> coords = traversal.Pop();
            int row = coords.Item1;
            int col = coords.Item2;
            
            // Find all connected FARMLAND and add it to the traversal.
            // As we're working with rectangular land we only need to consider 
            // areas to the right, or down.
            if (row < land.Length - 1 && land[row + 1][col] == FARMLAND) {
                traversal.Push(new Tuple<int, int>(row + 1, col));
            }
            
            if (col < land[row].Length - 1 && land[row][col + 1] == FARMLAND) {
                traversal.Push(new Tuple<int, int>(row, col + 1));
            }
            
            // Finally reset our current land and update our end row/col values.
            land[row][col] = EMPTY;
            endRow = Math.Max(endRow, row);
            endCol = Math.Max(endCol, col);
        }
        
        results.Add(new int[4] { startRow, startCol, endRow, endCol });
    }
}
// https://leetcode.com/problems/perfect-rectangle/

public class Solution {
    public bool IsRectangleCover(int[][] rectangles) {
        // As we scan rectangles, we'll add their corners (x,y coords for each corner) to a set.
        // If we find a duplicate corner in a set, we will remove the corner entry entirely, as that
        // implies that two rectangles share that corner.
        // If all rectangles form a perfect rectangle, we should end up with 4 unique corners only.
        // What about overlap? To cover that, we'll need to calculate the area of all rectangles we observed,
        // and then compare that to the area of the supposed perfect rectangle's 4-unique corners.        
        
        // First off, how do we store (x,y) coords in a data structure we can look up/remove from?
        // Tuples<..> are looked up by value, not reference, so we'll use that.
        HashSet<Tuple<int, int>> corners = new HashSet<Tuple<int, int>>();
        long area = 0;
        
        foreach (int[] rectangle in rectangles) {
            int left = rectangle[0];
            int bottom = rectangle[1];
            int right = rectangle[2];
            int top = rectangle[3];
            
            Tuple<int, int> bottomLeft = new Tuple<int, int>(left, bottom);
            Tuple<int, int> bottomRight = new Tuple<int, int>(right, bottom);
            Tuple<int, int> topLeft = new Tuple<int, int>(left, top);
            Tuple<int, int> topRight = new Tuple<int, int>(right, top);
            
            if (corners.Contains(bottomLeft)) {
                corners.Remove(bottomLeft);
            } else {
                corners.Add(bottomLeft);
            }
            
            if (corners.Contains(bottomRight)) {
                corners.Remove(bottomRight);
            } else {
                corners.Add(bottomRight);
            }
            
            if (corners.Contains(topLeft)) {
                corners.Remove(topLeft);
            } else {
                corners.Add(topLeft);
            }
            
            if (corners.Contains(topRight)) {
                corners.Remove(topRight);
            } else {
                corners.Add(topRight);
            }
            
            area += (right - left) * (top - bottom);
        }
        
        if (corners.Count != 4) {
            return false;
        }
        
        // Otherwise, now check the area and make sure it matches up.
        int minX = int.MaxValue;
        int maxX = int.MinValue;
        int minY = int.MaxValue;
        int maxY = int.MinValue;
        
        foreach (var corner in corners) {
            minX = Math.Min(minX, corner.Item1);
            maxX = Math.Max(maxX, corner.Item1);
            minY = Math.Min(minY, corner.Item2);
            maxY = Math.Max(maxY, corner.Item2);
        }
        
        int expectedArea = (maxX - minX) * (maxY - minY);
        
        return expectedArea == area;
    }
}
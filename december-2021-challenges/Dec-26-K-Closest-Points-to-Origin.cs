// https://leetcode.com/problems/k-closest-points-to-origin/

public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        // We'll store the points in a max heap of max size k
        // When we run out space in the max heap and need to add another
        // we'll remove the top (max) element.
        // The minimum values are defined by
        // the Euclidean distance to the origin.
        
        var maxHeap = new MaxHeap(k);
        
        foreach (var point in points) {
            maxHeap.Add(point);
        }
        
        List<int[]> results = new List<int[]>();
        
        while (maxHeap.Count > 0) {
            results.Add(maxHeap.RemoveMax());
        }
        
        return results.ToArray();
    }
}

public class MaxHeap {
    
    private int maxSize;
    
    private List<Tuple<double, int[]>> elements;
    
    public int Count => elements.Count;
    
    public MaxHeap(int maxSize) {
        this.maxSize = maxSize;
        this.elements = new List<Tuple<double, int[]>>();
    }
    
    public int[] RemoveMax() {
        if (this.elements.Count == 0) {
            return null;
        }
        
        // Remove the first element, replace it with the last
        // element, and then sift down
        int[] val = this.elements[0].Item2;
        this.elements[0] = this.elements[this.elements.Count - 1];
        this.elements.RemoveAt(this.elements.Count - 1);
        
        this.SiftDown(0);
        
        return val;
    }
    
    public void Add(int[] point) {
        // Calculate Euclidean distance
        double xSq = point[0] * point[0];
        double ySq = point[1] * point[1];
        
        double distance = xSq + ySq;
        
        // If we're at our max size we have to make a decision here...
        // Our max heap is full and of size k. This implies that there are, currently,
        // k - 1 elements in the heap smaller than the max value in the heap (elem[0]).
        // If the incoming value is LOWER than the max value, we can safely remove
        // the max value and replace it with this incoming value (and then sift down).
        if (elements.Count == maxSize) {
            if (distance < this.elements[0].Item1) {
                this.elements[0] = new Tuple<double, int[]>(distance, point);
                this.SiftDown(0);
            }
            return;
        }
        
        // Otherwise, we just add to the next available element and sift up
        this.elements.Add(new Tuple<double, int[]>(distance, point));
        this.SiftUp(this.elements.Count - 1);
    }
    
    private void SiftDown(int idx) {
        if (idx >= this.elements.Count / 2) {
            return;
        }
        
        int leftChildIdx = (idx * 2) + 1;
        int rightChildIdx = (idx * 2) + 2;
        double leftChildVal = leftChildIdx >= this.Count ? int.MinValue: this.elements[leftChildIdx].Item1;
        double rightChildVal = rightChildIdx >= this.Count ? int.MinValue: this.elements[rightChildIdx].Item1;
        
        int targetIdx = leftChildVal > rightChildVal ? leftChildIdx : rightChildIdx;
        
        if (targetIdx < this.elements.Count && this.elements[idx].Item1 < this.elements[targetIdx].Item1) {
            this.Swap(idx, targetIdx);
            this.SiftDown(targetIdx);
        }
        
        // Otherwise do nothing... we're done as this value is larger
        // than both children.
    }
    
    private void SiftUp(int idx) {
        int parent = (idx - 1) / 2;
        
        if (parent < 0) {
            return; 
        }
        
        if (this.elements[idx].Item1 > this.elements[parent].Item1) {
            Swap(idx, parent);
            SiftUp(parent);
        }
    }
    
    private void Swap(int sourceIdx, int destIdx) {
        var temp = this.elements[sourceIdx];
        this.elements[sourceIdx] = this.elements[destIdx];
        this.elements[destIdx] = temp;
    }
    
}

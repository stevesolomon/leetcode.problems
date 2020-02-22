// https://leetcode.com/problems/kth-largest-element-in-a-stream/

public class KthLargest {
    
    private MinHeap minHeap;

    public KthLargest(int k, int[] nums) {
        minHeap = new MinHeap(k);
        
        foreach (var num in nums) {
            minHeap.Add(num);
        }        
    }
    
    public int Add(int val) {
        
        minHeap.Add(val);
        return minHeap.GetMin();        
    }
}

public class MinHeap {
    
    private int[] heap;
    
    private int maxSize;
    
    private int heapSize;
    
    public MinHeap(int size) {
        // We ignore index 0 in our heap to make the math easier.
        heap = new int[size + 2];
        heap[0] = -1;
        maxSize = size;
        heapSize = 0;
    }
    
    public void Add(int val) {
        heapSize++;
        heap[heapSize] = val;
        SiftUp();        
        
        // If we've hit the max size we need to replace root with last value and sift down.
        if (heapSize > maxSize) {
            heap[1] = heap[heapSize];
            SiftDown();
            heapSize--;
        }
    }
    
    public int GetMin() {
        return heap[1];
    }
    
    private void SiftUp() {
        int idx = heapSize;
        
        while (idx > 1 && heap[idx] < heap[idx / 2]) {
            int temp = heap[idx];
            heap[idx] = heap[idx / 2];
            heap[idx / 2] = temp;
            
            idx = idx / 2;
        }
    }
    
    private void SiftDown() {
        int idx = 1;
        
        while ((idx <= heapSize / 2) && (heap[idx] > heap[idx * 2] || ((idx * 2 + 1 < maxSize + 2) && heap[idx] > heap[idx * 2 + 1]))) {
            // Swap with smallest child
            int targetIdx = idx * 2;
            
            if ((idx * 2 + 1) < maxSize + 2 && heap[idx * 2 + 1] < heap[idx * 2]) {
                targetIdx = idx * 2 + 1;
            }
            
            int temp = heap[targetIdx];
            heap[targetIdx] = heap[idx];
            heap[idx] = temp;
            
            idx = targetIdx;
        }
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */
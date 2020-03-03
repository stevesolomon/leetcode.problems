// https://leetcode.com/problems/daily-temperatures/
// This solution uses a MinHeap to solve the problem. We can do better/less memory intensive with a Stack.

public class Solution {
    public int[] DailyTemperatures(int[] T) {
        
        if (T == null || T.Length == 0) {
            return new int[0];
        } else if (T.Length == 1) {
            return new int[] { 0 };
        }
        
        MinHeap tempHeap = new MinHeap(T.Length);
        int[] results = new int[T.Length];
        
        // Run through the temps, storing unmatched (no higher yet found) temps in a MinHeap.
        // When we find a higher temperature than the top of the minheap, keep removing from the MinHeap
        // until we reach an equal/higher temp on the heap.
        tempHeap.Add(new HeapVal(T[0], 0));
        
        for (int i = 1; i < T.Length; i++) {
            while (tempHeap.Length > 0) {
                HeapVal minVal = tempHeap.Peek();
                
                if (minVal.temp >= T[i]) {
                    break;
                }
                
                // Otherwise, pop the top of our heap and update that array idx.
                tempHeap.Remove();
                results[minVal.arrayIdx] = i - minVal.arrayIdx;                
            }
            
            // Finally, add this temp to the heap.
            tempHeap.Add(new HeapVal(T[i], i));
        }
        
        // Add the remaining entries in the heap as 0 entries in our result array as we didn't find matching values.
        while (tempHeap.Length > 0) {
            HeapVal minVal = tempHeap.Remove();
            
            results[minVal.arrayIdx] = 0;
        }
        
        return results;
    }
}

public class MinHeap {
    HeapVal[] heap;
    
    int currSize = 0;
    
    public int Length {
        get { return currSize; }
    }
    
    public MinHeap(int size) {
        // heap[0] is ignored for simplicity.
        heap = new HeapVal[size + 1];
    }
    
    public void Add(HeapVal val) {
        currSize++;
        
        heap[currSize] = val;
        SiftUp();
    }
    
    public HeapVal Remove() {
        var val = heap[1];
        
        heap[1] = heap[currSize];
        currSize--;
        
        SiftDown();
        
        return val;
    }
    
    public HeapVal Peek() {
        return heap[1];
    }
    
    private void SiftUp() {
        int idx = currSize;
        
        while (idx > 1) {
            int parentIdx = idx / 2;
            
            if (heap[parentIdx].temp < heap[idx].temp) {
                break;
            }
            
            Swap(parentIdx, idx);
            
            idx /= 2;
        }
    }
    
    private void SiftDown() {
        int idx = 1;
        
        while (idx <= currSize / 2) {
            int leftIdx = idx * 2;
            int rightIdx = leftIdx + 1;
            
            // Swap with the the lower child, if any are lower at all.
            bool leftIdxLower = rightIdx <= currSize ? heap[leftIdx].temp < heap[rightIdx].temp : true;
            
            if (leftIdxLower && heap[idx].temp > heap[leftIdx].temp) {
                Swap(leftIdx, idx);
                idx = leftIdx;
            } else if (heap[idx].temp > heap[rightIdx].temp) {
                Swap(rightIdx, idx);
                idx = rightIdx;
            } else {
                break;
            }
        }
    }
    
    private void Swap(int sourceIdx, int destIdx) {
        HeapVal temp = heap[sourceIdx];
        heap[sourceIdx] = heap[destIdx];
        heap[destIdx] = temp;
    }
}

public class HeapVal {
    public int temp;
    public int arrayIdx;
    
    public HeapVal(int temp, int arrayIdx) {
        this.temp = temp;
        this.arrayIdx = arrayIdx;
    }
}
// https://leetcode.com/problems/sort-characters-by-frequency/

public class Solution {
    public string FrequencySort(string s) {
        if (string.IsNullOrWhiteSpace(s)) {
            return string.Empty;
        }
        
        Dictionary<char, int> freqs = new Dictionary<char, int>();
        
        foreach (char c in s) {
            if (!freqs.ContainsKey(c)) {
                freqs.Add(c, 0);
            }
            
            freqs[c]++;
        }
        
        // Now we have a dictionary of character frequency values.
        // We need to traverse these from largest -> smallest frequencies.
        // We can do this by inserting each character into a max heap and popping them out.
        MaxHeap heap = new MaxHeap();
        
        foreach (var kvp in freqs) {
            heap.Insert(kvp.Key, kvp.Value);
        }
        
        StringBuilder sb = new StringBuilder();
        
        while (heap.Count > 0) {
            var curr = heap.RemoveMax();
            
            sb.Append(curr.c, curr.freq);
        }
        
        return sb.ToString();
        
    }
    
    private class MaxHeap {
        private List<HeapNode> values;
        
        public int Count { get { return this.values.Count; } }
        
        public MaxHeap() {
            this.values = new List<HeapNode>();
        }
        
        public void Insert(char character, int freq) {
            this.values.Add(new HeapNode(character, freq));
            this.SiftUp(this.values.Count - 1);
        }
        
        public HeapNode RemoveMax() {
            HeapNode maxVal = this.values[0];
            
            this.values[0] = this.values[this.values.Count - 1];
            this.values.RemoveAt(this.values.Count - 1);
            SiftDown(0);
            
            return maxVal;
        }
        
        private void SiftUp(int index) {
            while (index > 0) {
                int parentIdx = index / 2;
                
                if (this.values[parentIdx].freq > this.values[index].freq) {
                    break;
                }
                
                HeapNode temp = this.values[parentIdx];
                this.values[parentIdx] = this.values[index];
                this.values[index] = temp;
                
                index = parentIdx;
            }
        }
        
        private void SiftDown(int index) {
            while (index < this.values.Count / 2 + 1) {
                int leftChildIdx = index * 2 + 1;
                int rightChildIdx = index * 2 + 2;

                int targetIdx = index;

                if (leftChildIdx < this.values.Count && this.values[leftChildIdx].freq > this.values[targetIdx].freq) {
                    targetIdx = leftChildIdx;
                }

                if (rightChildIdx < this.values.Count && this.values[rightChildIdx].freq > this.values[targetIdx].freq) {
                    targetIdx = rightChildIdx;
                }

                if (targetIdx != index) {
                    HeapNode temp = this.values[targetIdx];
                    this.values[targetIdx] = this.values[index];
                    this.values[index] = temp;
                } else {
                    break;
                }
            
                index = targetIdx;
            }
        }
    }
    
    private class HeapNode 
    {
        public char c { get; set; }
        public int freq { get; set; }
        
        public HeapNode(char c, int freq) {
            this.c = c;
            this.freq = freq;
        }
    }
}
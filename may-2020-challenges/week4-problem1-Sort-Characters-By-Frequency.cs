// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/537/week-4-may-22nd-may-28th/3337/

public class Solution {
    public string FrequencySort(string s) {
        if (string.IsNullOrWhiteSpace(s)) {
            return s;
        }
        
        // We'll use a special MaxHeap where each node stored keeps track of its
        // letter, frequency, and actual index in the MaxHeap.
        // A Dictionary maintains a lookup table into the MaxHeap for every letter.
        // As we get new letters, we'll update the LetterNode, rip it out of the MaxHeap
        // and re-add it (to account for the adjusted frequency.)
        // Or... alternatively, we just use the Dictionary to keep track of counts,
        // then iterate through its values later and store in the maxheap :)
        Dictionary<char, int> letterFreqs = new Dictionary<char, int>();
        
        foreach (char c in s) {
            if (!letterFreqs.ContainsKey(c)) {
                letterFreqs.Add(c, 0);
            }
            
            letterFreqs[c]++;
        }
        
        LetterMaxHeap maxHeap = new LetterMaxHeap();
        
        foreach (var kvp in letterFreqs) {
            maxHeap.Add(new LetterNode(kvp.Key, kvp.Value));
        }
        
        StringBuilder sb = new StringBuilder();
        
        while (maxHeap.Count > 0) {
            var currChar = maxHeap.Remove();
            
            for (int i = 0; i < currChar.Freq; i++) {
                sb.Append(currChar.Letter);
            }
        }        
        
        return sb.ToString();
    }
}

public class LetterMaxHeap {
    List<LetterNode> heap;
    
    public int Count {
        get { return this.heap.Count; }
    }

    public LetterMaxHeap() {
        this.heap = new List<LetterNode>();
    }

    public void Add(LetterNode node) {
        // Add node at end of heap and sift it up
        this.heap.Add(node);
        SiftUp(this.heap.Count - 1);
    }

    public LetterNode Remove() {
        var retNode = this.heap[0];

        Swap(0, this.heap.Count - 1);
        this.heap.RemoveAt(this.heap.Count - 1);
        SiftDown(0);

        return retNode;
    }
    
    private void SiftUp(int index) {
        while (index > 0) {
            int parentIdx = (index - 1) / 2;

            if (heap[parentIdx].Freq < heap[index].Freq) {
                Swap(parentIdx, index);
            } else {
                break;
            }

            index = parentIdx;
        }
    }

    private void SiftDown(int index) {
        while (index < this.heap.Count / 2 + 1) {
            int leftChildIdx = index * 2 + 1;
            int rightChildIdx = index * 2 + 2;

            int targetIdx = index;

            if (leftChildIdx < this.heap.Count && this.heap[leftChildIdx].Freq > this.heap[targetIdx].Freq) {
                targetIdx = leftChildIdx;
            }

            if (rightChildIdx < this.heap.Count && this.heap[rightChildIdx].Freq > this.heap[targetIdx].Freq) {
                targetIdx = rightChildIdx;
            }

            if (targetIdx != index) {
                Swap(targetIdx, index);
            } else {
                break;
            }
            
            index = targetIdx;
        }
    }

    private void Swap(int idx1, int idx2) {
        LetterNode node1 = heap[idx1];
        LetterNode node2 = heap[idx2];

        heap[idx1] = node2;
        heap[idx2] = node1;
    }
}

public class LetterNode {
    public char Letter { get; set; }
    public int Freq { get; set; }
    
    public LetterNode(char letter, int freq) {
        this.Letter = letter;
        this.Freq = freq;
    }
}
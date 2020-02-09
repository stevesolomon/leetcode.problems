// https://leetcode.com/problems/maximum-frequency-stack/

public class FreqStack {
    
    private Dictionary<int, int> numToFreq;
    
    private Dictionary<int, Stack<int>> freqToNums;
    
    private int currMaxFreq;

    public FreqStack() {
        this.numToFreq = new Dictionary<int, int>();
        this.freqToNums = new Dictionary<int, Stack<int>>();
        currMaxFreq = 0;
    }
    
    public void Push(int x) {
        
        // When we push a new number update its frequency in numToFreqs and...
        // and its frequency to freqToNums as well.
        if (!numToFreq.ContainsKey(x)) {
            numToFreq.Add(x, 0);
        }
        
        numToFreq[x]++;        
        int freq = numToFreq[x];
        currMaxFreq = Math.Max(currMaxFreq, freq);
        
        // Note that we don't remove x from freqToNums when its frequency increases.
        // Why? Because if we pop, say, num = 6, freq = 20, num = 6 now has a freq of 19.
        // We might as well just leave it in the frequency stack for use later on rather than
        // have to constantly update these (very inefficiently as well, as the freqToNums stack
        // needs to maintain FIFO, and if we then added 6 to the freq 19 stack we'd lose the original ordering).
        if (!freqToNums.ContainsKey(freq)) {
            freqToNums.Add(freq, new Stack<int>());
        }
        
        freqToNums[freq].Push(x);
    }
    
    public int Pop() {
        
        // Pop the top of the freq stack for currMaxFreq...
        int val = freqToNums[currMaxFreq].Pop();
        
        numToFreq[val]--;
        
        // If we emptied that stack then decrement the currMaxFreq and clean up...
        // Note that we only need to decrement currMaxFreq because we kept "duplicates" of the number
        // in each frequency bucket as we observed it to maintain FIFO ordering for those frequency stacks.
        if (freqToNums[currMaxFreq].Count == 0) {
            freqToNums.Remove(currMaxFreq);
            currMaxFreq--;    
        }
        
        return val;
    }
}

/**
 * Your FreqStack object will be instantiated and called as such:
 * FreqStack obj = new FreqStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 */
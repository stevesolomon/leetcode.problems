// https://leetcode.com/problems/min-stack/submissions/

public class MinStack {
    
    private Stack<StackObject> minStack;

    public MinStack() {
        this.minStack = new Stack<StackObject>();
    }
    
    public void Push(int val) {
        int min = val;
        
        if (this.minStack.Count > 0) {
            var top = this.minStack.Peek();
            min = top.Min > val ? val : top.Min;
        }
        
        this.minStack.Push(new StackObject(val, min));
    }
    
    public void Pop() {
        
        if (this.minStack.Count > 0) {
            this.minStack.Pop();
        }
    }
    
    public int Top() {
        return this.minStack.Peek().Value;
    }
    
    public int GetMin() {
        return this.minStack.Peek().Min;
    }
}

public class StackObject {
    public int Value { get; set; }
    public int Min { get; set; }
    
    public StackObject(int value, int min) {
        this.Value = value;
        this.Min = min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
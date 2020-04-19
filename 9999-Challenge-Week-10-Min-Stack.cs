// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/529/week-2/3292/

public class MinStack {

    // Each node in the stack maintains its own value, as well
    // as the minimum value observed for all nodes below it (and itself).
    Stack<StackNode> stack;
    
    /** initialize your data structure here. */
    public MinStack() {
        stack = new Stack<StackNode>();
    }
    
    public void Push(int x) {
        int currTopMin = stack.Count > 0 ? stack.Peek().MinVal : int.MaxValue;
        
        // When pushing our new value in the stack see
        // if it starts a new minimum value. If so, we set a
        // different MinVal in this StackNode.
        StackNode newNode = new StackNode { Val = x, MinVal = currTopMin };
        if (x < currTopMin) {
            newNode.MinVal = x;
        }
        
        stack.Push(newNode);
    }
    
    public void Pop() {
        stack.Pop();
    }
    
    public int Top() {
        return stack.Peek().Val;
    }
    
    public int GetMin() {
        return stack.Peek().MinVal;
    }
}

public class StackNode {
    public int Val { get; set; }
    public int MinVal { get; set; }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
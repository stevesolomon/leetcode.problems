// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/536/week-3-may-15th-may-21st/3334/

public class StockSpanner {
    
    private Stack<SpanData> spanStack;

    public StockSpanner() {
        spanStack = new Stack<SpanData>();
    }
    
    public int Next(int price) {
        // We will use a stack that stores historical aggregated span data -
        // daily prices along with their spans. 
        // How do we aggregate? For spans of:
        //  (1) 1 day (current day only) - just push it onto the stack.
        //  (2) N days - Pop all matching span data and push the new one with a span value of N
        int span = 1;
        
        while (spanStack.Count > 0  && spanStack.Peek().Price <= price) {
            var spanData = spanStack.Pop();
            span += spanData.Span;
        }
        
        spanStack.Push(new SpanData(price, span));
        
        return span;        
    }
}

public class SpanData {
    public int Price { get; private set; }
    public int Span { get; private set; }
    
    public SpanData(int price, int span) {
        this.Price = price;
        this.Span = span;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */
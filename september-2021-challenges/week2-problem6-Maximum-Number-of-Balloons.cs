// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/637/week-2-september-8th-september-14th/3973/

public class Solution {
    public int MaxNumberOfBalloons(string text) {
        if (string.IsNullOrWhiteSpace(text) || text.Length < "balloon".Length) {
            return 0;
        }        
        
        // We'll store letter counts in a Dictionary and use that to determine how
        // many 'balloon's we can make from unique instances of a character.
        Dictionary<char, int> letterCounts = new Dictionary<char, int>();
        
        foreach (char c in text) {
            if (!letterCounts.ContainsKey(c)) {
                letterCounts.Add(c, 0);
            }
            
            letterCounts[c]++;
        }
        
        // Now, we need at least this many chars for each word:
        //    b: 1
        //    a: 1
        //    l: 2
        //    o: 2
        //    n: 1
        int numWordsPossible = int.MaxValue;
        
        numWordsPossible = letterCounts.ContainsKey('b') ? Math.Min(numWordsPossible, letterCounts['b']) : 0;
        numWordsPossible = letterCounts.ContainsKey('a') ? Math.Min(numWordsPossible, letterCounts['a']) : 0;
        numWordsPossible = letterCounts.ContainsKey('n') ? Math.Min(numWordsPossible, letterCounts['n']) : 0;
        numWordsPossible = letterCounts.ContainsKey('l') ? Math.Min(numWordsPossible, letterCounts['l'] / 2) : 0;
        numWordsPossible = letterCounts.ContainsKey('o') ? Math.Min(numWordsPossible, letterCounts['o'] / 2) : 0;
        
        return numWordsPossible;
    }
}
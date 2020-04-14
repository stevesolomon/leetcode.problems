// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/528/week-1/3288/

public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        if (strs == null || strs.Length == 0) {
            return new List<IList<string>>();
        }
        
        // As we could be working with extended characters, we'll rely on sorting
        // the strings and using that as our keys.
        // Were we working with a limited character set we could count chars in
        // each string and store these char counts as their own unique "string" in a Dict.
        Dictionary<string, IList<string>> groups = new Dictionary<string, IList<string>>();
        
        foreach (var str in strs) {
            var sortedStr = new string(str.OrderBy(c => c).ToArray());
            
            if (!groups.ContainsKey(sortedStr)) {
                groups.Add(sortedStr, new List<string>());
            }
            
            groups[sortedStr].Add(str);
        }
        
        IList<IList<string>> results = new List<IList<string>>();
        
        foreach (var list in groups.Values) {
            results.Add(list);
        }
        
        return results;
    }
}
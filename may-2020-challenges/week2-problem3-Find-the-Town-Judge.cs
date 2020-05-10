// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3325/

public class Solution {
    public int FindJudge(int N, int[][] trust) {
        if (N == 0) {
            return -1;
        } else if (N == 1) {
            return 1;
        }
        
        // We will build up a dictionary where the key is the person
        // and the value is the count of others who trust the person.
        // Along with another dictionary where the key is the person
        // the value is the count of people this person trusts.
        // As trust[i] are all different the values can simply be 
        // aggregate counts, rather than HashSets of people.
        Dictionary<int, int> whoTrustsMe = new Dictionary<int, int>();
        Dictionary<int, int> whoITrust = new Dictionary<int, int>();
        
        for (int i = 0; i < trust.Length; i++) {
            int source = trust[i][0];
            int trusts = trust[i][1];
            
            if (!whoTrustsMe.ContainsKey(trusts)) {
                whoTrustsMe.Add(trusts, 0);
            }
            
            if (!whoITrust.ContainsKey(source)) {
                whoITrust.Add(source, 0);
            }
            
            whoTrustsMe[trusts]++;
            whoITrust[source]++;
        }
        
        // Now search for a candidate meeting both critera...
        // We'll start by searching for someone trusted by all.
        foreach (var kvp in whoTrustsMe) {
            if (kvp.Value == N - 1) {
                // We are trusted by everyone... but do we trust no-one?
                if (!whoITrust.ContainsKey(kvp.Key)) {
                    return kvp.Key;
                }
            }
        }
        
        return -1;
    }
}
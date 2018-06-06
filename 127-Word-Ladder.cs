// https://leetcode.com/problems/word-ladder/description/

public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        if (string.IsNullOrWhiteSpace(beginWord) || 
            string.IsNullOrWhiteSpace(endWord) || 
            wordList == null || 
            wordList.Count() == 0) {
            return 0;
        }
        
        if (beginWord.Equals(endWord)) {
            return 0;
        }
        
        // Perform a Breath-First Traversal of the solution space.
        // At each node we will try to create words in the wordList by
        // changing any single character.
        // Any word we create will be added as a new node to the traversal.
        // Layers represent the number of steps we've taken.
        Queue<string> inputs = new Queue<string>();
        inputs.Enqueue(beginWord);
        inputs.Enqueue(null);
        
        // Set up a dictionary of words already discovered. We don't want to 
        // waste time revisiting already-visited words in later layers of our
        // BFS search (as they will clearly not result in an optimal path).
        HashSet<string> discoveredWords = new HashSet<string>();
        discoveredWords.Add(beginWord);
        
        // First store our word list in a HashSet for quicker retrieval.
        HashSet<string> wordListSet = new HashSet<string>();
        
        int currLayer = 1;
        
        foreach (string word in wordList) {
            wordListSet.Add(word);
        }
        
        // Quick check to see if we can actually form the word or not.
        if (!wordListSet.Contains(endWord)) {
            return 0;
        }
        
        while (inputs.Count > 0) {
            string currWord = inputs.Dequeue();
            
            if (currWord == null) {
                if (inputs.Count > 0) {
                    inputs.Enqueue(null);
                    currLayer++;
                    continue;
                }
                
                // We ran out of nodes to visit. We failed.
                return 0;
            }
            
            // Otherwise, try replacing each letter index...
            for (int i = 0; i < currWord.Length; i++) {
                
                // With every possible character...
                for (char c = 'a'; c <= 'z'; c++) {
                    StringBuilder sb = new StringBuilder(currWord);                    
                    sb[i] = c;
                    string newWord = sb.ToString();
                    
                    // If we've found the word, return our current layer.
                    // Or, rather, currLayer + 1, as we're technically in the "next"
                    // layer when we see this word, we're just exiting earlier.
                    if (newWord.Equals(endWord)) {
                        return currLayer + 1;
                    } else if (wordListSet.Contains(newWord) && !discoveredWords.Contains(newWord)) {
                        
                        // Otherwise we didn't find the end word, but we do have a word we
                        // haven't yet visited in the solution space.
                        inputs.Enqueue(newWord);
                        discoveredWords.Add(newWord);
                    }
                }
            }
        }
        
        return 0;
    }
}
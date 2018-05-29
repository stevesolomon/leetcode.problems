// https://leetcode.com/problems/stickers-to-spell-word/description/
//
// Totally went overboard with using a custom class/Dictionary instead of
// an array to map letter counts for each sticker, but this was more fun.

public class Solution {
    public int MinStickers(string[] stickerArray, string target) {
        if (stickerArray == null || stickerArray.Length == 0) {
            return -1;
        } else if (string.IsNullOrWhiteSpace(target)) {
            return 0;
        }
        
        // First build up our stickers.
        List<Sticker> stickers = new List<Sticker>();
        
        foreach (string sticker in stickerArray) {
            stickers.Add(new Sticker(sticker));
        }
        
        // Now, perform a BFS traversal of the solution space.
        //   - At every node: 
        //      -- Try to grab all the letters we can from each sticker in turn.
        //         - If we've exhaused that sticker and there are still letters to be used,
        //           then add the remaining letters into the Queue.
        //   - We use nulls in the Queue to represent layer terminators.
        //      -- A layer in this case means we have HAD to take a new sticker.
        Queue<string> traversal = new Queue<string>();
        HashSet<string> alreadySeen = new HashSet<string>();
        
        traversal.Enqueue(target);
        traversal.Enqueue(null);
        
        int numStickersUsed = 1;
        
        while (traversal.Count > 0) {
            
            string remaining = traversal.Dequeue();
            
            if (remaining == null) {
                if (traversal.Count > 0) {
                    traversal.Enqueue(null);
                }
                numStickersUsed++;
                continue;
            }
            
            string key = GetRemainingKey(remaining);
            
            if (!alreadySeen.Contains(key)) {                
                alreadySeen.Add(key);
                
                // Grab everything we can from a given sticker.
                foreach (Sticker sticker in stickers) {
                    bool usedThisSticker = false;
                    
                    string tempRemaining = (string) remaining.Clone();
                    
                    // Try to take ever letter we need from the Sticker.
                    for (int i = tempRemaining.Length - 1; i >= 0; i--) {
                        if (sticker.HasLetterAvailable(tempRemaining[i])) {
                            usedThisSticker = true;
                            
                            sticker.TakeLetter(tempRemaining[i]);                            
                            tempRemaining = tempRemaining.Remove(i, 1);                            
                        }
                    }
                    
                    // We're done if we used them all...
                    if (tempRemaining.Length == 0) {
                        return numStickersUsed;
                    }
                    
                    // Otherwise, if we used this sticker at all,
                    // Add this potential solution to the Queue.
                    if (usedThisSticker) {
                        sticker.RefreshSticker();
                        traversal.Enqueue(tempRemaining);
                    }
                }
            }
        }
            
        return -1;        
    }
    
    private string GetRemainingKey(string letters) {
        char[] characters = letters.ToArray();
        Array.Sort(characters);
        return new string(characters);
    }
}

public class Sticker {
    
    private string originalWord;
    
    private Dictionary<char, int> letters;
    
    public Sticker(string word) {
        this.originalWord = word;
        this.letters = new Dictionary<char, int>();
        
        GenerateLetters();
    }
    
    public bool OriginalWordHasLetter(char letter) {
        return originalWord.Contains(letter);
    }
    
    public bool HasLetterAvailable(char letter) {
        return letters.ContainsKey(letter) && letters[letter] > 0;
    }
    
    public bool TakeLetter(char letter) {
        if (!letters.ContainsKey(letter) || letters[letter] == 0) {
            return false;
        }
        
        letters[letter]--;
        
        return true;
    }
    
    public void RefreshSticker() {
        GenerateLetters();
    }
    
    private void GenerateLetters() {
        letters.Clear();
        
        foreach (char letter in originalWord) {
            if (!letters.ContainsKey(letter)) {
                letters.Add(letter, 0);
            }
            
            letters[letter]++;
        }
    }
}
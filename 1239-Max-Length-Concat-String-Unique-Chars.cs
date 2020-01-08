// https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/

public class Solution
{
    public int MaxLength(IList<string> arr)
    {
        if (arr.Count == 0)
        {
            return 0;
        }

        // First prune our word list to only those words that contain unique characters.
        // At the same time we'll also build up a set of HashSets containing character counts
        // for each word that we know we'll use.
        List<string> pruned = new List<string>();
        List<HashSet<char>> prunedChars = new List<HashSet<char>>();

        foreach (var word in arr)
        {
            HashSet<char> seen = new HashSet<char>();
            bool valid = true;

            foreach (var c in word)
            {
                if (seen.Contains(c))
                {
                    valid = false;
                    break;
                }

                seen.Add(c);
            }

            if (valid)
            {
                pruned.Add(word);
                prunedChars.Add(seen);
            }
        }

        // Now perform a breadth-first traversal of the graph. Every "node" we visit represents some
        // combination of strings from the pruned array. Each node maintains the latest index in the pruned array
        // that it was built from, its length, and the set of characters observed within this string.
        Queue<TraversalNode> traversal = new Queue<TraversalNode>();
        traversal.Enqueue(new TraversalNode(-1, 0, new HashSet<char>()));

        int longestSoln = 0;

        while (traversal.Count > 0)
        {
            var currNode = traversal.Dequeue();

            // From the current node, we'll try to visit all indices in pruned > our current one
            // as long as there are no collisions in that string's hashset.
            for (int i = currNode.Idx + 1; i < pruned.Count; i++)
            {

                // Test for char collisions
                bool collision = false;

                foreach (var c in currNode.CharSeen)
                {
                    if (prunedChars[i].Contains(c))
                    {
                        collision = true;
                        break;
                    }
                }

                // We didn't have a collision, let's consider this node as a candidate.
                if (!collision)
                {
                    int len = currNode.Length + pruned[i].Length;

                    HashSet<char> newChars = new HashSet<char>();
                    newChars.UnionWith(currNode.CharSeen);
                    newChars.UnionWith(prunedChars[i]);

                    traversal.Enqueue(new TraversalNode(i, len, newChars));

                    longestSoln = len > longestSoln ? len : longestSoln;
                }
            }
        }

        return longestSoln;
    }
}

public class TraversalNode
{

    public int Idx { get; set; }
    public int Length { get; set; }
    public HashSet<char> CharSeen { get; set; }

    public TraversalNode(int idx, int length, HashSet<char> charSeen)
    {
        this.Idx = idx;
        this.Length = length;
        this.CharSeen = charSeen;
    }
}


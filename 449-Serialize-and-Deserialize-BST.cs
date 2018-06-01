// https://leetcode.com/problems/serialize-and-deserialize-bst/description/

public class Codec
{
    private const char DELIMITER = ',';

    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        if (root == null) {
            return string.Empty;
        }
        
        StringBuilder sb = new StringBuilder();

        SerializeHelper(root, sb);

        return sb.Remove(sb.Length - 1, 1).ToString();
    }

    private void SerializeHelper(TreeNode root, StringBuilder sb)
    {
        if (root == null) {
            return;
        }
        
        // Perform a post-order traversal of the tree
        SerializeHelper(root.left, sb);
        SerializeHelper(root.right, sb);
        
        sb.Append(root.val);
        sb.Append(DELIMITER);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        if (string.IsNullOrWhiteSpace(data)) {
            return null;
        }
        
        string[] stringArray = data.Split(DELIMITER);
        int[] dataArray = new int[stringArray.Length];
        
        for (int i = 0; i < dataArray.Length; i++) {
            dataArray[i] = int.Parse(stringArray[i]);
        }
        
        // What we have is a string/array that looks like this:
        //         5
        //     2       10
        //  1        7     11
        //
        // ==> [1, 2, 7, 11, 10, 5]
        // As this was a post-order traversal, the root of the tree must be the last
        // element.
        // As this was a BST, and constructed via post-order, the value directly to the left
        // of the root is the start of the right subtree.
        // We then search for the right-most value from the root such that the value is < root.
        // This will be the start of the left subtree.
        return DeserializeHelper(dataArray, 0, dataArray.Length - 1);
    }
    
    private TreeNode DeserializeHelper(int[] data, int startIdx, int endIdx) {
        if (startIdx > endIdx || startIdx < 0) {
            return null;
        } 
        
        // Create the root node first from the value at endIdx.
        TreeNode root = new TreeNode(data[endIdx]);
        
        // Now figure out where our right and left subtree's start/end...
        // The dividing line (the end of the left subtree) is the right-most value
        // from endIdx such that the value is lower than the root's value.
        int leftSubtreeEndIdx = startIdx - 1;
        
        for (int i = endIdx - 1; i >= startIdx; i--) {
            if (data[i] < data[endIdx]) {
                leftSubtreeEndIdx = i;
                break;
            }
        }
        
        // Now build up the left and right subtrees...
        root.left = DeserializeHelper(data, startIdx, leftSubtreeEndIdx);
        root.right = DeserializeHelper(data, leftSubtreeEndIdx + 1, endIdx - 1);
        
        return root;
    }
}
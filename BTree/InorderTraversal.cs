/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        List<int> result = new List<int>();
        
        // Recursion(result, root);
        NonRecursion(result, root);
        
        return result;
    }
    
    private void Recursion(List<int> result, TreeNode node)
    {
        if (node == null) return;
        
        Recursion(result, node.left);
        result.Add(node.val);
        Recursion(result, node.right);
    }
    
    private void NonRecursion(List<int> result, TreeNode node)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode current = node;
        
        while (current != null || stack.Count > 0)
        {
            if (current != null)
            {
                stack.Push(current);
                current = current.left;
            }
            else
            {
                current = stack.Pop();
                result.Add(current.val);
                current = current.right;
            }
        }
    }
}
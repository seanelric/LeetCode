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
    public IList<int> PreorderTraversal(TreeNode root)
    {
        List<int> result = new List<int>();
        
        //Recursion(result, root);
        // NonRecursion(result, root);
        NonRecursion1(result, root);
        
        return result;
    }
    
    private void Recursion(List<int> result, TreeNode node)
    {
        if (node == null) return;
        
        result.Add(node.val);
        Recursion(result, node.left);
        Recursion(result, node.right);
    }
    
    private void NonRecursion(List<int> result, TreeNode root)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode current = root;
        
        while (current != null || stack.Count > 0)
        {
            if (current != null)
            {
                result.Add(current.val);
                stack.Push(current);
                current = current.left;
            }
            else
            {
                current = stack.Pop();
                current = current.right;
            }
        }
    }
    
    private void NonRecursion1(List<int> result, TreeNode root)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode current = root;
        
        while (current != null)
        {
            result.Add(current.val);
            
            // Push right
            if (current.right != null)
            {
                stack.Push(current.right);
            }
            
            // Point to left
            current = current.left;
            
            if (current == null && stack.Count > 0)
            {
                current = stack.Pop();
            }
        }
    }
}
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
    public IList<int> PostorderTraversal(TreeNode root)
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
        Recursion(result, node.right);
        result.Add(node.val);
    }
    
    private void NonRecursion(List<int> result, TreeNode root)
    {
        if (root == null) return;
        
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        
        TreeNode pre = null;
        TreeNode current = null;
        
        while (stack.Count > 0)
        {
            current = stack.Peek();
            
            if ((current.left == null && current.right == null)
               || (pre != null && (pre == current.left || pre == current.right)))
            {
                result.Add(current.val);
                stack.Pop();
                pre = current;
            }
            else
            {
                if (current.right != null) stack.Push(current.right);
                if (current.left != null) stack.Push(current.left);
            }
        }
    }
}
namespace Algorithms.Leetcode;

public class SymmetricTree
{
    public bool IsSymmetric(TreeNode root)
    {
        InvertTreeRecursion(root);
        
        return IsSameTree(root.left,root.right);
    }
    
    private void InvertTreeRecursion(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        
        InvertTreeRecursion(root.left);
        InvertTreeRecursion(root.right);
        (root.left, root.right) = (root.right, root.left);
    }
    
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null)
        {
            return true;
        }
        
        if ((p == null && q != null) || (p != null && q == null))
        {
            return false;
        }

        if (p.val != q.val)
        {
            return false;
        }

        var left = IsSameTree(p.left,q.right);
        var right = IsSameTree(p.right,q.left);
        
        return left && right;   
    }
}
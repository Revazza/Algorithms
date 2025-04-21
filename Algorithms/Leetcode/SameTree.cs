namespace Algorithms.Leetcode;

public class SameTree
{
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

        var left = IsSameTree(p.left,q.left);
        var right = IsSameTree(p.right,q.right);
        
        return left && right;   
    }
}
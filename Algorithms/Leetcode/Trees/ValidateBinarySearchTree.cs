namespace Algorithms.Leetcode;

public class ValidateBinarySearchTree
{
    public bool IsValidBST(TreeNode root)
    {
        return IsValidBST(root, long.MinValue, long.MaxValue);
    }

    private bool IsValidBST(TreeNode node, long minimum, long maximum)
    {
        if (node == null)
        {
            return true;
        }

        if (!(node.val > minimum && node.val < maximum))
        {
            return false;
        }

        var ok = new Queue<int>();
        ok.Enqueue(1);
        while (ok.Count != 0)
        {
            ok.Dequeue();
            
        }

        return IsValidBST(node.left, minimum, node.val) &&
               IsValidBST(node.right, node.val, maximum);
    }
}
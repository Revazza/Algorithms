namespace Algorithms.Leetcode;

public class LowestCommonAncestorOfBinarySearchTree
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode first, TreeNode second)
    {
        var temp = root;
        while (temp != null)
        {
            if (temp.val < first.val && temp.val < second.val)
            {
                temp = temp.right;
                continue;
            }

            if (temp.val > first.val && temp.val > second.val)
            {
                temp = temp.left;
                continue;
            }

            return temp;
        }

        return null;
    }
}
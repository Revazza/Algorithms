namespace Algorithms.Leetcode;

public class MergeTrees
{
    public TreeNode Solve(TreeNode root1, TreeNode root2)
    {
        if (root1 == null && root2 == null)
        {
            return null;
        }

        return CopyTree(root1, root2);
    }

    private TreeNode CopyTree(TreeNode r1, TreeNode r2)
    {
        if (r1 == null && r2 == null)
        {
            return null;
        }

        TreeNode newNode = null;

        if (r1 != null && r2 != null)
        {
            newNode = new TreeNode(r1.val + r2.val);
        }
        else if (r1 != null && r2 == null)
        {
            newNode = new TreeNode(r1.val);
        }
        else if (r1 == null && r2 != null)
        {
            newNode = new TreeNode(r2.val);
        }

        newNode.left = CopyTree(r1?.left, r2?.left);
        newNode.right = CopyTree(r1?.right, r2?.right);

        return newNode;
    }
}
namespace Algorithms.Leetcode;

public class InvertBinaryTree
{
    public TreeNode InvertTree(TreeNode root)
    {
        InvertTreeRecursion(root);
        return root;
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
}
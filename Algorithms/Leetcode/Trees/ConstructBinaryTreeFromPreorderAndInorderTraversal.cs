namespace Algorithms.Leetcode;

public class ConstructBinaryTreeFromPreorderAndInorderTraversal
{
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        var headIndex = 0;
        return BuildBinaryTree(0, preorder.Length - 1, preorder, inorder, ref headIndex);
    }

    private TreeNode BuildBinaryTree(int left, int right, int[] preorder, int[] inorder, ref int preIndex)
    {
        if (left > right)
        {
            return null;
        }

        var root = new TreeNode(preorder[preIndex]);
        preIndex++;
        var index = FindValueIndex(root.val, inorder);
        root.left = BuildBinaryTree(left, index - 1, preorder, inorder, ref preIndex);
        root.right = BuildBinaryTree(index + 1, right, preorder, inorder, ref preIndex);

        return root;
    }

    private int FindValueIndex(int value, int[] inorder)
    {
        for (int i = 0; i < inorder.Length; i++)
        {
            if (inorder[i] == value)
            {
                return i;
            }
        }

        return -1;
    }
}
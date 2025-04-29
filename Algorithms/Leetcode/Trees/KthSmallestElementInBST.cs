namespace Algorithms.Leetcode;

public class KthSmallestElementInBST
{
    public int KthSmallest(TreeNode root, int k)
    {
        var ok = InOrderRecursive(root, k);
        return 0;
    }

    private int InOrderRecursive(TreeNode node, int k)
    {
        if (node == null)
        {
            return 0;
        }

        var left = InOrderRecursive(node.left, k);
        if (left == k)
        {
            return node.left.val;
        }

        var right = InOrderRecursive(node.right, k);
        if (right == k)
        {
            return node.right.val;
        }

        return 1;
    }
}
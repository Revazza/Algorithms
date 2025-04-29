namespace Algorithms.Leetcode;

public class KthSmallestElementInBST
{
    public int KthSmallest(TreeNode root, int k)
    {
        var list = new List<int>();
        InOrderRecursive(root, list);

        return list[k - 1];
    }

    private void InOrderRecursive(TreeNode node, List<int> list)
    {
        if (node == null)
        {
            return;
        }

        if (node.left != null)
        {
            InOrderRecursive(node.left, list);
        }

        list.Add(node.val);

        if (node.right != null)
        {
            InOrderRecursive(node.right, list);
        }
    }
}
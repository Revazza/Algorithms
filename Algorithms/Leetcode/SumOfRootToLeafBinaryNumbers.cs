namespace Algorithms.Leetcode;

public class SumOfRootToLeafBinaryNumbers
{
    public int Solve(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        var sum = CollectBits(node, 0);

        return sum;
    }

    public int CollectBits(TreeNode? node, int sum)
    {
        if (node == null)
        {
            return 0;
        }

        sum = 2 * sum + node.val;

        if (node.left == null && node.right == null)
        {
            return sum;
        }
        
        return  CollectBits(node.left, sum) + CollectBits(node.right, sum);;
    }
}
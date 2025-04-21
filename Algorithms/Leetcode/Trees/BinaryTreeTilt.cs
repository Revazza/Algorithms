namespace Algorithms.Leetcode;

public class BinaryTreeTilt
{
    public int Solve(TreeNode root) {

        if (root == null)
        {
            return 0;
        }

        var sum = 0;
        TiltRecursive(root, ref sum);
        return sum;
    }

    private int TiltRecursive(TreeNode node, ref int sum){
        if (node == null)
        {
            return 0;
        }

        var leftValue = TiltRecursive(node.left,ref sum);
        var rightValue = TiltRecursive(node.right,ref sum);
        var currentValue = node.val;

        node.val = Math.Abs(leftValue - rightValue);
        sum += node.val;
        
        return leftValue + rightValue + currentValue;
    }
}
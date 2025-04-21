namespace Algorithms.Leetcode;

public class CousinsInBinaryTree
{
    public bool Solve(TreeNode root, int x, int y)
    {
        if (root == null)
        {
            return false;
        }

        var requiredDepth = 0;
        var stack = new Stack<(TreeNode Parent, TreeNode Node, int Depth)>();
        stack.Push((null, root, 0));

        (int depth, TreeNode parent) xInfo = (-1, null);
        (int depth, TreeNode parent) yInfo = (-1, null);

        while (stack.Count > 0)
        {
            var (parent, current, depth) = stack.Pop();

            if (current.val == x)
            {
                xInfo.depth = depth;
                xInfo.parent = parent;
                if (yInfo.parent != null) break;
            }
            
            if (current.val == y)
            {
                yInfo.depth = depth;
                yInfo.parent = parent;
                if (xInfo.parent != null) break;
            }

            if (current.left != null)
            {
                stack.Push((current, current.left, depth + 1));
            }

            if (current.right != null)
            {
                stack.Push((current, current.right, depth + 1));
            }
        }

        if (xInfo.depth == yInfo.depth && xInfo.parent != yInfo.parent)
        {
            Console.WriteLine("TRUE");
            return true;
        }

        return false;
    }
}
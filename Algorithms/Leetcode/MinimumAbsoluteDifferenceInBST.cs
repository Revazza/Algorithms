using Algorithms.Extensions;

namespace Algorithms.Leetcode;

public class MinimumAbsoluteDifferenceInBST
{
    public int Solve(TreeNode root)
    {
        var list = new List<int>();
        var queue = new Stack<TreeNode>();
        queue.Push(root);

        while (queue.Count > 0)
        {
            var current = queue.Pop();

            list.Add(current.val);
            
            if (current.left != null)
            {
                queue.Push(current.left);
            }
            
            if (current.right != null)
            {
                queue.Push(current.right);
            }
        }

        list.Sort();        
        
        int minDiff = int.MaxValue;
    
        for (int i = 0; i < list.Count - 1; i++)
        {
            var currentDiff = Math.Abs(list[i] - list[i + 1]);
            minDiff = Math.Min(minDiff, currentDiff);
        }

        return minDiff;
    }
}
namespace Algorithms.Leetcode;

public class BinaryTreeLevelOrderTraversal
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        if (root == null)
        {
            return [];
        }

        var answer = new List<IList<int>>();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count != 0)
        {
            var count = q.Count;
            var counter = 0;

            var sub = new List<int>();
            while (counter < count)
            {
                var current = q.Dequeue();
                sub.Add(current.val);
                if (current.left != null)
                {
                    q.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    q.Enqueue(current.right);
                }

                counter++;
            }
        
            answer.Add(sub);
        }

        return answer;
    }
}
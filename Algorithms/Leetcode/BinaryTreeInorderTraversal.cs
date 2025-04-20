namespace Algorithms.Leetcode;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class BinaryTreeInorderTraversal
{
    public IList<int> Solve(TreeNode root)
    {
        if (root is null)
        {
            return [];
        }

        var list = new List<int>();
        Solution(root, list);
        return list;
    }

    private void Solution(TreeNode root, IList<int> list)
    {
        if (root is null)
        {
            return;
        }

        Solution(root.left, list);
        
        list.Add(root.val);
        
        Solution(root.right, list);
    }
}
namespace Algorithms.Leetcode;

public class ConvertSortedArrayToBinarySearchTree
{
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return BuildRecursively(0, nums.Length - 1, nums);
    }

    private TreeNode BuildRecursively(int low, int high, int[] nums)
    {
        if (low > high)
        {
            return null;
        }

        var mid = (low + high + 1) / 2;

        var root = new TreeNode(nums[mid]);

        root.left = BuildRecursively(low, mid - 1, nums);
        root.right = BuildRecursively(mid + 1, high, nums);
        return root;
    }
}
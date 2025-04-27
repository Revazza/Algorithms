namespace Algorithms.Leetcode.Arrays;

public class LongestIncreasingSubsequence
{
    public int Solve(int[] nums)
    {
        var ans = int.MinValue;
        var stack = new Stack<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            stack.Push(nums[i]);
            var count = CountMaxLength(i, stack, nums);
            ans = int.Max(ans, count);
            stack.Pop();
        }

        return ans;
    }

    private int CountMaxLength(
        int index,
        Stack<int> stack,
        int[] nums)
    {
        var max = stack.Count;

        for (int i = index + 1; i < nums.Length; i++)
        {
            if (nums[i] <= nums[index])
            {
                continue;
            }

            stack.Push(nums[i]);
            var count = CountMaxLength(i, stack, nums);
            max = Math.Max(max, count);
            stack.Pop();
        }

        return max;
    }
}
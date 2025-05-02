namespace Algorithms.Leetcode.Arrays;

public class MaximumProductSubarray
{
    public int MaxProduct(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        var ans = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            var odd = FindMaxProduct(i, i, nums);
            var even = FindMaxProduct(i, i + 1, nums);
            var max = Math.Max(odd, even);
            ans = Math.Max(ans, max);
        }

        return ans;
    }

    private int FindMaxProduct(int left, int right, int[] nums)
    {
        var maxProd = 0;
        var product = 1;
        while (left >= 0 && right < nums.Length)
        {
            if (left == right)
            {
                product = nums[left];
            }
            else
            {
                product *= nums[left] * nums[right];
            }

            maxProd = Math.Max(maxProd, product);

            left--;
            right++;
        }

        return maxProd;
    }
}
namespace Algorithms.Leetcode.Arrays;

public class MaximumProductSubarray
{
    public int Solve(int[] nums)
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
            Console.WriteLine("Odd :" + odd);
            Console.WriteLine("Even :" + even);
            var max = Math.Max(odd, even);
            ans = Math.Max(max, ans);
        }

        return ans;
    }


    private int FindMaxProduct(int l, int r, int[] nums)
    {
        var product = 1;
        while (l >= 0 && r < nums.Length)
        {
            if (nums[l] == 0 || nums[r] == 0)
            {
                return 0;
            }

            if (l == r)
            {
                product *= nums[l];
            }
            else
            {
                product = product * nums[l] * nums[r];
            }

            r++;
            l--;
        }

        return product;
    }
}
namespace Algorithms.Leetcode.Arrays;

public class ProductOfArrayExceptSelf
{
    // 2 3 6 2
    public int[] ProductExceptSelf(int[] nums)
    {
        var prefixes = new List<int> { 1 };

        for (int i = 1; i < nums.Length; i++)
        {
            prefixes.Add(nums[i - 1] * prefixes[i - 1]);
        }

        var postfixes = new int[nums.Length];
        postfixes[^1] = 1;
        var index = postfixes.Length - 2;
        for (int i = nums.Length - 1; i > 0; i--)
        {
            postfixes[index] = nums[i] * postfixes[index + 1];
            index--;
        }

        var result = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = prefixes[i] * postfixes[i];
        }
        
        return result;
    }
}
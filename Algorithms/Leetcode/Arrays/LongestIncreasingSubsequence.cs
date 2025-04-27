namespace Algorithms.Leetcode.Arrays;

public class LongestIncreasingSubsequence
{   
    public int Solve(int[] nums)
    {
        // 10,9,2,5,3,7,101,18

        var dict = new Dictionary<int, int>();
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            var count = 0;
            for (var k = i; k < nums.Length; k++)
            {
                if (nums[i] >= nums[k])
                {
                    continue;
                }

                count = int.Max(count, dict[k]);
            }

            Console.WriteLine($"{nums[i]} - {count + 1}");
            dict[i] = int.Max(1, count + 1);
        }
        
        return dict.Max(x => x.Value);
    }
}
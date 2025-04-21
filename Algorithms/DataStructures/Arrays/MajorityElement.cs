namespace Algorithms.DataStructures.Arrays;

public class MajorityElement
{
    public int Solve(int[] nums)
    {
        // Example 1:
        //
        // Input: nums = [3,2,3]
        // Output: 3
        // Example 2:
        //
        // Input: nums = [2,2,1,1,1,2,2]
        // Output: 2

        if (nums.Length == 0)
        {
            return -1;
        }

        var dict = new Dictionary<int, int>();
        var majorityCount = nums.Length / 2;
        for (int i = 0; i < nums.Length; i++)
        {
            if (dict.TryGetValue(nums[i], out int value))
            {
                if (++value > majorityCount)
                {
                    return nums[i];
                }

                dict[nums[i]] = value;
            }
            else
            {
                dict[nums[i]] = 1;
            }
        }

        return nums[0];
    }
}
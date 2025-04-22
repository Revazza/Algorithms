namespace Algorithms.DataStructures.Arrays;

public class MoveZeroes
{
    public void Solve(int[] nums)
    {
        // Input: nums = [0,1,0,3,12]
        // Output: [1,3,12,0,0]

        var j = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                continue;
            }

            (nums[j], nums[i]) = (nums[i], nums[j]);
            j++;
        }
    }
}
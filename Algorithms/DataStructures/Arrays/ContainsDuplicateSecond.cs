namespace Algorithms.DataStructures.Arrays;

public class ContainsDuplicateSecond
{
    public bool Solve(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if(dict.ContainsKey(nums[i]) && Math.Abs(dict[nums[i]] - i) <= k){
                return true;
            }

            dict[nums[i]] = i;
        }

        return false;
    }
}
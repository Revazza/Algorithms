namespace Algorithms.DataStructures.Arrays;

public class ContainsDuplicate
{
    public bool Solve(int[] nums)
    {
        var dict = new Dictionary<int, int>(nums.Length);

        return nums.Any(num => !dict.TryAdd(num, 0));
    }
}
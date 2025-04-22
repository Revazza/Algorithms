namespace Algorithms.DataStructures.Arrays;

public class MissingNumber
{
    public int Solve(int[] nums)
    {
        var expected = nums.Length * (nums.Length + 1) / 2;
        var sum = nums.Sum();

        return expected - sum;
    }
}
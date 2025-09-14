namespace Algorithms.Amazon;

public class MergeOperationsToTurnArrayIntoPalindrome
{
    public int MinimumOperations(int[] nums) {

        var steps = 0;

        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            if (nums[left] > nums[right]) {
                nums[right - 1] += nums[right];
                right--;
                steps++;
                continue;
            }

            if (nums[left] < nums[right]) {
                nums[left + 1] += nums[left];
                left++;
                steps++;
                continue;
            }

            left++;
            right--;
        }

        return steps;
    }
}
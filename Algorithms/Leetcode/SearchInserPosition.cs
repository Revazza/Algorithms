namespace Algorithms.Leetcode;

public class SearchInserPosition
{
    public int Solve(int[] nums, int target)
    {
        return BinarySearch(0, nums.Length - 1, target, nums);
    }

    private int BinarySearch(int low, int high, int target, int[] nums)
    {
        if (high < low)
        {
            Console.WriteLine(low + " " + high);
            Console.WriteLine("Couldn't found but could be added to index");

            if (target > nums[Math.Max(low - 1, 0)])
            {
                return Math.Max(low,0);
            }

            return Math.Max(high,0);
        }
        
        var mid = low + (high - low) / 2;
        if (nums[mid] == target)
        {
            Console.WriteLine("Found - " + nums[mid]);
            return mid;
        }

        if (target > nums[mid])
        {
            return BinarySearch(mid + 1, high, target, nums);
        }

        return BinarySearch(low, mid - 1, target, nums);
    }
}
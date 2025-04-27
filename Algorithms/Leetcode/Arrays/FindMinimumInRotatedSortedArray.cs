namespace Algorithms.Leetcode.Arrays;

public class FindMinimumInRotatedSortedArray
{
    public int FindMin(int[] nums) {
        // 1 2 3 4 5 6 7   r = 5
        // 6 7 1 2 3 4 5 8
        // 0     3       7
        //    m1 m m2

        if(nums.Length == 1){
            return nums[0];
        }

        var dict = new Dictionary<char, int>();
        var max = dict.Max(x => x.Value);
        return FindMinRecursive(0, nums.Length - 1,int.MaxValue, nums);
    }

    private int FindMinRecursive(int low, int high, int min, int[] nums){
        if(low > high){
            return min;
        }
        var mid = low + (high - low) / 2;

        if(nums[mid] < low){
            return FindMinRecursive(low, mid - 1, Math.Min(min, nums[mid]), nums);
        }

        return FindMinRecursive(mid + 1, high, Math.Min(min, nums[mid]), nums);
    }
}
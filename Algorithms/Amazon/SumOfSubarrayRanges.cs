namespace Algorithms.Amazon;

public class SumOfSubarrayRanges
{
    public long SubArrayRanges(int[] nums) {
        
        long result = 0;

        for(int i = 0;i < nums.Length; i++){

            long min = nums[i];
            long max = nums[i];

            for(int k = i; k < nums.Length; k ++){
                min = Math.Min(nums[k], min);
                max = Math.Max(nums[k], max);
                result += max - min;
            }
        }

        return result;
    }
}
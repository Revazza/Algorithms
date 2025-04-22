namespace Algorithms.DataStructures.Arrays;

public class RangeSumQueryImmutable
{
    public class NumArray
    {
        public int[] Nums { get; set; }

        public NumArray(int[] nums)
        {
            Nums = nums ?? [];
        }

        public int SumRange(int left, int right)
        {
            // Can be improved
            
            if (right < left ||
                left < 0 ||
                right < 0 ||
                left > Nums.Length - 1 ||
                right > Nums.Length - 1)
            {
                return 0;
            }


            var sum = 0;
            for (int i = left; i <= right; i++)
            {
                sum += Nums[i];
            }

            return sum;
        }
    }
}
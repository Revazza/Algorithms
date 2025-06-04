    namespace Algorithms.Leetcode.Arrays;

    public class FindKThSmallesSubbaraySum
    {
        public int KthSmallestSubarraySum(int[] nums, int k)
        {
            // 2 -1  3  6
            var list = GenerateSubbarySums(nums);
            
            list.Sort();
            
            return list[k];
        }

        private List<int> GenerateSubbarySums(int[] nums)
        {
            var list = new List<int>();
            
            for (int i = 0; i < nums.Length; i++)
            {
                var sum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    sum += nums[j];
                    list.Add(sum);
                }
            }

            return list;
        }
    }
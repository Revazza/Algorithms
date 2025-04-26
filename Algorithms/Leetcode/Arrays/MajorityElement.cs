namespace Algorithms.DataStructures.Arrays;

public class MajorityElement
{
    public int Solve(int[] nums)
    {
        if (nums.Length == 0) return -1;

        var dict = new Dictionary<int, int>();
        var majorityCount = nums.Length / 2;
        for (var i = 0; i < nums.Length; i++)
            if (dict.TryGetValue(nums[i], out var value))
            {
                if (++value > majorityCount) return nums[i];

                dict[nums[i]] = value;
            }
            else
            {
                dict[nums[i]] = 1;
            }

        return nums[0];
    }

// Elegant solution (Moore Algorithm)
//     int count = 0;
//     int candidate = 0;
//         
//         for (int num : nums) {
//         if (count == 0) {
//             candidate = num;
//         }
//             
//         if (num == candidate) {
//             count++;
//         } else {
//             count--;
//         }
//     }
//         
//     return candidate;
}
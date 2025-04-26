namespace Algorithms.DataStructures.Arrays;

public class SummaryRanges
{
    public IList<string> Solve(int[] nums)
    {
        // Example 1:
        //
        // Input: nums = [0,1,2,4,5,7]
        // Output: ["0->2","4->5","7"]
        // Explanation: The ranges are:
        // [0,2] --> "0->2"
        // [4,5] --> "4->5"
        // [7,7] --> "7"
        // Example 2:
        //
        // Input: nums = [0,2,3,4,6,8,9]
        // Output: ["0","2->4","6","8->9"]
        // Explanation: The ranges are:
        // [0,0] --> "0"
        // [2,4] --> "2->4"
        // [6,6] --> "6"
        // [8,9] --> "8->9"

        if (nums.Length == 0) return [];

        var list = new List<string>();

        // 0, 2, 3, 4, 6, 8, 9, 10, 12
        var counter = 0;
        var tail = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            var curr = nums[i];
            var prev = nums[i - 1];
            var sub = curr - prev;
            if (sub == 1)
            {
                counter++;
                continue;
            }

            if (counter > 0)
            {
                list.Add($"{tail}->{prev}");
                tail = curr;
            }
            else
            {
                list.Add(tail.ToString());
                tail = curr;
            }

            counter = 0;
        }

        if (counter > 0) list.Add($"{tail}->{nums[^1]}");

        if (nums[^1] == tail) list.Add(tail.ToString());

        return list;
    }
}
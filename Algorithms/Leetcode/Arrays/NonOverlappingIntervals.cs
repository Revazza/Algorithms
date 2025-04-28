namespace Algorithms.Leetcode.Arrays;

public class NonOverlappingIntervals
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        var ans = int.MaxValue;
        for (int i = 0; i < intervals.Length; i++)
        {
            var cur = intervals[i];
            var overLaps = 0;
            var temp = new List<int[]> { cur };
            for (int k = 0; k < intervals.Length; k++)
            {
                if(i == k){
                    continue;
                }
                if (temp.Any(interval => DoesOverlap(interval, intervals[k])))
                {
                    overLaps++;
                    continue;
                }

                temp.Add(intervals[k]);
            }

            if (overLaps == 0)
            {
                continue;
            }

            if (overLaps == 8)
            {
                Console.WriteLine();
            }

            ans = Math.Min(overLaps, ans);
        }

        return ans == int.MaxValue ? 0 : ans;
    }

    private bool DoesOverlap(int[] interval1, int[] interval2)
        => interval1[0] < interval2[1] && interval2[0] < interval1[1];
}
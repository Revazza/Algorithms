namespace Algorithms.Leetcode.Arrays;

public class MergeIntervals
{
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        // [[1,3],[2,6],[5,10],[15,18], [16,20]]
        // [[1,6],]
        var result = new List<int[]>() { intervals[0] };
        var prev = result[^1];
        for (int i = 1; i < intervals.Length; i++)
        {
            var current = intervals[i];

            if (DoesOverlap(prev, current))
            {
                result[^1] = GetMergedInterval(prev, current);
                prev = result[^1];
                continue;
            }
            
            result.Add(current);
            prev = current;
        }

        return result.ToArray();
    }

    public int[] GetMergedInterval(int[] first, int[] second)
    {
        var min = Math.Min(first[0], second[0]);
        var max = Math.Max(first[1], second[1]);
        return [min, max];
    }

    public bool DoesOverlap(int[] a, int[] b)
        => a[0] <= b[1] && b[0] <= a[1];
}
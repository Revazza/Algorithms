namespace Algorithms.Leetcode.Arrays;

public class InsertInterval
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        if (intervals.Length == 0)
        {
            return [newInterval];
        }

        var result = new List<int[]>();
        for (int i = 0; i < intervals.Length; i++)
        {
            var current = intervals[i];
            if (newInterval == null || !DoesOverlap(newInterval, current))
            {
                if (newInterval != null && ShouldInsert(current, newInterval))
                {
                    result.Add(newInterval);
                    result.Add(current);
                    newInterval = null;
                }
                else
                {
                    result.Add(current);
                }
                continue;
            }

            var merged = MergeIntervals(i, intervals, newInterval);
            newInterval = null;
            result.Add(merged.Merged);
            i = merged.Index;
        }

        return result.ToArray();
    }

    private bool ShouldInsert(int[] current, int[] newInterval)
        => newInterval[0] < current[0] && newInterval[1] < current[1];

    private (int[] Merged, int Index) MergeIntervals(int i, int[][] intervals, int[] newInterval)
    {
        // Input: intervals = [[1,3],[6,9]], newInterval = [2,5]

        var merged = newInterval;
        while (i < intervals.Length)
        {
            if (DoesOverlap(intervals[i], merged))
            {
                merged = Merge(intervals[i], merged);
                i++;
                continue;
            }

            i--;
            break;
        }

        return (merged, i);
    }

    private bool DoesOverlap(int[] prev, int[] current)
    {
        return prev[0] <= current[1] && current[0] <= prev[1];
    }

    private int[] Merge(int[] first, int[] second)
    {
        var min = first[0] > second[0] ? second[0] : first[0];

        var max = first[1] > second[1] ? first[1] : second[1];
        return new int[] { min, max };
    }
}
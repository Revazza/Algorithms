namespace Algorithms.Leetcode.Intervals;

public class MinimumNumberOfArrowsToBurstBalloons
{
    public int FindMinArrowShots(int[][] points) {
        Array.Sort(points, (a, b) => a[0].CompareTo(b[0]));

        if(points.Length == 1){
            return 1;
        }

        var arrows = points.Length;
        var interval = points[0];

        for(int i = 1; i < points.Length; i++){
            if(DoesOverlap(points[i], interval)){
                interval = Merge(points[i], interval);
                arrows--;
                continue;
            }
            interval = points[i];
        }

        return arrows;
    }

    private int[] Merge(int[] first, int[] second){
        return [Math.Max(first[0], second[0]), Math.Min(first[1], second[1])];
    }

    private bool DoesOverlap(int[] first, int[] second){
        return first[0] <= second[1] && second[0] <= first[1];
    }
}
namespace Algorithms.Leetcode.Arrays;

public class TrappingRainWaterOptimized
{
    public int Trap(int[] height)
    {
        var leftHeights = new int[height.Length];

        for (var i = 1; i < height.Length; i++)
        {
            leftHeights[i] = Math.Max(height[i - 1], leftHeights[i - 1]);
        }

        var rightHeights = new int[height.Length];

        for (var i = height.Length - 2; i >= 0; i--)
        {
            rightHeights[i] = Math.Max(height[i + 1], rightHeights[i + 1]);
        }

        var total = 0;

        for (var i = 0; i < height.Length; i++)
        {
            var sub = Math.Min(leftHeights[i], rightHeights[i]) - height[i];
            if (sub > 0)
            {
                total += sub;
            }
        }

        return total;
    }
}
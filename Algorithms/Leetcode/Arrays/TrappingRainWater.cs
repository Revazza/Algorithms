namespace Algorithms.Leetcode.Arrays;

public class TrappingRainWater
{
    public int Trap(int[] height)
    {
        // width = tallHeighIndex - smallHeigth - 1;
        var result = 0;
        while (true)
        {
            var total = CalculateTotal(height);
            if (total == -1)
            {
                return result;
            }

            result += total;
        }

        return result;
    }

    private int CalculateTotal(int[] height)
    {
        var i = 0;
        while (i < height.Length)
        {
            if (height[i] == 0)
            {
                i++;
                continue;
            }

            break;
        }

        if (i + 1 >= height.Length)
        {
            return -1;
        }

        var total = 0;
        var blockIndex = -1;
        for (; i < height.Length; i++)
        {
            if (height[i] == 0)
            {
                continue;
            }

            if (blockIndex == -1)
            {
                blockIndex = i;
                continue;
            }

            total += i - blockIndex - 1;
            height[blockIndex]--;
            blockIndex = i;
        }

        if (blockIndex != -1)
        {
            height[blockIndex]--;
        }
        return total;
    }
}
namespace Algorithms.Leetcode.Arrays;

public class UniquePaths
{
    public int Solve(int m, int n)
    {
        var matrix = new int[m][];
        for (var i = 0; i < m; i++)
        {
            matrix[i] = new int[n];
        }

        var cache = new Dictionary<(int Row, int Col), int>();
        return CountPaths(0, 0, matrix, cache);
    }
    // col = 4
    // row = 2
    // 0 0 0 0
    // 0 0 0 1

    private int CountPaths(int row, int col, int[][] matrix, Dictionary<(int Row, int Col), int> cache)
    {
        if (cache.ContainsKey((row,col)))
        {
            return cache[(row, col)];
        }
        if (row == matrix.Length - 1 && col == matrix[0].Length - 1)
        {
            return 1;
        }

        if (row >= matrix.Length || col >= matrix[0].Length)
        {
            return 0;
        }

        var ways = CountPaths(row + 1, col, matrix, cache) + CountPaths(row, col + 1, matrix,cache);
        cache[(row, col)] = ways;
        return ways;
    }
}
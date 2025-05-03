namespace Algorithms.Leetcode.Graphs;

public class NumberOfIslands
{
    // Input: grid = 
    // ['1', '1', '1', '1', '0'],
    // ['1', '1', '0', '1', '0'],
    // ['1', '1', '0', '0', '0'],
    // ['0', '0', '0', '0', '0']

    public int NumIslands(char[][] grid)
    {
        var hashSet = new HashSet<(int Row, int Col)>();
        var count = 0;
        for (int row = 0; row < grid.Length; row++)
        {
            for (int col = 0; col < grid[row].Length; col++)
            {
                if (grid[row][col] == '1' && !hashSet.Contains((row, col)))
                {
                    Bfs(row, col, grid, hashSet);
                    count++;
                }
            }
        }

        return count;
    }

    private void Bfs(int row, int col, char[][] grid, HashSet<(int Row, int Col)> hashSet)
    {
        var maxRow = grid.Length - 1;
        var maxCol = grid[0].Length - 1;

        var queue = new Queue<(int Row, int Col)>();
        queue.Enqueue((row, col));
        while (queue.Count != 0)
        {
            var (currRow, currCol) = queue.Dequeue();
            if (!hashSet.Add((currRow, currCol)))
            {
                continue;
            }

            // Search Left
            if (currCol - 1 >= 0 && grid[currRow][currCol - 1] == '1')
            {
                queue.Enqueue((currRow, currCol - 1));
            }

            // Search Top
            if (currRow - 1 >= 0 && grid[currRow - 1][currCol] == '1')
            {
                queue.Enqueue((currRow - 1, currCol));
            }

            // Search Bottom
            if (currRow + 1 <= maxRow && grid[currRow + 1][currCol] == '1')
            {
                queue.Enqueue((currRow + 1, currCol));
            }

            // Search Right
            if (currCol + 1 <= maxCol && grid[currRow][currCol + 1] == '1')
            {
                queue.Enqueue((currRow, currCol + 1));
            }
        }
    }
}
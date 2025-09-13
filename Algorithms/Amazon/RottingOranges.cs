namespace Algorithms.Amazon;

public class RottingOranges
{
    public int OrangesRotting(int[][] grid)
    {
        // if orange is fresh and has no adjecent return - 1
        // if orange  

        var rottenOranges = new HashSet<(int row, int col)>();
        var orangesCount = 0;
        for (int row = 0; row < grid.Length; row++)
        {
            for (int col = 0; col < grid[row].Length; col++)
            {
                if (grid[row][col] != 0)
                {
                    orangesCount++;
                }

                if (grid[row][col] == 2)
                {
                    rottenOranges.Add((row, col));
                }
            }
        }

        return CalculateRottingMinutes(rottenOranges, orangesCount, grid);
    }

    public int CalculateRottingMinutes(
        HashSet<(int row, int col)> rottenOranges,
        int orangesCount,
        int[][] grid)
    {
        var currentOranges = rottenOranges.Count;

        var queue = new Queue<(int row, int col, int minutes)>();
        var visited = new HashSet<(int row, int col)>();
        foreach (var (row, col) in rottenOranges)
        {
            queue.Enqueue((row, col, 0));
            visited.Add((row, col));
        }

        var neededMinutes = 0;
        while (queue.Count != 0)
        {
            var (row, col, minutes) = queue.Dequeue();
            neededMinutes = Math.Max(neededMinutes, minutes);

            if (row - 1 >= 0 && !visited.Contains((row - 1, col)) && grid[row - 1][col] != 0)
            {
                queue.Enqueue((row - 1, col, minutes + 1));
                visited.Add((row - 1, col));
                currentOranges++;
            }

            if (row + 1 < grid.Length && !visited.Contains((row + 1, col)) && grid[row + 1][col] != 0)
            {
                queue.Enqueue((row + 1, col, minutes + 1));
                visited.Add((row + 1, col));
                currentOranges++;
            }

            if (col + 1 < grid[row].Length && !visited.Contains((row, col + 1)) && grid[row][col + 1] != 0)
            {
                queue.Enqueue((row, col + 1, minutes + 1));
                visited.Add((row, col + 1));
                currentOranges++;
            }

            if (col - 1 >= 0 && !visited.Contains((row, col - 1)) && grid[row][col - 1] != 0)
            {
                queue.Enqueue((row, col - 1, minutes + 1));
                visited.Add((row, col - 1));
                currentOranges++;
            }
        }

        if (currentOranges != orangesCount)
        {
            return -1;
        }

        return neededMinutes;
    }
}
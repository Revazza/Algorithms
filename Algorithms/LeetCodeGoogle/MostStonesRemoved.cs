namespace Algorithms.LeetCodeGoogle;

public class MostStonesRemoved
{
    public int RemoveStones(int[][] stones)
    {
        // Input: stones = [[0,0],[0,1],[1,0],[1,2],[2,1],[2,2]]
        // Output: 5
        // Explanation: One way to remove 5 stones is as follows:
        // 1. Remove stone [2,2] because it shares the same row as [2,1].
        // 2. Remove stone [2,1] because it shares the same column as [0,1].
        // 3. Remove stone [1,2] because it shares the same row as [1,0].
        // 4. Remove stone [1,0] because it shares the same column as [0,0].
        // 5. Remove stone [0,1] because it shares the same row as [0,0].
        // Stone [0,0] cannot be removed since it does not share a row/column
        // with another stone still on the plane.

        // rows
        // (0, 0) - [(0, 1), (1, 0)]
        // (0, 1) - [(0, 0)]
        // (1, 0) - [(0, 0), (2, 0)]
        // (1, 2) - []

        var points = stones.Select(stone => (stone[0], stone[1])).ToHashSet();
        var graph = GenerateGraph(stones, points);

        var length = 0;
        foreach (var ((row, col), _) in graph)
        {
            length = Math.Max(CalculateRemovedStones(row, col, graph, []), length);
        }

        return length;
    }

    private int CalculateRemovedStones(
        int row,
        int col,
        Dictionary<(int, int), List<(int, int)>> graph,
        HashSet<(int, int)> visited)
    {
        visited.Add((row, col));

        var neighbors = graph[(row, col)];
        var removed = 0;

        foreach (var (nRow, nCol) in neighbors)
        {
            if (visited.Contains((nRow, nCol)))
            {
                continue;
            }
            removed += CalculateRemovedStones(nRow, nCol, graph, visited);
            removed++;
        }

        return removed + 1;
    }

    private Dictionary<(int, int), List<(int, int)>> GenerateGraph(int[][] stones, HashSet<(int, int)> points)
    {
        var graph = new Dictionary<(int, int), List<(int, int)>>();

        foreach (var point in stones)
        {
            var row = point[0];
            var col = point[1];

            var neig = new List<(int, int)>();
            if (points.Contains((row - 1, col)))
            {
                neig.Add((row - 1, col));
            }

            if (points.Contains((row + 1, col)))
            {
                neig.Add((row + 1, col));
            }

            if (points.Contains((row, col - 1)))
            {
                neig.Add((row, col - 1));
            }

            if (points.Contains((row, col + 1)))
            {
                neig.Add((row, col + 1));
            }

            graph[(row, col)] = neig;
        }

        return graph;
    }
}
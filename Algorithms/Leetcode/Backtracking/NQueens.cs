namespace Algorithms.Leetcode.Backtracking;

public class NQueens
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        var result = new List<IList<string>>();

        FindSolution(n, [], [], result);

        return result;
    }

    private void FindSolution(
        int n,
        List<(int Row, int Col)> queenPos,
        HashSet<(int Row, int Col)> occupied,
        IList<IList<string>> result)
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (occupied.Contains((row, col)))
                {
                    continue;
                }

                var occupiedCopy = occupied.ToHashSet();
                var queenCopy = queenPos.ToList();
                
                queenCopy.Add((row, col));
                occupiedCopy.Add((row, col));
                
                FillOccupied(row, col, n, occupiedCopy);
                FindSolution(n, queenCopy, occupiedCopy, result);
            }
        }

        if (queenPos.Count == n)
        {
            result.Add(GenerateBoard(queenPos, n));
            return;
        }

        return;
    }

    private List<string> GenerateBoard(List<(int Row, int Col)> queens, int n)
    {
        var board = new List<string>();

        for (int row = 0; row < n; row++)
        {
            var str = "";
            for (int col = 0; col < n; col++)
            {
                if (!queens.Contains((row, col)))
                {
                    str += ".";
                    continue;
                }

                str += "Q";
            }

            board.Add(str);
        }

        return board;
    }

    private void FillOccupied(
        int row,
        int col,
        int n,
        HashSet<(int Row, int Col)> occupied)
    {
        // Fill horizontal
        var tempCol = 0;
        while (tempCol < n)
        {
            occupied.Add((row, tempCol));
            tempCol++;
        }

        // Fill vertical
        var tempRow = 0;
        while (tempRow < n)
        {
            occupied.Add((tempRow, col));
            tempRow++;
        }

        // Fill left-top diagonal

        tempRow = row;
        tempCol = col;

        while (tempRow >= 0 && tempCol >= 0)
        {
            occupied.Add((tempRow, tempCol));
            tempRow--;
            tempCol--;
        }

        // Fill right-bottom diagonal
        tempRow = row;
        tempCol = col;

        while (tempRow < n && tempCol < n)
        {
            occupied.Add((tempRow, tempCol));
            tempRow++;
            tempCol++;
        }

        // Fill left-bottom diagonal
        tempRow = row;
        tempCol = col;

        while (tempRow < n && tempCol >= 0)
        {
            occupied.Add((tempRow, tempCol));
            tempRow++;
            tempCol--;
        }

        // Fill right-top diagonal
        tempRow = row;
        tempCol = col;

        while (tempRow >= 0 && tempCol < n)
        {
            occupied.Add((tempRow, tempCol));
            tempRow--;
            tempCol++;
        }
    }
}
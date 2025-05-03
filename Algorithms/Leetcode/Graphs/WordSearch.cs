namespace Algorithms.Leetcode.Graphs;

public class WordSearch
{
    public bool Exist(char[][] board, string word)
    {
        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[row].Length; col++)
            {
                if (word.Contains(board[row][col]))
                {
                    if (DoesExist(row, col, word, board))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private bool DoesExist(int row, int col, string word, char[][] board)
    {
        var maxRow = board.Length - 1;
        var maxCol = board[0].Length - 1;
        var visited = new List<(int Row, int Col, int WordIndex)>();
        var stack = new Stack<(int Row, int Col, int WordIndex)>();
        stack.Push((row, col, 0));

        while (stack.Count != 0)
        {
            var (currRow, currCol, wordIndex) = stack.Pop();

            if (wordIndex > word.Length - 1)
            {
                continue;
            }

            if (board[currRow][currCol] != word[wordIndex])
            {
                continue;
            }

            visited.RemoveAll(x => x.WordIndex >= wordIndex);

            if (visited.Exists(x => x.Row == currRow && x.Col == currCol))
            {
                continue;
            }

            if (wordIndex == word.Length - 1)
            {
                return true;
            }

            visited.Add((currRow, currCol, wordIndex));
            // Search Top
            if (currRow - 1 >= 0)
            {
                stack.Push((currRow - 1, currCol, wordIndex + 1));
            }

            // Search Left
            if (currCol - 1 >= 0)
            {
                stack.Push((currRow, currCol - 1, wordIndex + 1));
            }

            // Search Right
            if (currCol + 1 <= maxCol)
            {
                stack.Push((currRow, currCol + 1, wordIndex + 1));
            }

            // Search Bottom
            if (currRow + 1 <= maxRow)
            {
                stack.Push((currRow + 1, currCol, wordIndex + 1));
            }
        }

        return false;
    }
}
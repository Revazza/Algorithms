namespace Algorithms.Leetcode.Arrays;

public class DiagonalTraverse
{
    public int[] FindDiagonalOrder(int[][] matrix)
    {
        var list = new List<int>();

        var row = matrix.Length;
        var col = matrix[0].Length;
        var currCol = 0;
        var currRow = 0;
        var isGoingUp = true;
        // * * * *
        // 1 2 3
        // 4 5 6
        // 7 8 9
        // 
        
        // * * * * *
        // a b c d
        // e f g h
        // i j k l
        // m n o p

        while (currCol < col && currRow < row)
        {
            if (isGoingUp)
            {
                while (currRow >= 0 && currCol < col)
                {
                    list.Add(matrix[currRow][currCol]);
                    currRow--;
                    currCol++;
                }

                if (currCol == col)
                {
                    currCol--;
                    currRow += 2;
                }
                else
                {
                    currRow++;
                }

                isGoingUp = false;
            }
            else
            {
                while (currCol >= 0 && currRow < row)
                {
                    list.Add(matrix[currRow][currCol]);
                    currRow++;
                    currCol--;
                }

                if (currRow == row)
                {
                    currRow--;
                    currCol += 2;
                }
                else
                {
                    currCol++;
                }

                isGoingUp = true;
            }
        }

        return list.ToArray();
    }
}
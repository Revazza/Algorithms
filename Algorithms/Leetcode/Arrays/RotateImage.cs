using Algorithms.Extensions;

namespace Algorithms.Leetcode.Arrays;

public class RotateImage
{
    public void Rotate(int[][] matrix)
    {
        var left = 0;
        var right = matrix.Length - 1;
        var top = 0;
        var bottom = matrix[0].Length - 1;
        if (left > right)
        {
            return;
        }
        
        //   L   R
        // T 1 2 3      7 4 1
        //   4 5 6  ->  8 5 2
        // B 7 8 9      9 6 3
        //

        while (left < right && top < bottom)
        {
            matrix.DisplayTwoDimension();

            for (var i = 0; i < right - left; i++)
            {
                var temp = matrix[top][left + i];
                matrix[top][left + i] = matrix[bottom - i][left];
                
                matrix[bottom - i][left] = matrix[bottom][right - i];
                
                matrix[bottom][right - i] = matrix[top + i][right];
                
                matrix[top + i][right] = temp;
            }
            matrix.DisplayTwoDimension();
            top++;
            left++;
            right--;
            bottom--;
            Console.WriteLine();
        }
        
    }
}
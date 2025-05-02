namespace Algorithms.Leetcode.Arrays;

public class SpiralMatrix
{
    public IList<int> SpiralOrder(int[][] matrix) {

        if (matrix.Length == 1)
        {
            return matrix[0].ToList();
        }
        var result = new List<int>();

        var left = 0;
        var right = matrix[0].Length - 1;
        var top = 0;
        var bottom = matrix.Length - 1;
        
        while(left <= right && top <= bottom){

            for(int i = left; i <= right; i++){
                result.Add(matrix[top][i]);
            }

            top++;

            for(int i = top; i <= bottom; i++){
                result.Add(matrix[i][right]);
            }

            right--;

            if (top <= bottom)
            {
                for(int i = right; i >= left; i--){
                    result.Add(matrix[bottom][i]);
                }    
                bottom--;
            }

            if (left <= right)
            {
                for (int i = bottom; i >= top; i--) {
                    result.Add(matrix[i][left]);
                }
                left++;   
            }
        }

        return result;
    }
}
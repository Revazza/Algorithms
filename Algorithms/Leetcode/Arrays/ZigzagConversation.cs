namespace Algorithms.Leetcode.Arrays;

public class ZigzagConversation
{
    public string Convert(string str, int numRows)
    {
        var matrix = new List<List<char>>();

        var drawingCol = true;
        for (int i = 0; i < str.Length; i++)
        {

            if (drawingCol)
            {
                matrix.Add(DrawCol(ref i, str, numRows));
                drawingCol = false;
                i--;
            }
            else
            {
                matrix.AddRange(DrawZigZag(ref i, str, numRows));
                drawingCol = true;
                i--;
            }
        }

        var ans = "";

        for (int col = 0; col < matrix[0].Count; col++)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                if (matrix[row][col] == ' ')
                {
                    continue;
                }
                ans += matrix[row][col];
            }
        }

        return ans;
    }

    private List<List<char>> DrawZigZag(ref int i, string str, int numRows)
    {
        var result = new List<List<char>>();
        var startIndex = numRows - 2;

        while (startIndex > 0)
        {
            var chars = Enumerable.Repeat(' ', numRows).ToList();
            chars[startIndex] = str[i];
            i++;
            startIndex--;
            result.Add(chars);
        }

        return result;
    }

    private List<char> DrawCol(ref int i, string str, int numRows)
    {
        var count = 0;
        var chars = Enumerable.Repeat(' ', numRows).ToList();
        var index = 0;
        while (i < str.Length && count < numRows)
        {
            chars[index] = str[i];
            index++;
            i++;
            count++;
        }

        return chars;
    }
}
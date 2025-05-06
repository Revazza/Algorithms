namespace Algorithms.Leetcode.Arrays;

public class ZigzagConversation
{
    public string Convert(string str, int numRows)
    {
        if(numRows == 1){
            return str;
        }
        // first & last row = i + (numRows - 1) * 2;
        var ans = "";
        var increment = (numRows - 1) * 2;
        for(int r = 0; r < numRows; r++){

            for(int i = r; i < str.Length; i+= increment){
                ans+= str[i];

                if(r > 0 && r < numRows - 1){
                    var diagonalIndex = i + increment - 2 * r;
                    if(diagonalIndex < str.Length){
                        ans+= str[diagonalIndex];
                    }
                }
            }
        }

        return ans;
        // numRows = 5
        // i + 4
        // i + 3
        // i + 2
    }

    // P     I     N
    // A   L S   I G
    // Y  A  H  R
    // P B   I B
    // Z     G  
}
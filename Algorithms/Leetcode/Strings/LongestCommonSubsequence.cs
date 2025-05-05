namespace Algorithms.DataStructures.Strings;

public class LongestCommonSubsequence
{
    public int Solve(string text1, string text2)
    {
        // a b c d e
        // a e c
        // a c
        // a e
        // e c

        // f c d a 
        // [f] c d a
        // f [c] d a
        // f c [d] a
        // f c d [a]

        // c d a
        // [c] d a
        // c [d] a
        // c d [a]

        var dp = GenerateDp(text1, text2);

        for (int row = 0; row < dp.Length; row++)
        {
            for (int col = 0; col < dp[row].Length; col++)
            {
                if (text1[row] == text2[col])
                {
                    if (col - 1 < 0 || row - 1 < 0)
                    {
                        dp[row][col] = 1;
                    }
                    else
                    {
                        dp[row][col] = 1 + dp[row - 1][col - 1];
                    }
                }
                else
                {
                    var top = row > 0 ? dp[row - 1][col] : 0;
                    var left = col > 0 ? dp[row][col - 1] : 0;
                    dp[row][col] = Math.Max(top, left);
                }
            }
        }
        
        return dp[dp.Length - 1][dp[0].Length - 1];
    }

    private int[][] GenerateDp(string text1, string text2)
    {
        var dp = new int[text1.Length][];

        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[text2.Length];
        }

        return dp;
    }

}
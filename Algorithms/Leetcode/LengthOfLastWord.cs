namespace Algorithms.Leetcode;

public class LengthOfLastWord
{
    public int Solve(string s)
    {
        var str = s.Trim();

        var subStr = "";
        for (int i = str.Length - 1; i >= 0; i--)
        {
            if (str[i] == ' ')
            {
                Console.WriteLine("Answer is : " + subStr.Length);
                return subStr.Length;
            }
            subStr += str[i];
        }
        
        return str.Length;
    }
}
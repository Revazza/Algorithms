namespace Algorithms.DataStructures.Strings;

public class LengthOfLastWord
{
    public int Solve(string str) {
        return str.Trim().Split(" ").Last().Length;
    }
}
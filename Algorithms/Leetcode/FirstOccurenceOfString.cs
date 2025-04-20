namespace Algorithms.Leetcode;

public class FirstOccurenceOfString
{
    public int Solve(string haystack, string needle)
    {
        if (needle.Length > haystack.Length)
        {
            return -1;
        }

        for (int i = 0; i <= haystack.Length - needle.Length; i++)
        {
            var subString = haystack.Substring(i, needle.Length);
            if (subString == needle)
            {
                return i;
            }
        }
        
        return -1;
    }
}
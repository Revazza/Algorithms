namespace Algorithms.DataStructures.Strings;

public class PalindromicSubstrings
{
    public int Solve(string str)
    {
        if (str.Length == 1)
        {
            return 1;
        }
        return CountPalRecursion(0, str.Length - 1, str);
    }

    public int CountPalRecursion(int left, int right, string str)
    {
        if (left > right)
        {
            return 0;
        }

        var count = CountPal(left, right, str);

        return count + CountPalRecursion(left + 1, right, str) +
               CountPalRecursion(left, right - 1, str);
    }

    public int CountPal(int left, int right, string str)
    {
        while (left < right)
        {
            if (str[left] != str[right])
            {
                return 0;
            }

            left++;
            right--;
        }

        return 1;
    }
}
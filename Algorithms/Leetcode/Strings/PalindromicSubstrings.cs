namespace Algorithms.DataStructures.Strings;

public class PalindromicSubstrings
{
    public int Solve(string str)
    {
        if (str.Length == 1)
        {
            return 1;
        }

        var hashSet = new HashSet<(int Left, int Right)>();

        return CountPalRecursion(0, str.Length - 1, str,hashSet) + str.Length;
    }

    public int CountPalRecursion(int left, int right, string str, HashSet<(int Left, int Right)> hashSet)
    {
        if (left >= right)
        {
            return 0;
        }

        var count = CountPal(left, right, str, hashSet);

        return count + CountPalRecursion(left + 1, right, str, hashSet) +
               CountPalRecursion(left, right - 1, str, hashSet);
    }

    public int CountPal(int left, int right, string str,HashSet<(int Left, int Right)> hashSet)
    {
        if (hashSet.Contains((left, right)))
        {
            return 0;
        }
        hashSet.Add((left, right));
        Console.WriteLine($"Before Reft: {left}, Right: {right}");
        while (left <= right)
        {
            if (str[left] != str[right])
            {
                hashSet.Remove((left, right));
                Console.WriteLine("Not good");
                Console.WriteLine();
                return 0;
            }

            left++;
            right--;
        }
        
        Console.WriteLine($"After Left: {left}, Right: {right}");

        return 1;
    }
}
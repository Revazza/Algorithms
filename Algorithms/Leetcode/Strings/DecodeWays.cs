namespace Algorithms.DataStructures.Strings;

public class DecodeWays
{
    public int NumDecodings(string s)
    {
        var cache = new Dictionary<int, int>();
        return CountDecode(0, s, cache);
    }

    private int CountDecode(int k, string str, Dictionary<int, int> cache)
    {
        if (k >= str.Length)
        {
            return 1;
        }

        if (str[k] == '0')
            return 0;

        if (cache.ContainsKey(k))
        {
            return cache[k];
        }

        // 121
        //           *
        //      1      12
        //    2   21^     1^ 
        //   1
        var ways = 0;

        var oneDigit = str.Substring(k, 1);
        if (IsValidASCII(oneDigit))
        {
            ways += CountDecode(k + 1, str, cache);
        }

        if (k + 1 < str.Length)
        {
            var twoDigits = str.Substring(k, 2);
            if (IsValidASCII(twoDigits))
            {
                ways += CountDecode(k + 2, str, cache);
            }
        }

        cache[k] = ways;
        return ways;
    }

    private bool IsValidASCII(string str)
    {
        if (int.TryParse(str, out var number))
        {
            return number >= 1 && number <= 26;
        }

        return false;
    }
}
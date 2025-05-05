namespace Algorithms.DataStructures.Strings;

public class RomanToInteger
{
    public int RomanToInt(string str)
    {
        var numerals = new Dictionary<string, int>()
        {
            { "I", 1 },
            { "IV", 4 },
            { "V", 5 },
            { "IX", 9 },
            { "X", 10 },
            { "XL", 40 },
            { "L", 50 },
            { "XC", 90 },
            { "C", 100 },
            { "CD", 400 },
            { "D", 500 },
            { "CM", 900 },
            { "M", 1000 },
        };
        
        if (str.Length == 1)
        {
            return numerals[str];
        }

        var ans = 0;
        
        // III
        for (int i = 0; i < str.Length; i++)
        {
            var sub = str.Substring(i, i + 1 == str.Length ? 1 : 2);
            
            if (numerals.TryGetValue(sub, out var numeral))
            {
                ans += numeral;
                i++;
                continue;
            }
            ans += numerals[sub[0].ToString()];
        }

        return ans;
    }
}
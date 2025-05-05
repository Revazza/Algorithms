namespace Algorithms.DataStructures.Strings;

public class IntegerToRoman
{
    public string IntToRoman(int num)
    {
        var numerals = new Dictionary<int, string>()
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" },
        };

        var ans = string.Empty;

        while (num > 0)
        {
            foreach (var numeral in numerals)
            {
                if (num - numeral.Key >= 0)
                {
                    ans += numeral.Value;
                    num -= numeral.Key;
                    break;
                }
            }
        }
        

        return ans;
    }
}
using System.Text;
using Algorithms.DataStructures.Arrays;
using Algorithms.DataStructures.Strings;
using Algorithms.Extensions;
using Algorithms.Leetcode;
using Algorithms.Leetcode.Arrays;
using Algorithms.Leetcode.Backtracking;

var dict = "".GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());

MinWindow("adc", "dcda");

string MinWindow(string str, string t)
{
    if(str.Length == t.Length){
        return str;
    }

    var sample = t
        .GroupBy(c => c)
        .ToDictionary(g => g.Key, g => g.Count());

    var window = new Dictionary<char, int>();
    var result = "";

    var left = 0;
    var right = 0;
        
    while (right < str.Length)
    {
        if (!window.TryAdd(str[right], 1))
            window[str[right]]++;

        while (IsMatching(sample, window))
        {
            if ((result.Length > right - left + 1) || result.Length == 0)
                result = str.Substring(left, right - left + 1);

            if (window.ContainsKey(str[left]))
            {
                window[str[left]]--;
                if (window[str[left]] == 0)
                    window.Remove(str[left]);
            }
            left++;
        }

        right++;
    }

    return result;
}
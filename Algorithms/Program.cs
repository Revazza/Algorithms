using System.Text;
using Algorithms.DataStructures.Arrays;
using Algorithms.DataStructures.Strings;
using Algorithms.Extensions;
using Algorithms.Leetcode.Arrays;

MinWindow("ADOBECODEBANC", "ABC").Dump();

string MinWindow(string str, string t)
{
    if (t.Length > str.Length)
    {
        return string.Empty;
    }

    if (t.Length == 1 && str.Contains(t))
    {
        return t;
    }

    var sample = t
        .GroupBy(c => c)
        .ToDictionary(c => c.Key, c => c.Count());

    var actual = new Dictionary<char, int>();

    var ans = "";
    var left = 0;

    for (int right = 0; right < str.Length; right++)
    {
        if (!actual.TryAdd(str[right], 1))
        {
            actual[str[right]]++;
        }

        if (!MeetsCondition(sample, actual))
        {
            continue;
        }

        while (MeetsCondition(sample, actual))
        {
            actual[str[left]]--;
            left++;
        }

        if (string.IsNullOrEmpty(ans) || right - left + 1 < ans.Length)
        {
            ans = str.Substring(left - 1, right - left + 2);
        }
    }

    return ans;
}

bool MeetsCondition(
    Dictionary<char, int> sample,
    Dictionary<char, int> actual)
{
    foreach (var kvp in sample)
    {
        if (!actual.TryGetValue(kvp.Key, out var actualCount) ||
            actualCount < kvp.Value)
        {
            return false;
        }
    }

    return true;
}
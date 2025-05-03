namespace Algorithms.DataStructures.Strings;

public class MinimumWindowSubstring
{
    public string MinWindow(string str, string t)
    {
        if (str.Length == 0)
        {
            return string.Empty;
        }

        var dict = new Dictionary<char, int>();
        foreach (var c in t)
        {
            if (!dict.TryAdd(c, 1))
            {
                dict[c]++;
            }
        }

        var frequency = new Dictionary<char, int>();
        var left = 0;
        var right = 0;
        var ans = string.Empty;
        // Input: s = "ADOBECODEBANC", t = "ABC"
        var isConditionMeet = IsConditionMeet(dict, frequency);
        while (left <= right && right <= str.Length)
        {
            if (isConditionMeet)
            {
                frequency[str[left]]--;
                left++;
            }
            else
            {
                if (right == str.Length)
                {
                    break;
                }
                
                if (!frequency.TryAdd(str[right], 1))
                {
                    frequency[str[right]]++;
                }

                right++;
            }

            if (IsConditionMeet(dict, frequency))
            {
                var sub = str.Substring(left, right - left);
                if (ans.Length == 0 || ans.Length > sub.Length)
                {
                    ans = sub;
                }
                isConditionMeet = true;
            }
            else
            {
                isConditionMeet = false;
            }
        }

        while (right - left > t.Length)
        {
            if (IsConditionMeet(dict, frequency))
            {
                var sub = str.Substring(left, right - left);
                if (ans.Length == 0 || ans.Length > sub.Length)
                {
                    ans = sub;
                }
            }
            else
            {
                if (frequency.ContainsKey(str[left]))
                {
                    frequency[str[left]]--;
                }
            }

            left++;
        }

        return ans;
    }

    private bool IsConditionMeet(Dictionary<char, int> dict, Dictionary<char, int> frequency)
    {
        if (dict.Count > frequency.Count)
        {
            return false;
        }
        
        foreach (var keyPair in dict)
        {
            if (!frequency.ContainsKey(keyPair.Key) ||
                frequency[keyPair.Key] < keyPair.Value)
            {
                return false;
            }
        }

        return true;
    }
}
namespace Algorithms.DataStructures.Strings;

public class MinimumWindowSubstring
{
    public string MinWindow(string str, string t) {
        if (str.Length == 0)
        {
            return string.Empty;
        }

        if (str.Length == 1)
        {
            return str == t ? str : string.Empty;
        }
        
        // Input: s = "ADOBECODEBANC", t = "ABC"
        // ADOB..BANC
        // Input: s = "ab", t = "b"
        // 

        var ans = string.Empty;
        
        for (int i = 0; i <= str.Length - t.Length; i++)
        {
            for (int k = 0; k < str.Length - t.Length - i + 1; k++)
            {
                var sub = str.Substring(i, t.Length + k);
                if (DoesContain(sub, t))
                {
                    if (ans.Length == 0 || sub.Length < ans.Length)
                    {
                        ans = sub;
                        break;
                    }
                }
            }
        }
        return ans;
    }

    private bool DoesContain(string str, string t)
    {
        var charCount = new Dictionary<char, int>();
        foreach (char c in t)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }
    
        foreach (char c in str)
        {
            if (charCount.ContainsKey(c) && charCount[c] > 0)
            {
                charCount[c]--;
            
                if (charCount.Values.All(count => count == 0))
                    return true;
            }
        }
    
        return false;
    }

}
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
        
        for (int i = 0; i < str.Length - t.Length; i++)
        {
            for (int k = 0; k < str.Length - t.Length - i + 1; k++)
            {
                var sub = str.Substring(i, t.Length + k);
                if (DoesContain(sub, t))
                {
                    if (ans.Length == 0 || sub.Length < ans.Length)
                    {
                        ans = sub;
                    }
                }
            }
        }
        return ans;
    }

    private bool DoesContain(string str, string t){
        foreach(var c in str){
            var index = t.IndexOf(c);
            if(index == -1){
                continue;
            }
            t = t.Remove(index, 1);
            if(t.Length == 0){
                return true;
            }
        }

        return false;
    }
}
namespace Algorithms.Leetcode.Arrays;

public class GroupAnagrams
{
    public IList<IList<string>> Solve(string[] strs)
    {
        var dict = new Dictionary<string, List<string>>();
        foreach (var str in strs)
        {
            var key = new string(str.OrderBy(c => c).ToArray());
            if (dict.ContainsKey(key))
            {
                dict[key].Add(str);
            }
            else
            {
                dict[key] = new List<string>() { str };
            }
        }

        return dict.Select(keyPar => keyPar.Value).Cast<IList<string>>().ToList();
    }
}
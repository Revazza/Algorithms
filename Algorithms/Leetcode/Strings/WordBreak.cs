namespace Algorithms.DataStructures.Strings;

public class WordBreak
{
    public bool Solve(string str, IList<string> words)
    {
        var dp = new Dictionary<int, bool>();
        return DoesBreak(0, str, words, dp);
    }

    private bool DoesBreak(int currentIndex, string str, IList<string> words, Dictionary<int, bool> dp)
    {
        if (str.Length == 0)
        {
            return true;
        }

        if (dp.ContainsKey(currentIndex))
        {
            return false;
        }

        foreach (var word in words)
        {
            if (!str.StartsWith(word))
            {
                continue;
            }

            if (DoesBreak(currentIndex + word.Length, str.Substring(word.Length), words, dp))
            {
                return true;
            }
        }

        dp.TryAdd(currentIndex, false);
        return false;
    }
}
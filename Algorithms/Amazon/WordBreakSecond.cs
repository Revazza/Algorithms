namespace Algorithms.Amazon;

public class WordBreakSecond
{
    public IList<string> WordBreak(string str, IList<string> wordDict)
    {
        var prefixes = new Dictionary<string, string>();
        prefixes.Add("", "");
        var result = new List<string>();
        AddBreakingWords("", str, wordDict.ToHashSet(), [], prefixes, result);
        return result;
    }

    private void AddBreakingWords(
        string prefix,
        string target,
        HashSet<string> words,
        HashSet<string> cache,
        Dictionary<string, string> prefixes,
        List<string> result)
    {
        if (cache.Contains(prefix))
        {
            return;
        }

        if (prefix == target)
        {
            result.Add(prefixes[prefix]);
            return;
        }

        if (prefix.Length >= target.Length || !target.StartsWith(prefix))
        {
            cache.Add(prefix);
            return;
        }

        foreach (var word in words)
        {
            var newPrefix = prefix + word;
            var prefixValue = prefixes[prefix];
            if (prefixValue.Length == 0)
            {
                prefixes.TryAdd(newPrefix, word);
            }
            else
            {
                prefixes.TryAdd(newPrefix, $"{prefixValue} {word}");
            }

            AddBreakingWords(newPrefix, target, words, cache, prefixes, result);
            prefixes.Remove(newPrefix);
        }
    }
}
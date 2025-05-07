namespace Algorithms.DataStructures.Strings;

public class SubstringWithConcatenationOfAllWords
{
    public IList<int> FindSubstring(string str, string[] words)
    {
        if (words.Length == 0 || str.Length == 0)
        {
            return [];
        }

        var wordLength = words[0].Length;
        var result = new List<int>();
        var maxLength = wordLength * words.Length;

        var dict = Populate(words);

        for (int i = 0; i <= str.Length - maxLength; i++)
        {
            var k = i;
            var copyDict = new Dictionary<string, int>(dict);
            var allMatched = true;
            while (k <= str.Length - wordLength && k <= k + maxLength)
            {
                var sub = str.Substring(k, wordLength);
                k += wordLength;

                if (!dict.TryGetValue(sub, out int count) || count == 0)
                {
                    allMatched = false;
                    break;
                }

                copyDict[sub]--;
            }

            if (allMatched)
            {
                result.Add(i);
            }
        }

        return result;
    }

    private Dictionary<string, int> Populate(string[] words)
    {
        var dict = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (!dict.TryAdd(word, 1))
            {
                dict[word]++;
            }
        }

        return dict;
    }
}
namespace Algorithms.DataStructures.Strings;

public class EditDistance
{
    public int MinDistance(string word, string target)
    {
        if (target.Length == 0)
        {
            return word.Length;
        }

        if (word.Length == 0)
        {
            return target.Length;
        }

        // horse
        // ros
        
        return CalcMin(0, 0, word, target, []);
    }

    private int CalcMin(
        int i, 
        int j, 
        string word, 
        string target,
        Dictionary<(int I, int J), int> cache)
    {
        if (cache.ContainsKey((i, j)))
        {
            return cache[(i, j)];
        }
        
        if (i == word.Length)
        {
            return target.Length - j;
        }

        if (j == target.Length)
        {
            return word.Length - i;
        }

        if (word[i] == target[j])
        {
            return CalcMin(i + 1, j + 1, word, target, cache);
        }
        
        var insert = CalcMin(i, j + 1, word, target, cache);
        var delete = CalcMin(i + 1, j, word, target, cache);
        var replace = CalcMin(i + 1, j + 1, word, target, cache);

        var min = Math.Min(insert, Math.Min(delete, replace));

        cache[(i, j)] = min + 1;
        return cache[(i, j)];
    }
}
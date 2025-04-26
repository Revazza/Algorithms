namespace Algorithms.DataStructures.Strings;

public class WordBreak
{
    public bool Solve(string str, IList<string> words)
    {
        Console.WriteLine("str: " + str);

        var hashSet = new HashSet<string>(words);

        return DoesBreak(str, hashSet);
    }

    private bool DoesBreak(string str, HashSet<string> words)
    {
        if (str.Length == 0)
        {
            return true;
        }

        for (int i = 1; i <= str.Length; i++)
        {
            if (words.Contains(str.Substring(0, i)) && DoesBreak(str.Substring(i),words))
            {
                return true;
            }
        }

        return false;
    }
}
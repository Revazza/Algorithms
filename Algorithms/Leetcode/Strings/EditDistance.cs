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

        return CalcMin(0, 0, word, target);
    }

    private int CalcMin(int k, int j, string word, string target)
    {
        if (word == target)
        {
            return 1;
        }

        if (j >= target.Length || k >= word.Length)
        {
            return int.MaxValue;
        }

        var result = int.MaxValue;
        for (int i = k; i < word.Length; i++)
        {
            if (word[i] == target[j])
            {
                j++;
                continue;
            }

            var insert = CalcMin(i, j + 1, word, target);
            var delete = CalcMin(i + 1, j, word, target);
            var replace = CalcMin(i + 1, j + 1, word, target);

            var min = Math.Min(insert, Math.Min(delete, replace));
            if (min != int.MaxValue)
            {
                result = Math.Min(result, min + 1);
            }
        }

        return result;
    }
}
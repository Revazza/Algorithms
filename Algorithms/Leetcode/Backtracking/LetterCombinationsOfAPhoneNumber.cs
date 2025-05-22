namespace Algorithms.Leetcode.Backtracking;

public class LetterCombinationsOfAPhoneNumber
{
    public IList<string> LetterCombinations(string digits)
    {
        var map = new Dictionary<char, List<string>>()
        {
            { '2', ["a", "b", "c"] },
            { '3', ["d", "e", "f"] },
            { '4', ["g", "h", "i"] },
            { '5', ["j", "k", "l"] },
            { '6', ["m", "n", "o"] },
            { '7', ["p", "q", "r", "s"] },
            { '8', ["t", "u", "v"] },
            { '9', ["w", "x", "y", "z"] }
        };

        return GetLetterCombinations(digits, map);
    }

    private List<string> GetLetterCombinations(
        string digits,
        Dictionary<char, List<string>> map)
    {
        if (digits.Length == 0)
        {
            return [];
        }

        if (digits.Length == 1)
        {
            return map[digits[0]];
        }

        var letters = map[digits[0]];
        var result = new List<string>();

        var combinations = GetLetterCombinations(digits.Substring(1), map);

        for (int i = 0; i < letters.Count; i++)
        {
            for (int k = 0; k < combinations.Count; k++)
            {
                result.Add(letters[i] + combinations[k]);
            }
        }

        return result;
    }
}
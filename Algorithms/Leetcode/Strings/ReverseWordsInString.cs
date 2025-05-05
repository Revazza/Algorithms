namespace Algorithms.DataStructures.Strings;

public class ReverseWordsInString
{
    public string ReverseWords(string str)
    {
        return str
            .Trim()
            .Split(' ')
            .Where(x => x != " " && x != "")
            .Reverse()
            .Aggregate((a, b) => a + " " + b);
    }
}
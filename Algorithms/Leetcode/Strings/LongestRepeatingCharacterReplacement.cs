namespace Algorithms.DataStructures.Strings;

public class LongestRepeatingCharacterReplacement
{
    public int CharacterReplacement(string str, int k)
    {
        // AABABBA
        // A  ans = 1
        // A A ans = 2
        // A A B ans = 3
        // A A B A ans = 4
        // A A B A B ans = 4 move left
        // [A] A B A B B ans = 4 move left
        // [A A] B A B B ans = 4 move left
        // [A A B] A B B A ans = 4
        //
        var left = 0;
        var right = 0;
        var dict = new Dictionary<char, int>();
        var ans = 0;
        while (left < str.Length && right < str.Length)
        {
            var letter = str[right];
            if (!dict.TryAdd(letter, 1))
            {
                dict[letter]++;
            }

            // right - left + 1 is sliding window length 
            while (right - left + 1 - dict.Max(x => x.Value) > k)
            {
                dict[str[left]]--;
                left++;
            }
            var windowsLength = right - left + 1;
            ans = Math.Max(ans, windowsLength);
            right++;
        }

        return ans;
    }
}
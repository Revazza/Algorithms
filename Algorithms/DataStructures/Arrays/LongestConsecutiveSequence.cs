namespace Algorithms.DataStructures.Arrays;

public class LongestConsecutiveSequence
{
    public int Solve(int[] nums)
    {
        var hashSet = new HashSet<int>(nums);

        var seq = 0;
        foreach (var num in hashSet)
        {
            if (hashSet.Contains(num - 1))
            {
                continue;
            }

            var start = num;
            var count = 1;
            while (true)
            {
                if (hashSet.Contains(start + 1))
                {
                    count++;
                    start++;
                    continue;
                }

                break;
            }

            seq = Math.Max(seq, count);
        }
        
        return seq;
    }
}
namespace Algorithms.DataStructures.Arrays;

public class TwoSum
{
    public int Solve(int[] arr, int k)
    {
        var low = 0;
        var missing = new List<int>();

        for (var i = 0; i < arr.Length; i++)
        {
            var high = arr[i];
            if (low + 1 == high)
            {
                low = high;
                continue;
            }

            while (low + 1 < high)
            {
                missing.Add(++low);
                if (k == missing.Count) return missing.Last();
            }

            low = high;
        }

        var sub = k - missing.Count;
        var ans = arr[arr.Length - 1];
        for (var i = 0; i < sub; i++) ans++;
        return ans;

        return -1;
    }
}
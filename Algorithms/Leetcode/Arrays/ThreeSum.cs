namespace Algorithms.DataStructures.Arrays;

public class ThreeSum
{
    public IList<IList<int>> Solve(int[] nums)
    {
        var i = 0;
        var j = 1;
        var left = 2;
        var right = nums.Length - 1;

        // -1, 0, 1, 2, -1, -4, 2, 3, -1

        var dict = new Dictionary<int, int>();
        var triplets = new List<IList<int>>();

        for (var index = 0; i < nums.Length - 2; index++)
        {
            i = index;
            j = index + 1;
            left = index + 2;
            right = nums.Length - 1;

            while (i < nums.Length - 2)
            {
                var sum = nums[i] + nums[j] + nums[left];

                if (sum == 0) InsertTriplet(dict, triplets, [nums[i], nums[j], nums[left]]);

                left++;

                if (left > nums.Length - 1)
                {
                    j++;
                    left = j + 1;
                }

                if (j > nums.Length - 2)
                {
                    i++;
                    j = i + 1;
                    left = i + 2;
                }
            }
        }

        return triplets;
    }

    private void InsertTriplet(Dictionary<int, int> dict, List<IList<int>> triplets, int[] triplet)
    {
        var hash = GetTripletHash(triplet);
        if (dict.TryAdd(hash, hash)) triplets.Add(triplet);
    }

    public static int GetTripletHash(int[] triplet)
    {
        Array.Sort(triplet);
        return HashCode.Combine(triplet[0], triplet[1], triplet[2]);
    }
}
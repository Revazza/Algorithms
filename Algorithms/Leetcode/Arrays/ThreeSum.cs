namespace Algorithms.DataStructures.Arrays;

public class ThreeSum
{
    public IList<IList<int>> Solve(int[] nums)
    {
        var triplets = new Dictionary<int, int[]>();
        Array.Sort(nums);

        // -1, 0, 1, 2, -1, -4
        // -4 -1 -1 0 1 2  

        for (int i = 0; i < nums.Length - 2; i++)
        {
            var left = i + 1;
            var right = nums.Length - 1;

            while (left < right)
            {
                var sum = nums[i] + nums[left] + nums[right];

                if (sum > 0)
                {
                    right--;
                }
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    InsertTriplet(triplets, [nums[i], nums[left], nums[right]]);
                    left++;
                    right--;
                }
            }
        }

        var listOfLists = triplets.Values
            .Select(arr => (IList<int>)arr.ToList())
            .ToList();
        return listOfLists;
    }

    private void InsertTriplet(Dictionary<int, int[]> dict, int[] triplet)
    {
        var hash = GetTripletHash(triplet);
        dict.TryAdd(hash, triplet);
    }

    public static int GetTripletHash(int[] triplet)
    {
        Array.Sort(triplet);
        return HashCode.Combine(triplet[0], triplet[1], triplet[2]);
    }
}
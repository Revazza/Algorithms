namespace Algorithms.Leetcode.Arrays;

public class TopKFrequentElements
{
    public int[] TopKFrequent(int[] nums, int k) {
        var dict = new Dictionary<int,int>();

        for(int i = 0; i < nums.Length; i++){
            if(dict.ContainsKey(nums[i])){
                dict[nums[i]]++;
                continue;
            }

            dict[nums[i]] = 1;
        }

        return dict
            .OrderByDescending(x => x.Value)
            .Take(2)
            .Select(x => x.Key)
            .ToArray();
    }
}
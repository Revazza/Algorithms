namespace Algorithms.DataStructures.Arrays;

public class IntersectOfTwoArraysSecond
{
    public int[] Solve(int[] n1, int[] n2)
    {
        var minArr = n1.Length > n2.Length ? n2 : n1;
        var dict = new Dictionary<int, int>();

        for (int i = 0; i < minArr.Length; i++)
        {
            if (dict.ContainsKey(minArr[i]))
            {
                dict[minArr[i]]++;
                continue;
            }

            dict[minArr[i]] = 1;
        }

        var maxArr = n1.Length > n2.Length ? n1 : n2;

        var count = 0;

        // nums1 = [1,2,2,1], nums2 = [2,2]
        foreach (var kp in dict)
        {
            for (int i = 0; i < maxArr.Length; i++)
            {
                var num = maxArr[i];
                if (kp.Key == num)
                {
                    count++;
                }
            }

            if (kp.Value > count)
            {
                dict[kp.Key] = count;
            }

            count = 0;
        }

        var list = new List<int>();

        foreach (var kp in dict)
        {
            for (int i = 0; i < kp.Value; i++)
            {
                list.Add(kp.Key);
            }
        }
        
        return list.ToArray();
    }
}
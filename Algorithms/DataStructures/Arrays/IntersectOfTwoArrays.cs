namespace Algorithms.DataStructures.Arrays;

public class IntersectOfTwoArrays
{
    public int[] Solve(int[] nums1, int[] nums2)
    {
        var list = new List<int>();

        var i = 0;
        var j = 0;

        while (true)
        {
            var num1 = -1;
            if (i < nums1.Length)
            {
                num1 = nums1[i];
            }

            var num2 = -1;
            if (j < nums2.Length)
            {
                num2 = nums2[j];
            }
            
            
            
        }
        
        return list.ToArray();
    }
}
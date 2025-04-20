namespace Algorithms.Leetcode;

public class MergeSortedArray
{
    public void Solve(int[] nums1, int m, int[] nums2, int n)
    {
        // Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
        // Output: [1,2,2,3,5,6]
        
        //              NOT MY ANSWER

        var i = m - 1;
        var j = n - 1;
        var k = m + n - 1;

        while (j >= 0)
        {
            if (i >= 0 && nums1[i] > nums2[j])
            {
                nums1[k--] = nums1[i--];
            }
            else
            {
                nums1[k--] = nums2[j--];
            }
        }

    }
}
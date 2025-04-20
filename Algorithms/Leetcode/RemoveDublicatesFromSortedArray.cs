namespace Algorithms.Leetcode;

public class RemoveDublicatesFromSortedArray
{
    public int Solve(int[] nums)
    {
        var tail = 1;

        Display(nums);

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                nums[tail] = nums[i];
                tail++;
            }
        }
        
        Display(nums);
        
        return tail;
    }

    private void Display(int[] arr)
    {
        foreach (var num in arr)
        {
            Console.Write($"{num},");
        }

        Console.WriteLine();
    }
}
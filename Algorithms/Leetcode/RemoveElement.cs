namespace Algorithms.Leetcode;

public class RemoveElement
{
    public int Solve(int[] nums, int value)
    {
        var tail = 0;
        var l = 0;
        var r = nums.Length - 1;
        Display(nums);

        while (l <= r)
        {
            Console.WriteLine("Tail before: " + tail);

            Console.WriteLine("Left: " + nums[l] + " l " + l);
            
            if (nums[l] != value)
            {
                nums[tail] = nums[l];
                tail++;
                l++;
                continue;
            }

            Console.WriteLine("Right: " + nums[r] + " r " + r);
            if (nums[r] != value)
            {
                nums[tail] = nums[r];
                tail++;
            }

            Console.WriteLine("Tail now: " + tail);
            l++;
            r--;
            Console.WriteLine();
        }


        Display(nums);
        Console.WriteLine("Tail: " + tail);

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
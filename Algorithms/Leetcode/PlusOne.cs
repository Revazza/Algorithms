namespace Algorithms.Leetcode;

public class PlusOne
{
    public int[] Solve(int[] digits)
    {
        if (digits.Length == 0)
        {
            return digits;
        }

        int[] arr;

        if (digits.All(digit => digit == 9))
        {
            arr = new int[digits.Length + 1];
        }
        else
        {
            arr = new int[digits.Length];
        }

        var carry = 1;
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            var num = digits[i] + carry;
            if (num > 9)
            {
                carry = num / 10;
                arr[i] = num % 10;
            }
            else
            {
                arr[i] = num;
                carry = 0;
            }
        }


        if (carry != 0)
        {
            arr[0] = carry;
        }
        Display(arr);
        return arr;
    }

    private void Display(int[] digits)
    {
        foreach (var digit in digits)
        {
            Console.Write($"{digit}, ");
        }

        Console.WriteLine();
    }
}
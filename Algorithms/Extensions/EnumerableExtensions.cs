namespace Algorithms.Extensions;

public static class EnumerableExtensions
{
    public static void Display<T>(this IEnumerable<T> enumerable)
    {
        Console.Write("[");
        foreach (var value in enumerable)
        {
            Console.Write($"{value}, ");
        }
        Console.Write("]");
        Console.WriteLine();
    }
}
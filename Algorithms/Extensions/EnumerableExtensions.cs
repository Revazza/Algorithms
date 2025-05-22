namespace Algorithms.Extensions;

public static class EnumerableExtensions
{
    public static void Display<T>(this IEnumerable<T> enumerable)
        => Console.WriteLine($"[ {string.Join(", ", enumerable)} ]");

    public static string DisplayAsString<T>(this IEnumerable<T> enumerable)
        => $"[ {string.Join(", ", enumerable)} ]";

    
    public static void DisplayTwoDimension<T>(this IEnumerable<IEnumerable<T>> enumerable)
    {
        foreach (var innerEnumerable in enumerable)
        {
            innerEnumerable.Display();
        }

        Console.WriteLine();
    }
}
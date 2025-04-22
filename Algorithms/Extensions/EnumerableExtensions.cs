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
    
    public static void DisplayTwoDimension<T>(this IEnumerable<IEnumerable<T>> enumerable)
    {
        foreach (var innerEnumerable in enumerable)
        {
            Console.Write("[");
            foreach (var innerValue in innerEnumerable)
            {
                Console.Write($"{innerValue}, ");
            }
            Console.Write("]");
            Console.WriteLine();
        }
        

        Console.WriteLine();
    }
}
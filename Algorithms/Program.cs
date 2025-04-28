using Algorithms.Leetcode.Arrays;

var problem = new CoinsChange();

Console.WriteLine(problem.Solve([186, 419, 83, 408], 6249));
Console.WriteLine(problem.Solve([1, 2, 5], 11));

var dp = new Dictionary<int, int>();
var ok = dp.Last().Value;
Console.WriteLine();


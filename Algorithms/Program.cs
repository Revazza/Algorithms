using Algorithms.DataStructures.Arrays;
using Algorithms.Extensions;

var problem = new MoveZeroes();
var arr = new int[] { 0, 1, 0, 3, 12 };
arr.Display();

problem.Solve(arr);
arr.Display();

Console.WriteLine();
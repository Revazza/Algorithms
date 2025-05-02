using Algorithms.DataStructures.Strings;
using Algorithms.Leetcode.Arrays;


var problem = new WordBreak();

Console.WriteLine(problem.Solve("catsandog", ["cats", "dog", "sand", "and", "cat"]));
Console.WriteLine(problem.Solve("ccbb", ["bc","cb"]));
Console.WriteLine(problem.Solve("leetcode", ["leet","code"]));
Console.WriteLine(problem.Solve("ddadddbdddadd", ["dd","ad","da","b"]));
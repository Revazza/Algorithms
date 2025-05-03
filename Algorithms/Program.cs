using System.Text.RegularExpressions;
using Algorithms.DataStructures.Arrays;
using Algorithms.DataStructures.Strings;
using Algorithms.Extensions;
using Algorithms.Leetcode.Arrays;
using Algorithms.Leetcode.Graphs;


var problem = new WordSearch();
problem.Exist([['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']], "ABCCED").Dump();
problem.Exist([['A', 'B'], ['C','D']], "ABCD").Dump();
problem.Exist([ ['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E'] ], "ABCB").Dump();
problem.Exist([ ['A', 'B', 'C', 'E'], ['S', 'F', 'E', 'S'], ['A', 'D', 'E', 'E'] ], "ABCESEEEFS").Dump();
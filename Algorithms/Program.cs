using Algorithms.Extensions;
using Algorithms.Leetcode.Graphs;


var problem = new CourseSchedule();
//
problem.CanFinish(5, [[0, 1], [0, 2], [1, 3], [1, 4], [3, 4]]).Dump();
problem.CanFinish(20, [[0, 10], [3, 18], [5, 5], [6, 11], [11, 14], [13, 1], [15, 1], [17, 4]]).Dump();
problem.CanFinish(20, [[5, 5],[0, 10], [3, 18], [6, 11], [11, 14], [13, 1], [15, 1], [17, 4]]).Dump();


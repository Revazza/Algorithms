using Algorithms.DataStructures.Trees;
using Algorithms.Leetcode;

var problem = new ConvertSortedArrayToBinarySearchTree();

var root = problem.SortedArrayToBST([0, 1, 2, 3, 4, 5]);

var bt = new BinarySearchTree();
bt.Root = root;
bt.Display();
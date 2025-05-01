using Algorithms.DataStructures.Graphs;
using Algorithms.DataStructures.LinkedLists;
using Algorithms.DataStructures.Trees;
using Algorithms.Leetcode;
using Algorithms.Leetcode.Arrays;
using Algorithms.Leetcode.LinkedLists;
using Microsoft.CSharp.RuntimeBinder;


var l1 = new SinglyLinkedList();
l1.InsertRange([1, 4, 5]);

var l2 = new SinglyLinkedList();
l2.InsertRange([0, 2]);

var problem = new MergeKSortedLists();

problem.MergeKLists([l1.Head, l2.Head]);
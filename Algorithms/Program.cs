using Algorithms.DataStructures;
using Algorithms.DataStructures.Trees;

var binarySearchTree = new BinarySearchTree();

binarySearchTree.Insert(7);
binarySearchTree.Insert(3);
binarySearchTree.Insert(2);
binarySearchTree.Insert(1);
binarySearchTree.Insert(11);
binarySearchTree.Insert(14);
binarySearchTree.Insert(5);
binarySearchTree.Insert(4);
binarySearchTree.Insert(6);
binarySearchTree.Insert(9);
binarySearchTree.Insert(8);
binarySearchTree.Insert(10);
binarySearchTree.Insert(12);
binarySearchTree.Insert(15);
binarySearchTree.Insert(13);
binarySearchTree.Display();

var node = binarySearchTree.Find(14);
binarySearchTree.FindRightMostMin(node);


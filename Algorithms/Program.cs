using Algorithms.DataStructures.Trees;

var binaryTree = new BinaryTree();
binaryTree.Insert(1);
binaryTree.Insert(2);
binaryTree.Insert(2);
binaryTree.Insert(3);
binaryTree.Insert(4);
binaryTree.Insert(4);
binaryTree.Insert(3);
binaryTree.Display();

var copy = binaryTree.Copy();

copy.Display();


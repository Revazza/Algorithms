using Algorithms.DataStructures.Trees;

var binaryTree = new BinaryTree();
binaryTree.Insert(1);
binaryTree.Insert(1);
binaryTree.Display();

var subTree = new BinaryTree();
subTree.Insert(1);

subTree.Display();

var ans = binaryTree.IsSubtree(binaryTree.FindWithBFS(1), subTree.FindWithBFS(1));

Console.WriteLine(ans);



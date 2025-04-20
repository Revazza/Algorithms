using Algorithms.Leetcode;

var problem = new MinimumAbsoluteDifferenceInBST();
var head = new TreeNode(1);
head.right = new TreeNode(2);
head.right.right = new TreeNode(3);
head.left = new TreeNode(4);
head.left.left = new TreeNode(5);
head.left.right = new TreeNode(6);
problem.Solve(head);
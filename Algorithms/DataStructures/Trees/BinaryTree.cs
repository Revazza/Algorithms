namespace Algorithms.DataStructures.Trees;

public class BinaryTree
{
    private TreeNode? Root { get; set; }

    /*
                   1
                /     \
              2         3
             / \       / \
            4   5     6   7
           / \
          8   9

    */

    public TreeNode InvertTree(TreeNode root) {
        
    }

    public void FindHeight(TreeNode? node)
    {
        if (node == null)
        {
            return;
        }

        var height = FindHeightRecursion(node);
        Console.WriteLine("Height: " + height);
    }

    public void Tilt()
    {
        if (Root == null)
        {
            return;
        }

        var sum = 0;
        TiltRecursive(Root, ref sum);
        Console.WriteLine("sum: " + sum);
    }

    private int TiltRecursive(TreeNode? node, ref int sum)
    {
        if (node == null)
        {
            return 0;
        }

        var leftValue = TiltRecursive(node.left, ref sum);
        var rightValue = TiltRecursive(node.right, ref sum);
        var currentValue = node.val;

        node.val = Math.Abs(leftValue - rightValue);
        sum += node.val;

        return leftValue + rightValue + currentValue;
    }

    private int FindHeightRecursion(TreeNode? node)
    {
        if (node == null)
        {
            return -1;
        }

        var leftHeight = FindHeightRecursion(node.left);
        var rightHeight = FindHeightRecursion(node.right);

        return Math.Max(leftHeight, rightHeight) + 1;
    }

    public void Remove(int value)
    {
        if (Root == null)
        {
            Console.WriteLine("Tree is empty");
            return;
        }

        var nodeToDelete = FindWithBFS(value);
        var rightMostNodeValue = FindDeepestRightMostValueAndDelete();

        nodeToDelete.val = rightMostNodeValue;
    }

    public void Insert(int value)
    {
        if (Root is null)
        {
            Root = new TreeNode(value);
            return;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.left == null)
            {
                current.left = new TreeNode(value);
                return;
            }
            else
            {
                queue.Enqueue(current.left);
            }

            if (current.right == null)
            {
                current.right = new TreeNode(value);
                return;
            }
            else
            {
                queue.Enqueue(current.right);
            }
        }
    }

    public TreeNode? FindWithDFS(int value)
    {
        if (Root == null)
        {
            return null;
        }

        var stack = new Stack<TreeNode>();
        stack.Push(Root);
        Console.Write("Searching with DFS: ");

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            Console.Write($"{current.val} -> ");
            if (current.val == value)
            {
                Console.WriteLine();
                Console.WriteLine($"Found value {value}");
                return current;
            }

            if (current.right != null)
            {
                stack.Push(current.right);
            }

            if (current.left != null)
            {
                stack.Push(current.left);
            }
        }

        Console.WriteLine();
        return null;
    }

    public TreeNode? FindWithBFS(int value)
    {
        if (Root == null)
        {
            return null;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current.val == value)
            {
                Console.WriteLine($"Found value {value}");
                return current;
            }

            if (current.left != null)
            {
                queue.Enqueue(current.left);
            }

            if (current.right != null)
            {
                queue.Enqueue(current.right);
            }
        }

        Console.WriteLine($"Couldn't find value {value}");
        return null;
    }

    private int FindDeepestRightMostValueAndDelete()
    {
        if (Root is null)
        {
            return -1;
        }

        var parent = Root;
        var currentNode = Root.right;
        while (currentNode?.right != null)
        {
            parent = currentNode;
            currentNode = currentNode.right;
        }

        var value = currentNode?.left?.val ?? currentNode?.val ?? -1;

        if (currentNode!.left != null)
        {
            Console.WriteLine($"Deepest rightmost LEFT node value {value}");
            currentNode.left = null;
            return value;
        }

        parent.right = null;
        Console.WriteLine($"Deepest rightmost node value {value}");

        return value;
    }

    public void RemoveAllNodes()
    {
        RemoveAllNodes(Root);
        Root = null;
    }

    private void RemoveAllNodes(TreeNode? node)
    {
        if (node == null)
        {
            return;
        }

        RemoveAllNodes(node.left);
        RemoveAllNodes(node.right);

        node.left = null;
        node.right = null;
    }

    public void DisplayPostOrder()
    {
        DisplayPostOrder(Root);
        Console.WriteLine();
    }

    private void DisplayPostOrder(TreeNode? node)
    {
        if (node == null)
        {
            return;
        }

        DisplayPostOrder(node.left);
        DisplayPostOrder(node.right);

        Console.Write(node.val + " ");
    }

    public void Display()
    {
        if (Root == null)
        {
            Console.WriteLine("Tree is empty");
            return;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            Console.Write(current.val + " ");

            if (current.left != null) queue.Enqueue(current.left);
            if (current.right != null) queue.Enqueue(current.right);
        }

        Console.WriteLine();
    }

    public void Initialize()
    {
        Insert(1);
        Insert(2);
        Insert(3);
        Insert(4);
        Insert(5);
        Insert(6);
        Insert(7);
        Insert(8);
        Insert(9);
    }

    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode? left { get; set; }
        public TreeNode? right { get; set; }

        public TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
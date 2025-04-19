namespace Algorithms.DataStructures.Trees;

public class BinaryTree
{
    private Node? Root { get; set; }

    /*
                   1
                /     \
              2         3
             / \       / \
            4   5     6   7
           / \
          8   9

    */

    public void Remove(int value)
    {
        if (Root == null)
        {
            Console.WriteLine("Tree is empty");
            return;
        }

        var nodeToDelete = FindWithBFS(value);
        var rightMostNodeValue = FindDeepestRightMostValueAndDelete();

        nodeToDelete.Value = rightMostNodeValue;
    }
    
    public void Insert(int value)
    {
        if (Root is null)
        {
            Root = new Node(value);
            return;
        }

        var queue = new Queue<Node>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.Left == null)
            {
                current.Left = new Node(value);
                return;
            }
            else
            {
                queue.Enqueue(current.Left);
            }

            if (current.Right == null)
            {
                current.Right = new Node(value);
                return;
            }
            else
            {
                queue.Enqueue(current.Right);
            }
        }
    }

    public Node? FindWithDFS(int value)
    {
        if (Root == null)
        {
            return null;
        }

        var stack = new Stack<Node>();
        stack.Push(Root);
        Console.Write("Searching with DFS: ");

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            Console.Write($"{current.Value} -> ");
            if (current.Value == value)
            {
                Console.WriteLine();
                Console.WriteLine($"Found value {value}");
                return current;
            }

            if (current.Right != null)
            {
                stack.Push(current.Right);
            }
            
            if (current.Left != null)
            {
                stack.Push(current.Left);
            }
        }

        Console.WriteLine();
        return null;
    }

    public Node? FindWithBFS(int value)
    {
        if (Root == null)
        {
            return null;
        }

        var queue = new Queue<Node>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            Console.WriteLine($"Current value {current.Value}");
            if (current.Value == value)
            {
                Console.WriteLine($"Found value {value}");
                return current;
            }

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }
            
            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
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
        var currentNode = Root.Right;
        while (currentNode?.Right != null)
        {
            parent = currentNode;
            currentNode = currentNode.Right;
        }

        var value = currentNode?.Left?.Value ?? currentNode?.Value ?? -1;
        
        if (currentNode!.Left != null)
        {
            Console.WriteLine($"Deepest rightmost LEFT node value {value}");
            currentNode.Left = null;
            return value;
        }
        
        parent.Right = null;
        Console.WriteLine($"Deepest rightmost node value {value}");

        return value;
    }

    public void Display()
    {
        if (Root == null) return;

        var queue = new Queue<Node>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            Console.Write(current.Value + " ");

            if (current.Left != null) queue.Enqueue(current.Left);
            if (current.Right != null) queue.Enqueue(current.Right);
        }

        Console.WriteLine();
    }
    
    public class Node
    {
        public int Value { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public Node(int value, Node? left = null, Node? right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
}
namespace Algorithms.DataStructures.Trees;

public class BinarySearchTree
{
    private Node? Root { get; set; }

    public void Insert(int value)
    {
        if (Root == null)
        {
            Root = new Node(value);
            return;
        }

        InsertRecursively(value, Root);
    }

    public Node? Find(int value)
    {
        if (Root == null || Root.Value == value)
        {
            return Root;
        }

        return FindAndPrint(value, Root);
    }

    public Node? FindRightMostMin(Node? node)
    {
        if (node == null)
        {
            return null;
        }

        Console.Write($"From node with {node.Value},");
        
        while (node != null)
        {
            if (node.Left == null)
            {
                Console.Write($"min is {node.Value}");
                Console.WriteLine();
                return node;
            }

            node = node.Left;
        }

        Console.WriteLine("min value is node itself");
        return null;
    }

    public Node? Delete(int value, Node? node)
    {
        if (node is null)
        {
            return null;
        }

        if (value > node.Value)
        {
            node.Right = Delete(value, node.Right);
        }
        else if (value < node.Value)
        {
            node.Left = Delete(value, node.Left);
        }
        else
        {
            if (node.Left == null && node.Right == null)
            {
                
            }
        }

        return null;
    }

    public void Display()
    {
        if (Root == null)
        {
            return;
        }

        var queue = new Queue<Node>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            Console.Write($"{current.Value} -> ");

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }

            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            }
        }

        Console.WriteLine();
    }

    private Node? InsertRecursively(int value, Node? node)
    {
        if (node == null)
        {
            return new Node(value);
        }

        if (node.Value == value)
        {
            return null;
        }

        if (value > node.Value)
        {
            node.Right = InsertRecursively(value, node.Right);
        }
        else if (value < node.Value)
        {
            node.Left = InsertRecursively(value, node.Left);
        }

        return node;
    }
    
    
    private Node? FindAndPrint(int value, Node? node)
    {
        while (true)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value == value)
            {
                Console.WriteLine($"Found value {value}");
                return node;
            }

            Console.Write($"{node.Value} -> ");
            if (value > node.Value)
            {
                node = node.Right;
                continue;
            }

            if (value < node.Value)
            {
                node = node.Left;
                continue;
            }

            return node;
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public Node(int value, Node? right = null, Node? left = null)
        {
            Right = right;
            Left = left;
            Value = value;
        }
    }
}
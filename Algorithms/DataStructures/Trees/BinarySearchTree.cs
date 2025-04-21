using Algorithms.Leetcode;

namespace Algorithms.DataStructures.Trees;

public class BinarySearchTree
{
    public TreeNode? Root { get; set; }

    public void Insert(int value)
    {
        if (Root == null)
        {
            Root = new TreeNode(value);
            return;
        }

        InsertRecursively(value, Root);
    }

    public TreeNode? Find(int value)
    {
        if (Root == null || Root.val == value)
        {
            return Root;
        }

        return FindAndPrint(value, Root);
    }

    public TreeNode? FindRightMostMin(TreeNode? node)
    {
        if (node == null)
        {
            return null;
        }

        Console.Write($"From node with {node.val},");
        
        while (node != null)
        {
            if (node.left == null)
            {
                Console.Write($"min is {node.val}");
                Console.WriteLine();
                return node;
            }

            node = node.left;
        }

        Console.WriteLine("min value is node itself");
        return null;
    }

    public TreeNode? Delete(int value, TreeNode? node)
    {
        if (node is null)
        {
            return null;
        }

        if (value > node.val)
        {
            node.right = Delete(value, node.right);
        }
        else if (value < node.val)
        {
            node.left = Delete(value, node.left);
        }
        else
        {
            if (node.left == null && node.right == null)
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

        var queue = new Queue<TreeNode>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            Console.Write($"{current.val} -> ");

            if (current.left != null)
            {
                queue.Enqueue(current.left);
            }

            if (current.right != null)
            {
                queue.Enqueue(current.right);
            }
        }

        Console.WriteLine();
    }

    private TreeNode? InsertRecursively(int value, TreeNode? node)
    {
        if (node == null)
        {
            return new TreeNode(value);
        }

        if (node.val == value)
        {
            return null;
        }

        if (value > node.val)
        {
            node.right = InsertRecursively(value, node.right);
        }
        else if (value < node.val)
        {
            node.left = InsertRecursively(value, node.left);
        }

        return node;
    }
    
    
    private TreeNode? FindAndPrint(int value, TreeNode? node)
    {
        while (true)
        {
            if (node == null)
            {
                return null;
            }

            if (node.val == value)
            {
                Console.WriteLine($"Found value {value}");
                return node;
            }

            Console.Write($"{node.val} -> ");
            if (value > node.val)
            {
                node = node.right;
                continue;
            }

            if (value < node.val)
            {
                node = node.left;
                continue;
            }

            return node;
        }
    }

}
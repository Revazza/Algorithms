namespace Algorithms.DataStructures;

public class SinglyLinkedList
{
    public Node? Head { get; set; }

    public void Insert(int value)
    {
        var lastNode = FindLast(); // BC: O(1) , WC: O(n) 

        if (lastNode == null) // O(1)
        {
            Head = new Node(value);
            return;
        }

        lastNode.Next = new Node(value);
    }

    public void Insert(int value, int position)
    {
        if (position is 0)
        {
            if (Head is null)
            {
                Head = new Node(value);
            }
            else
            {
                // When adding at first position
                var newNode = new Node(value);
                newNode.Next = Head;
                Head = newNode;
            }
            return;
        }
        
        var tail = Head;
        var current = Head?.Next;
        var currentPosition = 1;

        while (currentPosition != position)
        {
            // When adding at last position
            if (current == null && currentPosition + 1 == position)
            {
                tail!.Next = new Node(value);
                return;
            }
            if (current == null)
            {
                Console.WriteLine("Position is not compatible");
                return;
            }

            tail = current;
            current = current.Next;
            currentPosition++;
        }

        // When adding at somewhere middle
        tail!.Next = new Node(value);
        tail.Next.Next = current;
    }


    public void Delete(int value)
    {
        (Node? Previous, Node? NodeToDelete) = FindPreviousAndNodeToDelete(value);

        if (Previous is null && NodeToDelete is null)
        {
            Console.WriteLine($"No node found by value {value}");
            return;
        }

        if (Previous is null && NodeToDelete is not null)
        {
            Head = Head!.Next;
            Console.WriteLine($"Deleted head with value {value}");
            return;
        }

        Previous!.Next = NodeToDelete!.Next;
        Console.WriteLine($"Deleted node with value {value}");
        return;
    }

    public Node? FindLast()
    {
        if (Head is null) // O(1)
        {
            return null;
        }
        
        var currentNode = Head;
        while (currentNode.Next != null) // O(n) where n is the size of linked list
        {
            currentNode = currentNode.Next;
        }

        return currentNode;
    }
    
    public void Display()
    {
        var currentNode = Head;
        while (currentNode != null)
        {
            Console.Write(currentNode.Value + " -> ");
            currentNode = currentNode.Next;
        }

        Console.WriteLine();
    }
    
    private (Node? Previous, Node? NodeToDelete) FindPreviousAndNodeToDelete(int value)
    {
        if (Head is null)
        {
            return (null,null);
        }

        if (Head.Value == value)
        {
            return (null, Head);
        }

        var previousNode = Head;
        var nodeToDelete = Head.Next;
        while (nodeToDelete is not null && nodeToDelete.Value != value)
        {
            previousNode = nodeToDelete;
            nodeToDelete = nodeToDelete.Next;
        }

        return (previousNode, nodeToDelete);
    }
    
    public class Node
    {
        public int Value { get; set; }
        public Node? Next { get; set; }

        public Node(int value, Node? next = null)
        {
            Value = value;
            Next = next;
        }
    }
}
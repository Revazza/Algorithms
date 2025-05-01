using Algorithms.Leetcode;

namespace Algorithms.DataStructures.LinkedLists;

public class SinglyLinkedList
{
    public ListNode? Head { get; set; }


    public void Reverse()
    {
        if (Head is null)
        {
            return;
        }

        ListNode? newHead = null;
        var curr = Head;
        
        while (curr != null)
        {
            var temp = curr.next;
            curr.next = newHead;
            newHead = curr;
            curr = temp;
        }

        Head = newHead;
    }

    public void InsertRange(IEnumerable<int> values)
    {
        foreach (var value in values)
        {
            Insert(value);
        }
    }

    public void Insert(int value)
    {
        var lastNode = FindLast(); // BC: O(1) , WC: O(n) 

        if (lastNode == null) // O(1)
        {
            Head = new ListNode(value);
            return;
        }

        lastNode.next = new ListNode(value);
    }

    public void Insert(int value, int position)
    {
        if (position is 0)
        {
            if (Head is null)
            {
                Head = new ListNode(value);
            }
            else
            {
                // When adding at first position
                var newNode = new ListNode(value);
                newNode.next = Head;
                Head = newNode;
            }
            return;
        }
        
        var tail = Head;
        var current = Head?.next;
        var currentPosition = 1;

        while (currentPosition != position)
        {
            // When adding at last position
            if (current == null && currentPosition + 1 == position)
            {
                tail!.next = new ListNode(value);
                return;
            }
            if (current == null)
            {
                Console.WriteLine("Position is not compatible");
                return;
            }

            tail = current;
            current = current.next;
            currentPosition++;
        }

        // When adding at somewhere middle
        tail!.next = new ListNode(value);
        tail.next.next = current;
    }


    public void Delete(int value)
    {
        (ListNode Previous, ListNode NodeToDelete) = FindPreviousAndNodeToDelete(value);

        if (Previous is null && NodeToDelete is null)
        {
            Console.WriteLine($"No node found by value {value}");
            return;
        }

        if (Previous is null && NodeToDelete is not null)
        {
            Head = Head!.next;
            Console.WriteLine($"Deleted head with value {value}");
            return;
        }

        Previous!.next = NodeToDelete!.next;
        Console.WriteLine($"Deleted node with value {value}");
        return;
    }

    public ListNode? FindLast()
    {
        if (Head is null) // O(1)
        {
            return null;
        }
        
        var currentNode = Head;
        while (currentNode.next != null) // O(n) where n is the size of linked list
        {
            currentNode = currentNode.next;
        }

        return currentNode;
    }
    
    public void Display()
    {
        var currentNode = Head;
        while (currentNode != null)
        {
            Console.Write(currentNode.val + " -> ");
            currentNode = currentNode.next;
        }

        Console.WriteLine();
    }
    
    private (ListNode? Previous, ListNode? NodeToDelete) FindPreviousAndNodeToDelete(int value)
    {
        if (Head is null)
        {
            return (null,null);
        }

        if (Head.val == value)
        {
            return (null, Head);
        }

        var previousNode = Head;
        var nodeToDelete = Head.next;
        while (nodeToDelete is not null && nodeToDelete.val != value)
        {
            previousNode = nodeToDelete;
            nodeToDelete = nodeToDelete.next;
        }

        return (previousNode, nodeToDelete);
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
    }
}
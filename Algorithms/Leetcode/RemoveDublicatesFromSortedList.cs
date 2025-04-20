namespace Algorithms.Leetcode;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class RemoveDublicatesFromSortedList
{
    public ListNode Solve(ListNode head)
    {
        if (head == null)
        {
            return head;
        }
        
        var dummyHead = new ListNode(head.val);
        var tempHead = dummyHead;
        while (head != null)
        {
            if (head.val > tempHead.val)
            {
                tempHead.next = new ListNode(head.val);
                tempHead = tempHead.next;
            }

            head = head.next;
        }

        return dummyHead;
    }
}
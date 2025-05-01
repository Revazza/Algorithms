namespace Algorithms.Leetcode.LinkedLists;

public class MergeKSortedLists
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.Length == 0)
        {
            return null;
        }

        ListNode sorted = null;
        var startIndex = 0;
        for (; startIndex < lists.Length; startIndex++)
        {
            if (lists[startIndex] != null)
            {
                sorted = lists[startIndex];
                startIndex++;
                break;
            }
        }

        // 1 -> 1 -> 1 -> 4 -> 5
        // 
        for (int i = startIndex; i < lists.Length; i++)
        {
            if (lists[i] == null)
            {
                continue;
            }

            if (sorted!.next == null && lists[i].val >= sorted.val)
            {
                sorted.next = new ListNode(lists[i].val);
                lists[i] = lists[i].next;
            }
            else if(sorted.next == null && lists[i].val <= sorted.val)
            {
                var temp = sorted;
                sorted = new ListNode(lists[i].val);
                sorted.next = temp;
                lists[i] = lists[i].next;
            }
            var (sortedLast, ith) = Merge(ref sorted, lists[i]);

            while (ith != null)
            {
                sortedLast.next = new ListNode(ith.val);
                ith = ith.next;
                sortedLast = sortedLast.next;
            }
        }

        return sorted;
    }
    // [[1,4,5],[0,2]]
    //
    // Use Testcase
    // Output
    // [1,4,5,0,2]
    // Expected
    // [0,1,2,4,5]
    private (ListNode SortedLast, ListNode Ith) Merge(ref ListNode sorted, ListNode ith)
    {
        var prev = sorted;
        var current = prev.next;
        
        while (ith != null && current != null)
        {
            if (prev.val <= ith.val && current.val >= ith.val)
            {
                InsertBetween(prev, current, ith.val);
                ith = ith.next;
                prev = prev.next;
                continue;
            }

            if (prev.val > ith.val)
            {
                var temp = new ListNode(ith.val);
                temp.next = sorted;
                sorted = temp;
                ith = ith.next;
                prev = sorted;
                current = prev.next;
                continue;
            }

            prev = current;
            current = current.next;
        }

        return (prev, ith);
    }

    private void InsertBetween(ListNode prev, ListNode current, int val)
    {
        prev.next = new ListNode(val);
        prev.next.next = current;
    }
}
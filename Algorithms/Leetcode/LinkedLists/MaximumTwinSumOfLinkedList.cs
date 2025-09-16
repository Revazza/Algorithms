namespace Algorithms.Leetcode.LinkedLists;

public class MaximumTwinSumOfLinkedList
{
    public int PairSum(ListNode head) {
        var slow = head;
        var fast = head;

        while(fast != null && fast.next != null){
            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode prev = null; 
        var curr = slow;
        while (curr != null) {
            var next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        var left = head;
        var right = prev;

        var max = 0;
        while(left != null && right != null){
            max = Math.Max(left.val + right.val, max);     
            left = left.next;
            right = right.next;
        }

        return max;
    }
}
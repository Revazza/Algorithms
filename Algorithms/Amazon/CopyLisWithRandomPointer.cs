namespace Algorithms.Amazon;

using Node = DataStructures.LinkedLists.NodeWithRandom;

public class CopyLisWithRandomPointer
{
    public Node CopyRandomList(Node head) {
        
        if(head is null){
            return head;
        }

        var copied = new Dictionary<Node, Node>();
        var newHead = new Node(0);
        var newHeadRef = newHead;

        var temp = head;
        while(temp != null){
            var copiedCurrent = GetOrCreateCopy(temp, copied);
            copiedCurrent.next = GetOrCreateCopy(temp.next, copied);
            copiedCurrent.random = GetOrCreateCopy(temp.random, copied);

            newHead.next = copiedCurrent;
            newHead = newHead.next;
            temp = temp.next;
        }

        return newHeadRef.next;
    }

    public Node GetOrCreateCopy(Node original, Dictionary<Node, Node> copied) {
        if(original is null){
            return null;
        }
        
        if (!copied.ContainsKey(original)) {
            copied[original] = new Node(original.val);
        }
            
        return copied[original];
    }
}
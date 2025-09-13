namespace Algorithms.DataStructures.LinkedLists;

public class NodeWithRandom {
    public int val;
    public NodeWithRandom next;
    public NodeWithRandom random;
    
    public NodeWithRandom(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
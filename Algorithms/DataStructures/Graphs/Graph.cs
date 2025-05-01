namespace Algorithms.DataStructures.Graphs;

public class Graph
{
    public Dictionary<int, Node> Nodes = new();

    public void AddNode(int val)
    {
        if (Nodes.ContainsKey(val))
        {
            Console.WriteLine($"Node with value {val} already exists");
            return;
        }

        Nodes[val] = new Node(val);
    }

    public void AddEdge(int val1, int val2)
    {
        if (!Nodes.ContainsKey(val1) || !Nodes.ContainsKey(val2))
        {
            Console.WriteLine("One of the values doesn't exist as node");
            return;
        }

        var node1 = Nodes[val1];
        var node2 = Nodes[val2];

        node1.neighbors.Add(node2);
        node2.neighbors.Add(node1);
    }

    public Node GetNode(int val) => Nodes.GetValueOrDefault(val);

    public void DisplayBFS()
    {
        if (Nodes.Count == 0)
        {
            Console.WriteLine("Nodes are empty");
            return;
        }

        var nodes = Nodes.Values.ToList();

        var visited = GenerateDefaultUnvisited();
        var queue = new Queue<Node>();
        queue.Enqueue(nodes[0]);
        visited[nodes[0].val] = true;

        while (queue.Count != 0)
        {
            var current = queue.Dequeue();
            Console.Write($"{current.val} ");

            foreach (var neighbor in current.neighbors)
            {
                if (visited[neighbor.val])
                {
                    continue;
                }
                
                queue.Enqueue(neighbor);
                visited[current.val] = true;

            }
        }
    }

    public Node DeepCopy(Node node)
    {
        if (node == null || node.neighbors.Count == 0)
        {
            return node;
        }

        var map = new Dictionary<Node, Node>();
        map[node] = new Node(node.val);
        var queue = new Queue<Node>();
        queue.Enqueue(node);

        while (queue.Count != 0)
        {
            var current = queue.Dequeue();

            foreach (var neighbor in current.neighbors)
            {
                if (!map.ContainsKey(neighbor))
                {
                    map[neighbor] = new Node(neighbor.val);
                    queue.Enqueue(neighbor);
                }
                
                map[current].neighbors.Add(map[neighbor]);
            }
        }

        return map[node];
    }

    public void Initialize()
    {
        AddNode(1);
        AddNode(2);
        AddNode(3);
        AddNode(4);
        AddNode(5);
        AddEdge(1, 2);
        AddEdge(1, 3);
        AddEdge(2, 4);
        AddEdge(3, 5);
    }

    private Dictionary<int, bool> GenerateDefaultUnvisited()
        => Nodes.Keys.ToDictionary(key => key, _ => false);
}
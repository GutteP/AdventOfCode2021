
namespace Library;

public class Pathfinding
{
    private readonly Dictionary<string, Node> _nodes;
    public Pathfinding(Dictionary<string, Node> nodes)
    {
        _nodes = nodes;
    }

    public List<Path> FindPaths(Node from, Node to)
    {
        List<Path> response = new();
        foreach (var n in _nodes[from.Name].Neighbors)
        {
            var r = FindPaths(_nodes[n.Name], new List<Node> { _nodes[from.Name] }, to);
            if (r != null) response.AddRange(r);
        }
        return response;
    }

    private List<Path> FindPaths(Node node, List<Node> visited, Node to)
    {
        if (!IsVisitable(node, visited)) return null;

        List<Path> response = null;
        foreach (var n in node.Neighbors)
        {
            if (IsVisitable(_nodes[n.Name], visited))
            {
                List<Node> newV = new List<Node>();
                newV.AddRange(visited);
                newV.Add(node);
                if (n.Name == to.Name)
                {
                    newV.Add(_nodes[n.Name]);
                    if (response == null) response = new();
                    response.Add(new Path(newV));
                    continue;
                }
                var r = FindPaths(_nodes[n.Name], newV, to);
                if (r != null)
                {
                    if (response == null) response = new();
                    response.AddRange(r);
                }
            }
        }
        return response;
    }

    protected virtual bool IsVisitable(Node node, List<Node> visited)
    {
        if (visited.Contains(node)) return false;
        return true;
    }

    protected virtual double DistanceToTarget(Node from, Node end)
    {
        return (Math.Abs(from.Position.X - end.Position.X) + Math.Abs(from.Position.Y - end.Position.Y));
    }

    public Path AStar(Node start, Node end)
    {
        List<Node> open = new List<Node> { start };
        List<Node> closed = new();
        Node current = default;

        while (open.Count != 0 && !closed.Exists(x => x == end))
        {
            current = open[0];
            open.Remove(current);
            closed.Add(current);

            foreach (var neighbor in current.Neighbors.OrderBy(x => x.Weight))
            {
                Node n = _nodes[neighbor.Name];
                if (IsVisitable(n, closed))
                {
                    if (!open.Contains(n))
                    {
                        n.Parent = current;
                        n.DistanceToTarget = DistanceToTarget(n, end);
                        n.AccumulatedCost = n.Weight + n.Parent.AccumulatedCost;
                        open.Add(n);
                        open = open.OrderBy(node => node.FScore).ToList();
                    }
                }               
            } 
        }

        if (!closed.Exists(x => x == end)) return null;       

        return ReconstructPath(closed[closed.IndexOf(current)], start);
    }

    public double GetHCost(Node a, Node b)
    {
        double x = Math.Abs(a.Position.X - b.Position.X);
        double y = Math.Abs(a.Position.Y - b.Position.Y);
        return (x+y)*6;
    }



    public Path ReconstructPath(Node target, Node start)
    {
        double weight = target.AccumulatedCost;
        Stack<Node> nodes = new();
        if (target == null) return null;
        do
        {
            nodes.Push(target);
            target = target.Parent;
        } while (target != start && target != null);
        Path path = new Path(nodes);
        path.Weight = weight;
        return path;
    }
}

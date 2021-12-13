
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

    //public Path FindShortestPath(Node start, Node end, double h)
    //{
    //    List<Node> openSet = new List<Node> { start };
    //    List<Node> cameFrom = new();
    //    List<(Node Node, double Score)> gScore = new List<(Node Node, double Score)> { (start, 0) };
    //    List<(Node Node, double Score)> fScore = new List<(Node Node, double Score)> { (start, 0) };

    //    while (openSet.Count != 0)
    //    {
    //        Node current = fScore.MinBy(n => n.Score).Node;
    //        if (current == end) return ReconstructPath(cameFrom, current);
    //        openSet.Remove(current);
    //        foreach (var neighbor in current.Neighbors)
    //        {
    //            double tentativeGScore = gScore.Where(x => x.Node == current).FirstOrDefault().Score + neighbor.Weight;
    //            if(gScore.Where(x => x.Node.Name == neighbor.Name).Any() && tentativeGScore < gScore.Where(x => x.Node.Name == neighbor.Name).FirstOrDefault().Score)
    //            {
    //                cameFrom.Add()
    //            }
    //        }

    //    }

    //}

    //public Path ReconstructPath(List<Node> cameFrom, Node current)
    //{
    //    return new Path(cameFrom);
    //}



    protected virtual bool IsVisitable(Node node, List<Node> visited)
    {
        if (visited.Contains(node)) return false;
        return true;
    }
}

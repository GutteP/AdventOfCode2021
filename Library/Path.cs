
namespace Library;

public record Path
{
    public IEnumerable<Node> Nodes { get; private set; }
    public double Weight { get; set; }
    public Path(IEnumerable<Node> nodes)
    {
        Nodes = nodes ?? throw new ArgumentNullException(nameof(nodes));
        for (int i = 1; i < Nodes.Count(); i++)
        {
            Weight += Nodes.ElementAt(i).Neighbors.Where(n => n.Name == Nodes.ElementAt(i - 1).Name).FirstOrDefault().Weight;
        }
    }
}

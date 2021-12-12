using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public record Node
    {
        public Node(string name)
        {
            Name = name;
            Neighbors = new List<(string Name, double Weight)>();
        }
        public string Name { get; private set; }
        public List<(string Name, double Weight)> Neighbors { get; private set; }

        public void AddNeighbor(Node n, double? weight = 1)
        {
            if (Neighbors.Where(x => x.Name == n.Name).Any()) return;
            else Neighbors.Add((n.Name, (double)weight));
        }
    }
}

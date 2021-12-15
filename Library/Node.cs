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
        public Position Position { get; private set; }
        public double Weight { get; set; }

        public Node Parent { get; set; }
        public double DistanceToTarget { get; set; }
        public double AccumulatedCost { get; set; }

        public double FScore
        {
            get
            {
                if (DistanceToTarget != -1 && AccumulatedCost != -1) return DistanceToTarget + AccumulatedCost;
                else return -1;
            }
        }

        public void AddNeighbor(Node n, double? weight = 1)
        {
            if (Neighbors.Where(x => x.Name == n.Name).Any()) return;
            else Neighbors.Add((n.Name, (double)weight));
        }

        public void AddPosition(Position position)
        {
            Position = position;
        }
    }
}

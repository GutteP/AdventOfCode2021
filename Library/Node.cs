using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Node : IEquatable<Node>, IEqualityComparer<Node>
    {
        public Node(string name)
        {
            Name = name;
            Neighbors = new List<string>();
        }
        public string Name { get; private set; }
        public List<string> Neighbors { get; private set; }

        public void AddNeighbor(Node n)
        {
            if (Neighbors.Contains(n.Name)) return;
            else Neighbors.Add(n.Name);
        }

        public bool Equals(Node? other)
        {
            return Name == other.Name;
        }

        public bool Equals(Node? x, Node? y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode([DisallowNull] Node obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}

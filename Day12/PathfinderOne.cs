using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    public class PathfinderOne : Pathfinding
    {
        public PathfinderOne(Dictionary<string, Node> nodes) : base(nodes) { }

        protected override bool IsVisitable(Node node, List<Node> visited)
        {
            if (node.Name == "start") return false;
            if (node.IsBig()) return true;
            if (visited.Contains(node)) return false;
            return true;
        }
    }
}

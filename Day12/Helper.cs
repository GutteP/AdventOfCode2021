using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    public static class Helper
    {
        public static Dictionary<string, Node> NodeFromInput(IEnumerable<string> input)
        {
            Dictionary<string, Node> nodes = new Dictionary<string, Node>();
            foreach (string path in input)
            {
                string[] sp = path.Split('-');
                Node n1 = default;
                Node n2 = default;

                if (nodes.ContainsKey(sp[0])) n1 = nodes[sp[0]];
                else n1 = new Node(sp[0]);
                if (nodes.ContainsKey(sp[1])) n2 = nodes[sp[1]];
                else n2 = new Node(sp[1]);

                n1.AddNeighbor(n2);
                n2.AddNeighbor(n1);

                if (!nodes.ContainsKey(n1.Name)) nodes.Add(n1.Name, n1);
                if (!nodes.ContainsKey(n2.Name)) nodes.Add(n2.Name, n2);
            }
            return nodes;
        }

        public static bool IsBig(this Node node)
        {
            return node.Name.ToUpper() == node.Name;
        }
    }
}

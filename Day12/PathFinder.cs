using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    public class PathFinder
    {
        private readonly Dictionary<string, Node> _nodes;
        public PathFinder(Dictionary<string, Node> nodes)
        {
            _nodes = nodes;
        }

        public List<List<Node>> FindPaths(bool oneExtraSmallVisit = false)
        {
            List<List<Node>> response = new();
            foreach (var n in _nodes["start"].Neighbors)
            {
                var r = FindPath(_nodes[n], new List<Node> { _nodes["start"] }, oneExtraSmallVisit);
                if (r != null) response.AddRange(r);
            }
            return response;
        }

        private List<List<Node>> FindPath(Node node, List<Node> visited, bool extraSmallVisit = false)
        {
            if(!IsVisitable(node, visited, extraSmallVisit)) return null;

            List<List<Node>> response = null;
            foreach (string n in node.Neighbors)
            {
                if (IsVisitable(_nodes[n], visited, extraSmallVisit))
                {
                    List<Node> newV = new List<Node>();
                    newV.AddRange(visited);
                    newV.Add(node);
                    if (n == "end")
                    {
                        newV.Add(_nodes[n]);
                        if (response == null) response = new();
                        response.Add(newV);
                        continue;
                    }
                    var r = FindPath(_nodes[n], newV, extraSmallVisit);
                    if (r != null)
                    {
                        if (response == null) response = new();
                        response.AddRange(r);
                    }
                }
            }
            return response;
        }

        private bool IsVisitable(Node n, List<Node> visited, bool extraSmallVisit = false)
        {
            bool extra = false;
            if(extraSmallVisit) extra = HasExtraVisitLeft(visited);

            if (n.Name == "start") return false;
            if (n.IsBig()) return true;
            if (extra) return true;
            if (visited.Contains(n)) return false;
            return true;
        }

        private bool HasExtraVisitLeft(List<Node> visited)
        {
            foreach (var n in visited)
            {
                if (n.IsBig()) continue;
                if(visited.FindAll(x => x == n).Count() > 1) return false;
            }
            return true;
        }
    }

    
}

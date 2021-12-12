using Library;

namespace Day12
{
    public class PathfinderTwo : Pathfinding
    {
        public PathfinderTwo(Dictionary<string, Node> nodes) : base(nodes) { }

        protected override bool IsVisitable(Node node, List<Node> visited)
        {
            bool extra = HasExtraVisitLeft(visited);

            if (node.Name == "start") return false;
            if (node.IsBig()) return true;
            if (extra) return true;
            if (visited.Contains(node)) return false;
            return true;
        }

        private bool HasExtraVisitLeft(List<Node> visited)
        {
            foreach (var n in visited)
            {
                if (n.IsBig()) continue;
                if (visited.FindAll(x => x == n).Count() > 1) return false;
            }
            return true;
        }
    }
}

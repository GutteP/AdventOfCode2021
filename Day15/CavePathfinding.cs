using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15
{
    public class CavePathfinding : Pathfinding
    {
        private readonly int _targetDistanceMultiplier;
        public CavePathfinding(Dictionary<string, Node> nodes, int targetDistanceMultiplier) : base(nodes)
        {
            _targetDistanceMultiplier = targetDistanceMultiplier;
        }

        protected override double DistanceToTarget(Node from, Node end)
        {
            return (Math.Abs(from.Position.X - end.Position.X) + Math.Abs(from.Position.Y - end.Position.Y)) * _targetDistanceMultiplier;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23
{
    public class Burrow
    {
        public Dictionary<Position, Amphipod> Amphipods { get; set; }
        
        public bool Walkable(Amphipod a, Position p)
        {
            if(Amphipods.TryGetValue(p, out Amphipod v))
            {
                if (v != default) return false;
            }
            if (BurrowParts.K.HasFlag(a.CurrentPosition) && BurrowParts.K.HasFlag(p)) return false;
            if(BurrowParts.K.HasFlag(a.CurrentPosition) && a.Home.HasFlag(p))
            {
                if(!CheckRoom(a.Home)) return false;
            }
            return true;
        }

        private bool CheckRoom(Position p)
        {
            foreach (var e in Enum.GetValues(typeof(Position)))
            {
                if (p.HasFlag((Position)e))
                {
                    if (Amphipods.TryGetValue((Position)e, out Amphipod v))
                    {
                        if (v != default && v.Home == p) return false;
                    }
                }
            }
            return true;
        }
    }

    public static class BurrowParts
    {
        public static Position K
        {
            get
            {
                return Position.k1 | Position.k2 | Position.k3 | Position.k4 | Position.k5 | Position.k6 |
  Position.k7 | Position.k8 | Position.k9 | Position.k10 | Position.k11;
            }
        }

        public static Position A
        {
            get
            {
                return Position.a1 | Position.a2;
            }
        }

        public static Position B
        {
            get
            {
                return Position.b1 | Position.b2;
            }
        }

        public static Position C
        {
            get
            {
                return Position.c1 | Position.c2;
            }
        }
        public static Position D
        {
            get
            {
                return Position.d1 | Position.d2;
            }
        }
    }

    public enum Position
    {
        k1, k2, k3, k4, k5, k6, k7, k8, k9, k10, k11, 
        a1, a2,
        b1, b2,
        c1, c2,
        d1, d2
    }
}

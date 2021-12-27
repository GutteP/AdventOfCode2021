using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23
{
    public class Amphipod
    {
        public AmphipodType Type { get; set; }
        public Position CurrentPosition { get; set; }
        public int StepsTaken { get; set; }
        public int StepCost 
        { 
            get 
            {
                switch (Type)
                {
                    case AmphipodType.A:
                        return 1;
                    case AmphipodType.B:
                        return 10;
                    case AmphipodType.C:
                        return 100;
                    case AmphipodType.D:
                        return 1000;
                    default:
                        throw new NotImplementedException();
                }
            } 
        }

        public Position Home 
        { 
            get 
            {
                switch (Type)
                {
                    case AmphipodType.A:
                        return BurrowParts.A;
                    case AmphipodType.B:
                        return BurrowParts.B;
                    case AmphipodType.C:
                        return BurrowParts.C;
                    case AmphipodType.D:
                        return BurrowParts.D;
                    default:
                        throw new NotImplementedException();
                }
            } 
        }

        public bool Stoppable()
        {
            if (CurrentPosition == Position.k3 ||
                CurrentPosition == Position.k5 ||
                CurrentPosition == Position.k7 ||
                CurrentPosition == Position.k9)
            {
                return false;
            }
            return true;
        }

        public Position Neighbors()
        {
            switch (CurrentPosition)
            {
                case Position.k1:
                    return Position.k2;
                case Position.k2:
                    return Position.k1 | Position.k3;
                case Position.k3:
                    return Position.k2 | Position.k4 | Position.a1;
                case Position.k4:
                    return Position.k3 | Position.k5;
                case Position.k5:
                    return Position.k4 | Position.k6 | Position.b1;
                case Position.k6:
                    return Position.k5 | Position.k7;
                case Position.k7:
                    return Position.k6 | Position.k8 | Position.c1;
                case Position.k8:
                    return Position.k7 | Position.k9;
                case Position.k9:
                    return Position.k8 | Position.k10 | Position.d1;
                case Position.k10:
                    return Position.k9 | Position.k11;
                case Position.k11:
                    return Position.k10;
                case Position.a1:
                    return Position.k3 | Position.a2;
                case Position.a2:
                    return Position.a1;
                case Position.b1:
                    return Position.k5 | Position.b2;
                case Position.b2:
                    return Position.b1;
                case Position.c1:
                    return Position.k7 | Position.c2;
                case Position.c2:
                    return Position.c1;
                case Position.d1:
                    return Position.k9 | Position.d2;
                case Position.d2:
                    return Position.d1;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public enum AmphipodType
    {
        A,
        B,
        C,
        D
    }


}

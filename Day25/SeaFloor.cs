using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day25
{
    public class SeaFloor : Map
    {
        public SeaFloor(int x, int y) : base(x, y)
        {
        }

        public void Print()
        {
            for(int y = 0; y < Positions.GetLength(0); y++)
            {
                StringBuilder sb = new StringBuilder(Positions.GetLength(1));
                for (int x = 0; x < Positions.GetLength(1); x++)
                {
                    sb.Append(Positions[y, x] == 0 ? '.' : Positions[y, x] == 1 ? '>' : 'v');
                    //sb.Append(Positions[y, x]);
                }
                Console.WriteLine(sb.ToString());
            }
            Console.WriteLine();
        }

        public bool Step()
        {
            List<(int oldY, int oldX, int newY, int newX)> toMoveEast = new();
            for (int y = 0; y < Positions.GetLength(0); y++)
            {
                for (int x = 0; x < Positions.GetLength(1); x++)
                {
                    if(Positions[y, x] == 1)
                    {

                        (int y, int x) east = GetNextPosition((y, x), SeaFloorType.East);
                        if (Get(east) == 0) toMoveEast.Add((y, x, east.y, east.x));
                    }
                }
            }
            Move(toMoveEast, SeaFloorType.East);

            List<(int oldY, int oldX, int newY, int newX)> toMoveSouth = new();
            for (int y = 0; y < Positions.GetLength(0); y++)
            {
                for (int x = 0; x < Positions.GetLength(1); x++)
                {
                    if (Positions[y, x] == 2)
                    {

                        (int y, int x) south = GetNextPosition((y, x), SeaFloorType.South);
                        if (Get(south) == 0) toMoveSouth.Add((y, x, south.y, south.x));
                    }
                }
            }
            Move(toMoveSouth, SeaFloorType.South);

            if (toMoveEast.Count != 0 || toMoveSouth.Count != 0) return true;
            return false;
        }

        private void Move(List<(int oldY, int oldX, int newY, int newX)> toMove, SeaFloorType t)
        {
            foreach ((int oldY, int oldX, int newY, int newX) item in toMove)
            {
                Positions[item.oldY, item.oldX] = 0;
                Positions[item.newY, item.newX] = (int)t;
            }
        }

        private (int y, int x) GetNextPosition((int y, int x) p, SeaFloorType t)
        {
            if (t == SeaFloorType.East)
            {
                (int y, int x) east = (p.y, p.x + 1);
                if (east.x > Positions.GetLength(1) - 1) east = (p.y, 0);
                return east;
            }
            else if (t == SeaFloorType.South)
            {
                (int y, int x) south = (p.y +1, p.x);
                if (south.y > Positions.GetLength(0) - 1) south = (0, p.x);
                return south;
            }
            else throw new Exception();
        }
    }

    public enum SeaFloorType
    {
        Empty = 0,
        East = 1,
        South = 2
    }
}

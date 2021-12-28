using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Map
    {
        public Map(int x, int y)
        {
            Positions = new int[y, x];
        }

        public Map(List<Position> positions)
        {
            Positions = new int[positions.MaxBy(p => p.Y).Y+1, positions.MaxBy(p => p.X).X+1];
            foreach (Position p in positions)
            {
                Set(p.X, p.Y, 1);
            }
        }

        public int[,] Positions { get; private set; }

        public bool Set(int x, int y, int value)
        {
            try
            {
                Positions[y, x] = value;
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
        public bool Set(Position p, int value)
        {
            return Set(p.X, p.Y, value);
        }

        public int? Get(Position p)
        {
            try
            {
                return Positions[p.Y, p.X];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        public int? Get((int y, int x) p)
        {
            return Positions[p.y, p.x];
        }

        public void TickAll(bool down = false)
        {
            for (int y = 0; y < Positions.GetLength(1); y++)
            {
                for (int x = 0; x < Positions.GetLength(0); x++)
                {
                    if (!down) Positions[y, x]++;
                    else if (down) Positions[y, x]--;
                }
            }
        }

        public List<Position> GetAll(params int[] values)
        {
            List<Position> result = new();
            for (int y = 0; y < Positions.GetLength(1); y++)
            {
                for (int x = 0; x < Positions.GetLength(0); x++)
                {
                    if (values.Contains(Positions[y, x])) result.Add(new Position(x, y));
                }
            }
            return result;
        }

        public bool Tick(Position p, bool down = false)
        {
            try
            {
                if (down) Positions[p.Y, p.X]--;
                else Positions[p.Y, p.X]++;
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
    }
}

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
            Positions = new int[x, y];
        }

        public int[,] Positions { get; private set; }

        public bool Set(int x, int y, int value)
        {
            try
            {
                Positions[x, y] = value;
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
                return Positions[p.X, p.Y];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        public void TickAll(bool down = false)
        {
            for (int i = 0; i < Positions.GetLength(0); i++)
            {
                for (int j = 0; j < Positions.GetLength(1); j++)
                {
                    if(!down)Positions[i, j]++;
                    else if (down) Positions[i, j]--;
                }
            }
        }

        public List<Position> GetAll(params int[] values)
        {
            List<Position> result = new();
            for (int i = 0; i < Positions.GetLength(0); i++)
            {
                for (int j = 0; j < Positions.GetLength(1); j++)
                {
                    if(values.Contains(Positions[i, j])) result.Add(new Position(i, j));
                }
            }
            return result;
        }

        public bool Tick(Position p, bool down = false)
        {
            try
            {
                if (down) Positions[p.X, p.Y]--;
                else Positions[p.X, p.Y]++;
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            
        }
    }
}
